namespace RuleChecker
{
    partial class RuleCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleCheckForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileNameText = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.sqlRadioButton = new System.Windows.Forms.RadioButton();
            this.JSONRadioButton = new System.Windows.Forms.RadioButton();
            this.ruleGroupBox = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ruleGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 452);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.ruleGroupBox);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.checkButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.fileNameText);
            this.tabPage1.Controls.Add(this.inputText);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.outputText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TEXT";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(793, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(793, 168);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 0;
            this.checkButton.Text = "CHECK";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Input";
            // 
            // fileNameText
            // 
            this.fileNameText.Location = new System.Drawing.Point(9, 24);
            this.fileNameText.Name = "fileNameText";
            this.fileNameText.Size = new System.Drawing.Size(778, 19);
            this.fileNameText.TabIndex = 2;
            this.fileNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fileNameText_KeyDown);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(9, 49);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputText.Size = new System.Drawing.Size(859, 106);
            this.inputText.TabIndex = 5;
            this.inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(6, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output";
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(9, 201);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputText.Size = new System.Drawing.Size(860, 215);
            this.outputText.TabIndex = 3;
            this.outputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultText_KeyDown);
            // 
            // sqlRadioButton
            // 
            this.sqlRadioButton.AutoSize = true;
            this.sqlRadioButton.Checked = true;
            this.sqlRadioButton.Location = new System.Drawing.Point(6, 10);
            this.sqlRadioButton.Name = "sqlRadioButton";
            this.sqlRadioButton.Size = new System.Drawing.Size(44, 16);
            this.sqlRadioButton.TabIndex = 9;
            this.sqlRadioButton.TabStop = true;
            this.sqlRadioButton.Text = "SQL";
            this.sqlRadioButton.UseVisualStyleBackColor = true;
            // 
            // JSONRadioButton
            // 
            this.JSONRadioButton.AutoSize = true;
            this.JSONRadioButton.Location = new System.Drawing.Point(56, 10);
            this.JSONRadioButton.Name = "JSONRadioButton";
            this.JSONRadioButton.Size = new System.Drawing.Size(53, 16);
            this.JSONRadioButton.TabIndex = 10;
            this.JSONRadioButton.Text = "JSON";
            this.JSONRadioButton.UseVisualStyleBackColor = true;
            // 
            // ruleGroupBox
            // 
            this.ruleGroupBox.Controls.Add(this.sqlRadioButton);
            this.ruleGroupBox.Controls.Add(this.JSONRadioButton);
            this.ruleGroupBox.Location = new System.Drawing.Point(672, 161);
            this.ruleGroupBox.Name = "ruleGroupBox";
            this.ruleGroupBox.Size = new System.Drawing.Size(115, 32);
            this.ruleGroupBox.TabIndex = 11;
            this.ruleGroupBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TFS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "シェルブとか";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "チェックアウト中のファイルとか\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "チェックインにフックとか";
            // 
            // RuleCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuleCheckForm";
            this.Text = "RuleChecker";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ruleGroupBox.ResumeLayout(false);
            this.ruleGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileNameText;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.RadioButton JSONRadioButton;
        private System.Windows.Forms.RadioButton sqlRadioButton;
        private System.Windows.Forms.GroupBox ruleGroupBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;

    }
}