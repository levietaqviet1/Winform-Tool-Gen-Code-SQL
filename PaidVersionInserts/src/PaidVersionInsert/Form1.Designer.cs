
namespace PaidVersionInsert
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValueCondition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameDictionary = new System.Windows.Forms.TextBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.btnGrnCode = new System.Windows.Forms.Button();
            this.cboDbName = new System.Windows.Forms.ComboBox();
            this.cboColumnNull = new System.Windows.Forms.CheckBox();
            this.cboKeyCondition = new System.Windows.Forms.ComboBox();
            this.cbDefaultName = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbShowMessCopy = new System.Windows.Forms.CheckBox();
            this.btnSettingDatabase = new System.Windows.Forms.Button();
            this.cboDefautDataEmpty = new System.Windows.Forms.CheckBox();
            this.cboDataNull = new System.Windows.Forms.CheckBox();
            this.cbValueTop1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNameOldParam = new System.Windows.Forms.TextBox();
            this.txtNameNewParam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTableName = new System.Windows.Forms.ComboBox();
            this.btnCopyNewParam = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTypeTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "DB Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Condition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value Condition";
            // 
            // txtValueCondition
            // 
            this.txtValueCondition.Location = new System.Drawing.Point(116, 242);
            this.txtValueCondition.Name = "txtValueCondition";
            this.txtValueCondition.Size = new System.Drawing.Size(199, 19);
            this.txtValueCondition.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name Dictionary";
            // 
            // txtNameDictionary
            // 
            this.txtNameDictionary.Location = new System.Drawing.Point(116, 279);
            this.txtNameDictionary.Name = "txtNameDictionary";
            this.txtNameDictionary.Size = new System.Drawing.Size(199, 19);
            this.txtNameDictionary.TabIndex = 8;
            // 
            // richTextBox
            // 
            this.richTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox.Location = new System.Drawing.Point(345, 136);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(584, 259);
            this.richTextBox.TabIndex = 10;
            this.richTextBox.Text = "";
            // 
            // btnGrnCode
            // 
            this.btnGrnCode.Location = new System.Drawing.Point(12, 401);
            this.btnGrnCode.Name = "btnGrnCode";
            this.btnGrnCode.Size = new System.Drawing.Size(75, 23);
            this.btnGrnCode.TabIndex = 11;
            this.btnGrnCode.Text = "Gen code";
            this.btnGrnCode.UseVisualStyleBackColor = true;
            this.btnGrnCode.Click += new System.EventHandler(this.btnGrnCode_Click);
            // 
            // cboDbName
            // 
            this.cboDbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDbName.FormattingEnabled = true;
            this.cboDbName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboDbName.IntegralHeight = false;
            this.cboDbName.Location = new System.Drawing.Point(116, 139);
            this.cboDbName.Name = "cboDbName";
            this.cboDbName.Size = new System.Drawing.Size(121, 20);
            this.cboDbName.TabIndex = 19;
            this.cboDbName.TextChanged += new System.EventHandler(this.cboDbName_TextChanged);
            // 
            // cboColumnNull
            // 
            this.cboColumnNull.AutoSize = true;
            this.cboColumnNull.Location = new System.Drawing.Point(12, 315);
            this.cboColumnNull.Name = "cboColumnNull";
            this.cboColumnNull.Size = new System.Drawing.Size(104, 16);
            this.cboColumnNull.TabIndex = 20;
            this.cboColumnNull.Text = "Column not null";
            this.cboColumnNull.UseVisualStyleBackColor = true;
            // 
            // cboKeyCondition
            // 
            this.cboKeyCondition.FormattingEnabled = true;
            this.cboKeyCondition.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboKeyCondition.IntegralHeight = false;
            this.cboKeyCondition.Location = new System.Drawing.Point(116, 209);
            this.cboKeyCondition.Name = "cboKeyCondition";
            this.cboKeyCondition.Size = new System.Drawing.Size(199, 20);
            this.cboKeyCondition.TabIndex = 21;
            // 
            // cbDefaultName
            // 
            this.cbDefaultName.AutoSize = true;
            this.cbDefaultName.Location = new System.Drawing.Point(150, 315);
            this.cbDefaultName.Name = "cbDefaultName";
            this.cbDefaultName.Size = new System.Drawing.Size(150, 16);
            this.cbDefaultName.TabIndex = 22;
            this.cbDefaultName.Text = "Default Name Dictionary";
            this.cbDefaultName.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(854, 415);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 23;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbShowMessCopy
            // 
            this.cbShowMessCopy.AutoSize = true;
            this.cbShowMessCopy.Location = new System.Drawing.Point(712, 419);
            this.cbShowMessCopy.Name = "cbShowMessCopy";
            this.cbShowMessCopy.Size = new System.Drawing.Size(112, 16);
            this.cbShowMessCopy.TabIndex = 24;
            this.cbShowMessCopy.Text = "Show Mess Copy";
            this.cbShowMessCopy.UseVisualStyleBackColor = true;
            // 
            // btnSettingDatabase
            // 
            this.btnSettingDatabase.Location = new System.Drawing.Point(788, 15);
            this.btnSettingDatabase.Name = "btnSettingDatabase";
            this.btnSettingDatabase.Size = new System.Drawing.Size(103, 34);
            this.btnSettingDatabase.TabIndex = 25;
            this.btnSettingDatabase.Text = "Setting Database";
            this.btnSettingDatabase.UseVisualStyleBackColor = true;
            this.btnSettingDatabase.Click += new System.EventHandler(this.btnSettingDatabase_Click);
            // 
            // cboDefautDataEmpty
            // 
            this.cboDefautDataEmpty.AutoSize = true;
            this.cboDefautDataEmpty.Location = new System.Drawing.Point(150, 341);
            this.cboDefautDataEmpty.Name = "cboDefautDataEmpty";
            this.cboDefautDataEmpty.Size = new System.Drawing.Size(122, 16);
            this.cboDefautDataEmpty.TabIndex = 26;
            this.cboDefautDataEmpty.Text = "Output Data Empty";
            this.cboDefautDataEmpty.UseVisualStyleBackColor = true;
            // 
            // cboDataNull
            // 
            this.cboDataNull.AutoSize = true;
            this.cboDataNull.Location = new System.Drawing.Point(12, 341);
            this.cboDataNull.Name = "cboDataNull";
            this.cboDataNull.Size = new System.Drawing.Size(108, 16);
            this.cboDataNull.TabIndex = 27;
            this.cboDataNull.Text = "Output Data null";
            this.cboDataNull.UseVisualStyleBackColor = true;
            // 
            // cbValueTop1
            // 
            this.cbValueTop1.AutoSize = true;
            this.cbValueTop1.Location = new System.Drawing.Point(150, 372);
            this.cbValueTop1.Name = "cbValueTop1";
            this.cbValueTop1.Size = new System.Drawing.Size(119, 16);
            this.cbValueTop1.TabIndex = 28;
            this.cbValueTop1.Text = "Defaut value top 1";
            this.cbValueTop1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "Convert name method";
            // 
            // txtNameOldParam
            // 
            this.txtNameOldParam.Location = new System.Drawing.Point(163, 18);
            this.txtNameOldParam.Name = "txtNameOldParam";
            this.txtNameOldParam.Size = new System.Drawing.Size(100, 19);
            this.txtNameOldParam.TabIndex = 30;
            this.txtNameOldParam.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNameNewParam
            // 
            this.txtNameNewParam.Location = new System.Drawing.Point(298, 17);
            this.txtNameNewParam.Name = "txtNameNewParam";
            this.txtNameNewParam.Size = new System.Drawing.Size(100, 19);
            this.txtNameNewParam.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "-->";
            // 
            // cboTableName
            // 
            this.cboTableName.FormattingEnabled = true;
            this.cboTableName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboTableName.IntegralHeight = false;
            this.cboTableName.Location = new System.Drawing.Point(116, 174);
            this.cboTableName.Name = "cboTableName";
            this.cboTableName.Size = new System.Drawing.Size(199, 20);
            this.cboTableName.TabIndex = 33;
            this.cboTableName.TextChanged += new System.EventHandler(this.cboTableName_TextChanged);
            // 
            // btnCopyNewParam
            // 
            this.btnCopyNewParam.Location = new System.Drawing.Point(413, 14);
            this.btnCopyNewParam.Name = "btnCopyNewParam";
            this.btnCopyNewParam.Size = new System.Drawing.Size(75, 23);
            this.btnCopyNewParam.TabIndex = 34;
            this.btnCopyNewParam.Text = "Copy";
            this.btnCopyNewParam.UseVisualStyleBackColor = true;
            this.btnCopyNewParam.Click += new System.EventHandler(this.btnCopyNewParam_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "Type: ";
            // 
            // lbTypeTable
            // 
            this.lbTypeTable.AutoSize = true;
            this.lbTypeTable.Location = new System.Drawing.Point(376, 112);
            this.lbTypeTable.Name = "lbTypeTable";
            this.lbTypeTable.Size = new System.Drawing.Size(33, 12);
            this.lbTypeTable.TabIndex = 36;
            this.lbTypeTable.Text = "Table";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 467);
            this.Controls.Add(this.lbTypeTable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCopyNewParam);
            this.Controls.Add(this.cboTableName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNameNewParam);
            this.Controls.Add(this.txtNameOldParam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbValueTop1);
            this.Controls.Add(this.cboDataNull);
            this.Controls.Add(this.cboDefautDataEmpty);
            this.Controls.Add(this.btnSettingDatabase);
            this.Controls.Add(this.cbShowMessCopy);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cbDefaultName);
            this.Controls.Add(this.cboKeyCondition);
            this.Controls.Add(this.cboColumnNull);
            this.Controls.Add(this.cboDbName);
            this.Controls.Add(this.btnGrnCode);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNameDictionary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValueCondition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValueCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameDictionary;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button btnGrnCode;
        private System.Windows.Forms.ComboBox cboDbName;
        private System.Windows.Forms.CheckBox cboColumnNull;
        private System.Windows.Forms.ComboBox cboKeyCondition;
        private System.Windows.Forms.CheckBox cbDefaultName;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox cbShowMessCopy;
        private System.Windows.Forms.Button btnSettingDatabase;
        private System.Windows.Forms.CheckBox cboDefautDataEmpty;
        private System.Windows.Forms.CheckBox cboDataNull;
        private System.Windows.Forms.CheckBox cbValueTop1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNameOldParam;
        private System.Windows.Forms.TextBox txtNameNewParam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTableName;
        private System.Windows.Forms.Button btnCopyNewParam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTypeTable;
    }
}

