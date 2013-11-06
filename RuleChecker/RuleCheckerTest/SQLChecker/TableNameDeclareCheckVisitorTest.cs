using NUnit.Framework;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using RuleChecker.SqlCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SqlCheckerTest
{
    [TestFixture]
    public class TableNameDeclareCheckVisitorTest
    {
        [Test]
        public void TestSelectSimple()
        {
            string tsql = @"
                SELECT
                    *
                FROM
                    book
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleWithWhere()
        {
            string tsql = @"
                SELECT
                    *
                FROM
                    book
                WHERE
                    id_author = 2
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文(WHERE付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleWithOrder()
        {
            string tsql = @"
                SELECT
                    *
                FROM
                    book
                ORDER BY
                    id_author
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文(ORDER付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleWithGroup()
        {
            string tsql = @"
                SELECT
                    id_author
                FROM
                    book
                GROUP BY
                    id_author
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文(GROUP付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleWithAggregateFunction()
        {
            string tsql = @"
                SELECT
                    COUNT(*)
                FROM
                    book
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文(集計関数付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleWithHaving()
        {
            string tsql = @"
                SELECT
                    id_author
                FROM
                    book
                GROUP BY
                    id_author
                HAVING
                    COUNT(*) > 3
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なSELECT文(HAVING付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectSimpleJoin()
        {
            string tsql = @"
                SELECT
                    book.id,
                    id_book,
                    *
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "単純なJOINで規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "単純なJOINで規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "JOINがあるのにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文でJOINがあるのにテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithWhere()
        {
            string tsql = @"
                SELECT
                    book.id,
                    *
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                WHERE
                    shelf.id = 2 AND
                    id_book = 1
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "WHEREで規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "WHEREで規約違反の発見数を勘違い"
            );

            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "WHEREでJOINがあるのにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文内でJOINがあるのにWHEREでテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithOrder()
        {
            string tsql = @"
                SELECT
                    book.id,
                    *
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                ORDER BY
                    book.name,
                    id_book
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "ORDERで規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "ORDERで規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "ORDERでJOINがあるのにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文内でJOINがあるのにORDERでテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithGroup()
        {
            string tsql = @"
                SELECT
                    MIN(book.count)
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                WHERE
                    shelf.id = 2
                GROUP BY
                    shelf.count,
                    name
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "GROUP BYで規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "GROUP BYで規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "GROUP BYでJOINがあるのにテーブルを宣言してない",
                "name"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文内でJOINがあるのにGROUP BYでテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithAggregateFunction()
        {
            string tsql = @"
                SELECT
                    COUNT(shelf.id_home),
                    COUNT(id_author)
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                WHERE
                    shelf.id = 2
                GROUP BY
                    shelf.count
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "集計関数で規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "集計関数で規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "集計関数でJOINがあるのにテーブルを宣言してない",
                "id_author"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文内でJOINがあるのに集計関数でテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithHaving()
        {
            string tsql = @"
                SELECT
                    MIN(book.count)
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                WHERE
                    shelf.id = 2
                GROUP BY
                    shelf.count
                HAVING
                    COUNT(shelf.id) < 2 AND
                    COUNT(id_author) > 5
                    
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "HAVINGで規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "HAVINGで規約違反の発見数を勘違い"
            );

            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "HAVINGでJOINがあるのにテーブルを宣言してない",
                "id_author"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT文内でJOINがあるのにHAVINGでテーブル名を宣言しない規約の違反で要素が違う"
            );
        }
        
        [Test]
        public void TestSelectJoinWithScalarFunction()
        {
            string tsql = @"
                SELECT
                    book.id_author
                FROM
                    book
                WHERE
                    book.id_authors = dbo.f_getMostLikeAuthorId()
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "スカラ関数の使用で何か規約違反を見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectJoinWithScalarFunctionNotDeclaringSchemaName()
        {
            string tsql = @"
                SELECT
                    book.id_author
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                    LEFT OUTER JOIN home ON shelf.id_home = home.id
                WHERE
                    book.id_authors = f_getMostLikeAuthorId()
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "スカラ関数の使用(スキーマ名無し)で何か規約違反を見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectJoinWithTableValuedFunction()
        {
            string tsql = @"
                SELECT
                    authors.id
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                    LEFT OUTER JOIN dbo.f_getAuthros AS authors ON book.id_author = authors.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル値関数の使用で何か規約違反を見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectJoinWithTableValuedFunctionNotDeclaringSchemaName()
        {
            string tsql = @"
                SELECT
                    authors.id
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                    LEFT OUTER JOIN f_getAuthros AS authors ON book.id_author = authors.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル値関数(スキーマ名無し)の使用で何か規約違反を見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectTableSimple()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            id,
                            *
                        FROM
                            shelf
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "SELECTを使用して得たテーブルをJOINしたら何か規約違反を見つけてしまった"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTable()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            shelf.id,
                            id_shelf,
                            *
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECTを使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECTを使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECTを使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "id_shelf"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECTを使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTableWithWhere()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            shelf.id,
                            *
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                        WHERE
                            shelf.id_home = 2 AND
                            id_country = 1
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(WHERE有り)を使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(WHERE有り)を使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );

            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECT(WHERE有り)を使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "id_country"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT(WHERE有り)を使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTableWithOrder()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT TOP 3
                            shelf.id,
                            *
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                        ORDER BY
                            shelf.id,
                            id_country
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(ORDER有り)を使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(ORDER有り)を使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );

            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECT(ORDER有り)を使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "id_country"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT(ORDER有り)を使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTableWithAggregateFunction()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            COUNT(shelf.id_home),
                            MAX(count_family)
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(集計関数有り)を使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(集計関数有り)を使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECT(集計関数有り)を使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "count_family"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT(集計関数有り)を使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTableWithGroup()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            shelf.id,
                            COUNT(shelf.id_home)
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                        GROUP BY
                            home.id_country,
                            id_home
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(GROUP有り)を使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(GROUP有り)を使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECT(GROUP有り)を使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "id_home"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT(GROUP有り)を使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectFromOtherSelectJoinTableWithHaving()
        {
            string tsql = @"
                SELECT
                    book.id
                FROM
                    book
                    INNER JOIN
                    (
                        SELECT
                            shelf.id
                        FROM
                            shelf
                            INNER JOIN home ON shelf.id_home = home.id
                        HAVING
                            COUNT(shelf.id_home) > 2 AND
                            COUNT(id_country) = 1
                    ) AS a_shelf ON book.id_shelf = a_shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(HAVING有り)を使用して得たテーブルをJOINしたら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "SELECT(HAVING有り)を使用して得たテーブルをJOINしたら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "SELECT(HAVING有り)を使用して得たテーブルをJOINするときにテーブルを宣言してない",
                "id_country"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "SELECT(HAVING有り)を使用して得たテーブルをJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectWithUnion()
        {
            string tsql = @"
                SELECT
                    book.id,
                    shelf.id_shlef
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                UNION ALL
                SELECT
                    id_book,
                    book.id_shelf
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UNIONを行ったら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UNIONを行ったら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "UNIONするときにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "UNIONしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectWithExcept()
        {
            string tsql = @"
                SELECT
                    book.id,
                    shelf.id_shlef
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                EXCEPT
                SELECT
                    id_book,
                    book.id_shelf
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "EXCEPTを行ったら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "EXCEPTを行ったら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "EXCEPTするときにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "EXCEPTしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestSelectWithIntersect()
        {
            string tsql = @"
                SELECT
                    book.id,
                    shelf.id_shlef
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
                INTERSECT
                SELECT
                    id_book,
                    book.id_shelf
                FROM
                    book
                    INNER JOIN shelf ON book.id_shelf = shelf.id
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "INTERSECTを行ったら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "INTERSECTを行ったら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "INTERSECTするときにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "INTERSECTしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestUpdateSimple()
        {
            string tsql = @"
                UPDATE book
                SET
                    id_shelf = 1
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なUPDATE文で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestUpdateSimpleWithWhere()
        {
            string tsql = @"
                UPDATE book
                SET
                    id_shelf = 1
                WHERE
                    id_author = 2
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なUPDATE文(WHERE付き)で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestUpdateFromJoinSimple()
        {
            string tsql = @"
                UPDATE book
                SET
                    id_shelf = shelf.id,
                    id_author = books_id_author
                FROM
                    book
                    INNER JOIN shelf ON shelf.id = book.id_shelf
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UPDATE文でJOINを行ったら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UPDATE文でJOINを行ったら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "UPDATE文でJOINするときにテーブルを宣言してない",
                "books_id_author"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "UPDATE文でJOINしたが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestUpdateFromJoinWithWhere()
        {
            string tsql = @"
                UPDATE book
                SET
                    id_shelf = shelf.id
                FROM
                    book
                    INNER JOIN shelf ON shelf.id = book.id_shelf
                WHERE
                    book.id = 1 AND
                    id_book < 2
            ";
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 1;
            int actual = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UPDATE文でJOIN(WHERE付き)を行ったら規約に抵触する可能性のある数を勘違い"
            );
            
            List<Notification> illegalList = list.GetIllegalList();
            expectedNotificationCount = 1;
            actual = illegalList.Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actual,
                "UPDATE文でJOIN(WHERE付き)を行ったら規約違反の発見数を勘違い"
            );
            
            Notification actualIllegal = illegalList[0];
            Notification expectedIllegal = new Notification(
                NotificationLevel.Illegal,
                IllegalType.NotDeclaredTableName,
                "UPDATE文でJOIN(WHERE付き)するときにテーブルを宣言してない",
                "id_book"
            );

            Assert.AreEqual(
                expectedIllegal,
                actualIllegal,
                "UPDATE文でJOIN(WHERE付き)したが、テーブル名を宣言しなかった時の違反要素が違う"
            );
        }
        
        [Test]
        public void TestInsertSimple()
        {
            string tsql = @"
                INSERT INTO book
                (
                    id_shelf,
                    name
                )
                VALUES
                (
                    1,
                    'Software Systems Architecture'
                )
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なINSERT文で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestDeleteSimple()
        {
            string tsql = @"
                DELETE book
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なDELETE文で何かを見つけてしまった"
            );
        }
        
        [Test]
        public void TestDeleteSimpleWithWhere()
        {
            string tsql = @"
                DELETE book
                WHERE
                    id < 2
            ";
            
            TableNameDeclareCheckVisitor visitor = visitTSql(tsql);
            NotificationList list = visitor.getNotificationList();
            
            int expectedNotificationCount = 0;
            int actualCount = list.GetAll().Count;
            Assert.AreEqual(
                expectedNotificationCount,
                actualCount,
                "テーブル一つの単純なDELETE文(WHERE付き)で何かを見つけてしまった"
            );
        }
        
        private TableNameDeclareCheckVisitor visitTSql(string tsql)
        {
            TSqlParser parser = new TSql100Parser(false);

            IList<ParseError> errors;
            TextReader reader = new StringReader(tsql);

            TSqlFragment parsed = parser.Parse(reader, out errors);

            if (errors.Count != 0)
            {
                string errorMessage = "";
                foreach (ParseError error in errors)
                {
                    errorMessage = errorMessage + "\n" + error.Line + " : " + error.Message;
                }
                throw new Exception("パース失敗\n" + errorMessage);
            }

            TableNameDeclareCheckVisitor visitor = new TableNameDeclareCheckVisitor();
            parsed.Accept(visitor);

            return visitor;
        }
    }

}
