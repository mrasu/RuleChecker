using System;
using System.IO;

namespace RuleChecker
{
    public abstract class Checker
    {
        public abstract CheckResult Check(TextReader reader);
    }

    public abstract class CheckResult
    {
        public abstract string ToFormattedString();
    }
    
    public class CheckException : Exception
    {
        public CheckException(string message)
            : base(message)
        {
            //do nothing
        }

        public CheckException(string message, Exception inner)
            : base(message, inner)
        {
            //do nothing
        }
    }
}
