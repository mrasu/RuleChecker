using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RuleChecker.SqlCheck
{
    ///複数テーブルをJOINしている場合、テーブル名と共に宣言されているかをチェックするクラス。
    ///JOINがあるのに列のテーブルが指定されていない場所がないかどうかをチェックする。
    public class TableNameDeclareCheckVisitor : SQLCheckVisitor
    {
        //文が入れ子になった場合、内と外でJOINの有無が変わる可能性がある。
        //その場合に、JOINの有無を区別するために内と外を別のTableNameIllegalCandidateで管理する。
        private Stack<TableNameIllegalCandidate> candidateStack = new Stack<TableNameIllegalCandidate>();

        
        //SETの左側はテーブル名が指定されていなくても問題がないので、スルーするためのフラグが必要。
        //AssignmentSetClauseはSET中で使用されるクラス。
        //このタイプのフラグが複数いる場合はフラグ以外の方法を考えなくては
        private bool isLeftAssignmentSetClause = false;
        
        //行を見ている時にのみテーブル名の宣言があるかどうかを見る。
        private bool isInsideColumnReference = false;

        private const IllegalType DEFAULT_ILLEGAL_TYPE = IllegalType.NotDeclaredTableName;
        
        //SELECT文
        public override void ExplicitVisit(SelectStatement node)
        {
            TableNameIllegalCandidate candidate = CreateAndPushCandidate();
            base.ExplicitVisit(node);
            PopAndSetIllegalStatement(candidate);
        }
        
        //スタックに積む。詳しくはcandidateStack参照。
        private TableNameIllegalCandidate CreateAndPushCandidate()
        {
            TableNameIllegalCandidate candidate = new TableNameIllegalCandidate();
            candidateStack.Push(candidate);
            return candidate;
        }
        
        private void PopAndSetIllegalStatement(TableNameIllegalCandidate candidate)
        {
            //本来はポップだけで問題ないが、スタック操作に失敗する気がするので、バリアを張っておく。
            if (candidate != candidateStack.Pop())
            {
                throw new InvalidOperationException("正しくスタックが動作していない。popのし忘れかpushのし忘れ");
            }
            //違反候補に上がっていて、Joinがないのなら規約違反確定。
            if (candidate.hasJoin == true)
            {
                //ZIP!
                IList<string> illegalTextList = candidate.TextList;
                IList<string> illegalCommentList = candidate.CommentList;

                var illegalList = illegalTextList.Zip(illegalCommentList, (text, comment) => new { text = text, comment = comment });
                foreach (var illegal in illegalList)
                {
                    notificationList.Add(
                        NotificationLevel.Illegal,
                        DEFAULT_ILLEGAL_TYPE,
                        "JOINがあるのに [" + illegal.text + "] のテーブル宣言がない。\r\n" + illegal.comment,
                        illegal.text
                    );
                }
            }
        }
        
        //UPDATEやINSERTなどでSELECTを使用したときに発生するExplicitVisit
        public override void ExplicitVisit(QueryDerivedTable node)
        {
            TableNameIllegalCandidate candidate = CreateAndPushCandidate();
            base.ExplicitVisit(node);
            PopAndSetIllegalStatement(candidate);
        }
        
        public override void ExplicitVisit(InsertStatement node)
        {
            TableNameIllegalCandidate candidate = CreateAndPushCandidate();
            base.ExplicitVisit(node);
            PopAndSetIllegalStatement(candidate);
        }
        
        public override void ExplicitVisit(DeleteStatement node)
        {
            TableNameIllegalCandidate candidate = CreateAndPushCandidate();
            base.ExplicitVisit(node);
            PopAndSetIllegalStatement(candidate);
        }
        
        public override void ExplicitVisit(UpdateStatement node)
        {
            TableNameIllegalCandidate candidate = CreateAndPushCandidate();
            base.ExplicitVisit(node);
            PopAndSetIllegalStatement(candidate);
        }
        
        //SET式。左側はテーブル名の宣言がなくてもいい。
        public override void ExplicitVisit(AssignmentSetClause node)
        {
            isLeftAssignmentSetClause = true;
            base.ExplicitVisit(node);
        }
        
        //列を参照する場合に呼び出される。これ以下はテーブル名を指定しているか確認する必要がある。
        public override void ExplicitVisit(ColumnReferenceExpression node)
        {
            isInsideColumnReference = true;
            base.ExplicitVisit(node);
            isInsideColumnReference = false;
        }
        
        //列を参照する場合に呼び出される。
        //MultiPartIdentifier.Countが1だった場合は、テーブルの宣言なしに列を指定しているということを意味するので違反候補に追加する。
        public override void ExplicitVisit(MultiPartIdentifier node)
        {
            if (isInsideColumnReference == true &&
                node.Count == 1 &&
                candidateStack.Count > 0 &&
                isLeftAssignmentSetClause == false)
            {
                TableNameIllegalCandidate candidate = candidateStack.Peek();
                candidate.AddText(node.Identifiers[0].Value);

                //commentには理解のために前後の文を追加する。
                
                IList<TSqlParserToken> tokenList = node.ScriptTokenStream;
                int commentFirstIndex = node.FirstTokenIndex - 10 < 0 ? 0 : node.FirstTokenIndex - 10;
                int commentLastIndex = node.FirstTokenIndex + 10 < tokenList.Count ? node.FirstTokenIndex + 10 : tokenList.Count;
                string comment = tokenList[node.FirstTokenIndex].Line.ToString() + "行目付近：";
                for (int i = commentFirstIndex; i < commentLastIndex; i++)
                {
                    comment = comment + tokenList[i].Text;
                }
                candidate.AddComment(comment);
            }

            base.ExplicitVisit(node);
            isLeftAssignmentSetClause = false;
        }
        
        //JOINが発生する場合に呼び出される。
        public override void ExplicitVisit(QualifiedJoin node)
        {
            if (candidateStack.Count > 0)
            {
                TableNameIllegalCandidate candidate = candidateStack.Peek();
                candidate.hasJoin = true;
            }
            base.ExplicitVisit(node);
        }
        
        private class TableNameIllegalCandidate
        {
            private IList<string> textList = new List<string>();
            public bool hasJoin { get; set; }
            private IList<string> commentList = new List<string>();

            public void AddText(string text)
            {
                textList.Add(text);
            }

            public void AddComment(string comment)
            {
                this.commentList.Add(comment);
            }

            public IList<string> CommentList
            {
                get { return new List<string>(commentList); }
            }
            public IList<string> TextList
            {
                get { return new List<string>(textList); }
            }
        }
    }
}
