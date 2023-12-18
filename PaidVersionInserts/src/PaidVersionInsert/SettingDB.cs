using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaidVersionInsert
{
    public partial class SettingDB : Form
    {
        private Utills utills = new Utills();
        private InFoDatabase inFoDatabase = new InFoDatabase();
        private CRUD_DataTest cRUD_DataTest;
        private CommonResult result;
        public bool check;
        public SettingDB(bool check = true)
        {
            InitializeComponent();
            this.check = check;
            Load();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            inFoDatabase.ServerName = tbServerName.Text.Trim();
            inFoDatabase.Login = tbLogin.Text.Trim();
            inFoDatabase.Password = tbPassword.Text.Trim();
            if (Validate())
            {
                cRUD_DataTest = new CRUD_DataTest(inFoDatabase);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM sys.databases ");
                result = cRUD_DataTest.ExecuteQuery(null, sb);
                //if (check)
                //{
                if (result.Status)
                {
                    MessageBox.Show("Connect Done");
                    utills.SaveTextToFile(inFoDatabase.ToString(), "Setting.txt");
                    this.Hide();
                    DialogResult result = new Form1().ShowDialog();
                    if (result == DialogResult.OK) // hoặc result là giá trị nút đóng dialog mà bạn xác định
                    {
                        Application.Exit(); // Đóng chương trình
                    }
                }
                else
                {
                    MessageBox.Show("Connect Error");
                }
                //}
                //else
                //{
                //    check = true;
                //}

            }
            else
            {
                MessageBox.Show("Connect Error");
            }
        }

        private void Load()
        {
            List<string> listData = utills.ReadLinesFromFile("Setting.txt");
            try
            {
                if (listData.Count >= 3)
                {
                    inFoDatabase.ServerName = listData[0].Trim();
                    inFoDatabase.Login = listData[1].Trim();
                    inFoDatabase.Password = listData[2].Trim();
                }
            }
            finally
            {
            }
            if (Validate())
            {
                cRUD_DataTest = new CRUD_DataTest(inFoDatabase);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM sys.databases ");
                result = cRUD_DataTest.ExecuteQuery(null, sb);
                if (result.Status)
                {
                    MessageBox.Show("Connect Done");
                    tbServerName.Text = inFoDatabase.ServerName;
                    tbLogin.Text = inFoDatabase.Login;
                    tbPassword.Text = inFoDatabase.Password;
                    if (check)
                    {
                        this.Close();
                        new Form1().ShowDialog();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Connect Error");
                }
            }
            else
            {
                MessageBox.Show("Connect Error");
            }
        }

        private bool Validate()
        {
            if (String.IsNullOrEmpty(inFoDatabase.ServerName) || String.IsNullOrEmpty(inFoDatabase.Login) || String.IsNullOrEmpty(inFoDatabase.Password))
            {
                return false;
            }
            return true;
        }
    }
}
