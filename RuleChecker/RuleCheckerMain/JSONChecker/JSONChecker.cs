using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleChecker.JSONCheck
{
    class JSONChecker : Checker
    {
        public override CheckResult Check(System.IO.TextReader reader)
        {
            JsonTextReader jsonReader = new JsonTextReader(reader);
            try
            {
                while (jsonReader.Read())
                {
                    //全読み込みのために回しているだけ。
                    //具体的なチェックは未実装
                }
            }
            catch (JsonReaderException e)
            {
                throw new JSONCheckException(e.Message, e);
            }
            return new JSONCheckResult();
        }
    }

    class JSONCheckResult : CheckResult
    {
        public override string ToFormattedString()
        {
            string formattedString = "JSONChecker\r\nOK";
            return formattedString;
        }
    }

    public class JSONCheckException : CheckException
    {
        public JSONCheckException(string message)
            : base(message)
        {
            //do nothing
        }


        public JSONCheckException(string message, Exception inner)
            : base(message, inner)
        {
            //do nothing
        }
    }
}
