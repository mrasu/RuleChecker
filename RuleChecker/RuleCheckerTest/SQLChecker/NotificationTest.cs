using NUnit.Framework;
using RuleChecker.SqlCheck;
using System;

namespace SqlCheckerTest
{
    [TestFixture]
    public class NotificationListTest
    {
        public static void Main(String[] args)
        {
            
        }
        [Test]
        public void TestConstructor()
        {
            NotificationList actualList = new NotificationList();
            int expectedListCount = 0;
            Assert.AreEqual(expectedListCount, actualList.GetIllegalList().Count);
        }

        [Test]
        public void TestAddNotification()
        {
            NotificationList notificationList = new NotificationList();

            int expectedIllegalCount = 0;
            Assert.AreEqual(expectedIllegalCount, notificationList.GetIllegalList().Count);

            expectedIllegalCount = 1;
            notificationList.Add(NotificationLevel.Illegal, IllegalType.NotDeclaredTableName, "hello", "hello");
            Assert.AreEqual(expectedIllegalCount, notificationList.GetIllegalList().Count);

            notificationList.Add(NotificationLevel.Warning, IllegalType.NotDeclaredTableName, "hello", "hello");
            Assert.AreEqual(expectedIllegalCount, notificationList.GetIllegalList().Count);
        }
    }
}
