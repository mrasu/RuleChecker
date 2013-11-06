using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using RuleChecker.JSONCheck;

namespace RuleChecker
{
    class program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new RuleCheckForm());
        }
    }
}
