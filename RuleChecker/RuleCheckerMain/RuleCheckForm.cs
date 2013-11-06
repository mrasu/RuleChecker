using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuleChecker.SqlCheck;
using RuleChecker.JSONCheck;

namespace RuleChecker
{
    public partial class RuleCheckForm : Form
    {
        private IDictionary<CheckType, Checker> checkerDictionary = createCheckerDictionary();

        //選択できるラジオボタンのテキストと同名のCheckTypeを全て含まなくてはならない。
        private enum CheckType
        {
            SQL,
            JSON
        }

        //ラジオボタンから選択できるすべてのCheckTypeはcheckerDictionaryに登録されなくてはならない。
        //物理的な強制を行いたいが思いつかなかった。
        static private IDictionary<CheckType, Checker> createCheckerDictionary()
        {
            IDictionary<CheckType, Checker> checkerDictionary = new Dictionary<CheckType, Checker>();

            checkerDictionary[CheckType.SQL] = new SqlChecker();
            checkerDictionary[CheckType.JSON] = new JSONChecker();
            return checkerDictionary;
        }

        public RuleCheckForm()
        {
            InitializeComponent();
        }

        
        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckRule();
        }

        //ファイル名の入力があればファイルがチェック対象。なければ、テキストボックスがチェック対象。
        private void CheckRule()
        {
            try
            {
                using (TextReader reader = GetReaderFromFormInput())
                {
                    CheckType selectedCheckType = GetSelectedCheckType();
                    Checker checker = checkerDictionary[selectedCheckType];
                    CheckResult resultVisitors = checker.Check(reader);
                    this.outputText.Text = resultVisitors.ToFormattedString();
                }
            }
            catch (CheckException exception)
            {
                this.outputText.Text = exception.Message;
            }
            
        }

        //ファイル名の入力があればファイルのReaderを、無ければテキストボックスを読む。
        private TextReader GetReaderFromFormInput()
        {
            string fileName = fileNameText.Text;

            if (fileName != "" && File.Exists(fileName) == false)
            {
                throw new CheckException("File Not Found");
            }
            if (fileName == "" && this.inputText.Text == "")
            {
                throw new CheckException("No Input");
            }

            TextReader resultReader;
            if (fileName != "")
            {
                resultReader = new StreamReader(fileName);
            }
            else
            {
                resultReader = new StringReader(inputText.Text);
            }
            return resultReader;
        }

        //選択したラジオボタンから使用するCheckTypeを返す
        private CheckType GetSelectedCheckType()
        {
            //選択中のラジオボタンを取得する
            RadioButton checkedButton = this.ruleGroupBox
                .Controls
                .OfType<RadioButton>()
                .Where(button => button.Checked == true)
                .FirstOrDefault();

            //選択中のラジオボタンのテキストをCheckTypeに変換する
            CheckType selectedCheckType = (CheckType)Enum.Parse(
                typeof(CheckType),
                checkedButton.Text
            );

            return selectedCheckType;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select File";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.fileNameText.Text = fileDialog.FileName;
            }
        }

        private void resultText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control == true)
            {
                outputText.SelectAll();
            }
        }

        private void fileNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control == true)
            {
                fileNameText.SelectAll();
            }
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control == true)
            {
                inputText.SelectAll();
            }
        }
    }
}
