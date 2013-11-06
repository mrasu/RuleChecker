using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleChecker.SqlCheck
{
    ///規約違反のリスト
    public class NotificationList
    {
        private List<Notification> notificationList;

        public NotificationList()
        {
            notificationList = new List<Notification>();
        }

        public void Add(NotificationLevel level, IllegalType type, string message, string statement)
        {
            notificationList.Add(new Notification(level, type, message, statement));
        }
        
        public List<Notification> GetAll()
        {
            return new List<Notification>(notificationList);
        }
        
        public List<Notification> GetIllegalList()
        {
            List<Notification> resultList = new List<Notification>();
            foreach(Notification notification in notificationList)
            {
                if(notification.Level == NotificationLevel.Illegal)
                {
                    resultList.Add(notification);
                }
            }
            
            return resultList;
        }
    }
    
    ///ひとつの規約違反。
    public class Notification
    {
        private NotificationLevel notificationLevel;
        private IllegalType notificationType;
        
        ///人間のためのメッセージ
        private string notificationMessage;
        
        ///機械のためのメッセージ
        private string notificationStatement;

        public Notification(NotificationLevel level, IllegalType type, string message, string statement)
        {
            this.notificationLevel = level;
            this.notificationType = type;
            this.notificationMessage = message;
            this.notificationStatement = statement;
        }

        public NotificationLevel Level
        {
            get
            {
                return notificationLevel;
            }
        }
        
        public IllegalType Type
        {
            get
            {
                return notificationType;
            }
        }
        
        public string Message
        {
            get
            {
                return notificationMessage;
            }
        }
        
        public string Statement
        {
            get
            {
                return notificationStatement;
            }
        }

        public override string ToString()
        {
            string result = "Level : " + this.notificationLevel + 
                                " Type : " + this.notificationType + 
                                " Message : " + this.notificationMessage + 
                                " Statement : " + this.notificationStatement;
            return result;
        }

        /// LevelとTypeとStatementが同じであれば等価
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Notification otherNotification = (Notification)obj;

            if (this.notificationLevel != otherNotification.Level)
            {
                return false;
            }

            if (this.notificationType != otherNotification.Type)
            {
                return false;
            }

            if (this.notificationStatement != otherNotification.Statement)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            hash += this.notificationLevel.GetHashCode();
            hash += this.notificationType.GetHashCode();
            hash += this.notificationStatement.GetHashCode();

            return hash;
        }
    }
    
    ///規約違反の度合
    public enum NotificationLevel
    {
        //違反要素は無し。コメントとして表示する。
        Info,
        //違反ではないが、限りなく違反に近い場合の警告
        Warning,
        //違反
        Illegal
    }
    
    ///どのような規約に違反したかを表す。
    public enum IllegalType
    {
        //テーブル名が宣言されていない
        NotDeclaredTableName
    }
}
