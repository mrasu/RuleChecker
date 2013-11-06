using Microsoft.SqlServer.TransactSql.ScriptDom;
using RuleChecker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RuleChecker.SqlCheck
{
    public class SqlChecker : Checker
    {
        //処理に時間がかかると、TextReaderの解放までに時間がかかる事になる。
        public override CheckResult Check(TextReader reader)
        {
            TSqlFragment parsedTSql = Parse(reader);
            return CheckParsedTsql(parsedTSql);
        }

        private TSqlFragment Parse(TextReader reader)
        {
            //引数のfalseが謎。
            //Specifies whether quoted identifier handling is on.
            TSqlParser parser = new TSql100Parser(false);

            IList<ParseError> errors;
            TSqlFragment parsed;
            parsed = parser.Parse(reader, out errors);
            if (errors.Count != 0)
            {
                string errorMessage = "";
                foreach (ParseError error in errors)
                {
                    errorMessage = errorMessage + "\n" + error.Line + " : " + error.Message;
                }
                throw new ParseException("パース失敗\n" + errorMessage);
            }

            return parsed;
        }

        private CheckResult CheckParsedTsql(TSqlFragment parsedTSql)
        {
            SQLCheckVisitor[] checkTargetVisitors = CreateCheckTargetVisitors();

            foreach (SQLCheckVisitor visitor in checkTargetVisitors)
            {
                parsedTSql.Accept(visitor);
            }

            CheckResult checkResult = new SqlCheckerResult(checkTargetVisitors);
            return checkResult;
        }

        private SQLCheckVisitor[] CreateCheckTargetVisitors()
        {
            SQLCheckVisitor[] checkTargetVisitors = {
                new TableNameDeclareCheckVisitor()
            };
            
            return checkTargetVisitors;
        }
    }

    class SqlCheckerResult : CheckResult
    {
        private SQLCheckVisitor[] checkedVisitorArray;

        public SqlCheckerResult(SQLCheckVisitor[] checkedVisitorArray)
        {
            this.checkedVisitorArray = checkedVisitorArray;
        }

        public override string ToFormattedString()
        {
            //StringBuilderはAppendで組み立てるべきだが、長いのでstringの生成後にAppendする。ボトルネックになる可能性あり
            StringBuilder formattedStringBuilder = new StringBuilder();
            foreach (SQLCheckVisitor visitor in checkedVisitorArray)
            {
                formattedStringBuilder.Append(visitor.GetType().Name + "\r\n");

                IList<Notification> illegalList = visitor.getNotificationList().GetIllegalList();
                if (illegalList.Count == 0)
                {
                    formattedStringBuilder.Append("OK");
                    continue;
                }

                foreach (Notification illegal in illegalList)
                {
                    formattedStringBuilder.Append("TYPE : " + illegal.Type + "\r\n" + illegal.Message + "\r\n");
                }
            }

            return formattedStringBuilder.ToString();
        }
    }

    public class SQLCheckVisitor : TSqlFragmentVisitor
    {
        protected NotificationList notificationList = new NotificationList();
        
        public NotificationList getNotificationList()
        {
            return notificationList;
        }
    }

    public class ParseException : CheckException
    {
        public ParseException(string message) :
            base(message)
        {
            //do nothing
        }
    }

}
