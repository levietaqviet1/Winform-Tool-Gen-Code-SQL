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
        private List<InFoDatabase> inFoDatabases = new List<InFoDatabase>();
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
            inFoDatabase = new InFoDatabase();
            inFoDatabase.ServerName = cboServerName.Text ?? "";
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

                    inFoDatabase.Choice = true;

                    bool checkChoice = false;

                    inFoDatabases = utills.GetInFoDatabases("Setting.txt");

                    for (int i = 0; i < inFoDatabases.Count; i++)
                    {
                        if (inFoDatabases[i].ServerName.Equals(inFoDatabase.ServerName))
                        {
                            //if (!inFoDatabases[i].Login.Equals(inFoDatabase.Login) || !inFoDatabases[i].Password.Equals(inFoDatabase.Password))
                            //{
                            //    inFoDatabases[i].Login = inFoDatabase.Login;
                            //    inFoDatabases[i].Password = inFoDatabase.Password;
                            //}

                            inFoDatabases[i].Choice = true;
                            checkChoice = true;
                        }
                        else
                        {
                            inFoDatabases[i].Choice = false;
                        }
                    }

                    if (!checkChoice)
                    {
                        inFoDatabases.Add(inFoDatabase);
                    }

                    inFoDatabases = inFoDatabases.OrderByDescending(x => x.Choice).ToList();

                    string str = "";
                    foreach (var item in inFoDatabases)
                    {
                        str += item.ToString();
                    }
                    utills.SaveTextToFile(str, "Setting.txt");
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
            inFoDatabases = utills.GetInFoDatabases("Setting.txt");
            cboServerName.DataSource = inFoDatabases;
            cboServerName.DisplayMember = "ServerName";

            tbLogin.DataBindings.Clear();
            tbLogin.DataBindings.Add("Text", inFoDatabases, "Login");

            tbPassword.DataBindings.Clear();
            tbPassword.DataBindings.Add("Text", inFoDatabases, "Password");

            for (int i = 0; i < inFoDatabases.Count; i++)
            {
                if (inFoDatabases[i].Choice)
                {
                    cboServerName.SelectedIndex = i;
                    inFoDatabase = inFoDatabases.ToList()[i];
                    break;
                }
            }
            //List<string> listData = utills.ReadLinesFromFile("Setting.txt");
            //try
            //{
            //    if (listData.Count >= 3)
            //    {
            //        inFoDatabase.ServerName = listData[0].Trim();
            //        inFoDatabase.Login = listData[1].Trim();
            //        inFoDatabase.Password = listData[2].Trim();
            //    }
            //}
            //finally
            //{
            //}
            if (Validate())
            {
                cRUD_DataTest = new CRUD_DataTest(inFoDatabase);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM sys.databases ");
                result = cRUD_DataTest.ExecuteQuery(null, sb);
                if (result.Status)
                {
                    MessageBox.Show("Connect Done");
                    //tbServerName.Text = inFoDatabase.ServerName;
                    //tbLogin.Text = inFoDatabase.Login;
                    //tbPassword.Text = inFoDatabase.Password;
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
