using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaidVersionInsert
{
    public partial class Form1 : Form
    {
        private string tableName;
        private string keyCondition;
        private string valueCondition;
        private string dbName;
        private string dicInsertName;
        private CRUD_DataTest crudData;
        private CommonResult result;
        private InFoDatabase inFoDatabase;
        private Utills utills = new Utills();

        public Form1()
        {
            InitializeComponent();
            inFoDatabase = new InFoDatabase();
            CheckConnectSQL();

            crudData = new CRUD_DataTest(inFoDatabase);
        }

        private void CheckConnectSQL()
        {
            List<string> listData = utills.ReadLinesFromFile("Setting.txt");
            inFoDatabase = new InFoDatabase();
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
            if (!(String.IsNullOrEmpty(inFoDatabase.ServerName) || String.IsNullOrEmpty(inFoDatabase.Login) || String.IsNullOrEmpty(inFoDatabase.Password)))
            {
                crudData = new CRUD_DataTest(inFoDatabase);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM sys.databases ");
                CommonResult result = crudData.ExecuteQuery(null, sb);

                if (!result.Status)
                {
                    this.Close();
                    DialogResult rs = new SettingDB(false).ShowDialog();

                    if (rs == DialogResult.OK) // hoặc result là giá trị nút đóng dialog mà bạn xác định
                    {
                        Application.Exit(); // Đóng chương trình
                    }
                }
            }
            else
            {
                this.Close();
                DialogResult rs = new SettingDB(false).ShowDialog();
                if (rs == DialogResult.OK) // hoặc result là giá trị nút đóng dialog mà bạn xác định
                {
                    Application.Exit(); // Đóng chương trình
                }
            }
        }

        private void Validate()
        {
            CheckConnectSQL();
            tableName = cboTableName.Text as string;
            if (tableName != null && tableName.Contains("[") && tableName.Contains("]"))
            {
                tableName = tableName.Substring(1, tableName.Length - 2);
            }
            if(tableName is null)
            {
                tableName = "";
            }

            if (cboKeyCondition.SelectedValue != null)
            {
                keyCondition = cboKeyCondition.SelectedValue.ToString().Trim() ?? "";
            }
            else
            {
                keyCondition = "";
            }
            valueCondition = txtValueCondition.Text.Trim();
            dbName = cboDbName.SelectedValue.ToString().Trim() ?? "";

            txtValueCondition.Text = valueCondition;
        }

        private void btnGrnCode_Click(object sender, EventArgs e)
        {

            Validate();
            dicInsertName = txtNameDictionary.Text;
            string key = "";
            try
            {
                if (cboKeyCondition.SelectedValue != null)
                {
                    key = keyCondition;
                }
            }
            catch (Exception)
            {
            }

            if (cbDefaultName.Checked == true)
            {
                dicInsertName = "dicData" + ConvertToCamelCase(tableName);
            }
            if (String.IsNullOrEmpty(txtNameDictionary.Text.Trim()))
            {
                dicInsertName = "dicDataFake";
            }
            txtNameDictionary.Text = dicInsertName;

            richTextBox.Text = AutoGenInsertDataCode().ToString();
        }

        private string ConvertToCamelCase(string input)
        {
            string[] words = input.ToLower().Trim().Split('_');
            string output = "";

            if (words.Length > 0)
            {
                foreach (string word in words)
                {
                    output += char.ToUpper(word[0]) + word.Substring(1).ToLower();
                }
            }
            else
            {
                output += char.ToUpper(input[0]) + input.Substring(1).ToLower();
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="tableName"> table name </param>
        /// <param name="dbName"> database name </param>
        /// <param name="keyCondition"> Table key which is used to select specific row</param>
        /// <param name="valueCondition"> Value which corressponding to the 'keyCondition' param </param>
        /// <param name="dicInsertName"> Name of param 'dicData' in CRUD_DataTest.Insert function </param>
        /// <returns></returns>
        private StringBuilder AutoGenInsertDataCode()
        {
            Validate();
            var selectCondition = new Dictionary<string, object>();
            StringBuilder output = new StringBuilder();
            selectCondition.Add(keyCondition, valueCondition);
            List<String> outputSelect = null;
            string columnCheck = cboColumnNull.Checked == true ? "NO" : "YES";
            if (cboColumnNull.Checked == true)
            {
                outputSelect = new List<string>();
                StringBuilder query = new StringBuilder();
                query.Append($"USE {cboDbName.SelectedValue.ToString()} SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' " +
                    $"AND IS_NULLABLE = '{columnCheck}';");
                using (SqlConnection cn = new SqlConnection($"Data Source={inFoDatabase.ServerName};User ID={inFoDatabase.Login};Password={inFoDatabase.Password}"))
                {
                    cn.Open();
                    using (SqlCommand command = new SqlCommand(query.ToString(), cn))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string columnName = dr.GetString(0);
                                outputSelect.Add(columnName);
                            }
                        }
                    }
                }
            }
            CommonResult result;
            if (cbValueTop1.Checked)
            {
                result = crudData.Select(null, tableName, dbName, outputSelect, 1);
            }
            else
            {
                result = crudData.Select(selectCondition, tableName, dbName, outputSelect);
            }
            
            if (result.Data.Rows.Count != 0)
            {
                output.Append($"#region {tableName} \n");
                output.Append($"Dictionary<string, object> {dicInsertName} = new Dictionary<string, object>();\n");
                foreach (DataColumn column in result.Data.Columns)
                {
                    List<object> rowData = new List<object>();

                    foreach (DataRow row in result.Data.Rows)
                    {
                        rowData.Add(row[column]);
                    }
                    if (cboDataNull.Checked && rowData[0].GetType().Equals(typeof(DBNull)))
                    {
                        output.Append($"{dicInsertName}.Add(\"{column.ColumnName}\",\"\");  // Data is NULL \n") ;
                        continue;
                    }
                    if (!cboDefautDataEmpty.Checked && rowData[0].ToString().Equals(""))
                    {
                        continue;
                    }
                    if (rowData[0].GetType().Equals(typeof(decimal)))
                    {
                        output.Append($"{dicInsertName}.Add(\"{column.ColumnName}\",{rowData[0]});\n");
                    }
                    if ( rowData[0].GetType().Equals(typeof(string)))
                    {
                        output.Append($"{dicInsertName}.Add(\"{column.ColumnName}\",\"{rowData[0].ToString().Trim()}\");\n");
                    }
                    if ( rowData[0].GetType().Equals(typeof(DateTime)))
                    {
                        output.Append($"{dicInsertName}.Add(\"{column.ColumnName}\",\"{DateTime.Parse(rowData[0].ToString()).ToString("yyyy-MM-dd HH:mm:ss:fff")}\");\n");
                    }
                }
                output.Append($"crudDatatest.Insert(commonData, {dicInsertName} , \"{tableName}\", \"{dbName}\");\n");
                output.Append("#endregion");
            }
            else
            {

                output.Append($"#region {tableName}\n");
                output.Append($"Dictionary<string, object> {dicInsertName} = new Dictionary<string, object>();\n");
                StringBuilder sb = new StringBuilder();
                sb.Append($"SELECT COLUMN_NAME, DATA_TYPE FROM {dbName}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME" +
                    $" = '{tableName}' ");
                if (columnCheck == "NO")
                {
                    sb.Append($" AND IS_NULLABLE = '{columnCheck}';");
                }
                using (SqlConnection cn = new SqlConnection($"Data Source={inFoDatabase.ServerName};User ID={inFoDatabase.Login};Password={inFoDatabase.Password}"))
                {
                    cn.Open();
                    using (SqlCommand command = new SqlCommand(sb.ToString(), cn))
                    {
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string columnName = dr.GetString(0);
                                string dataType = dr.GetString(1);
                                if (dataType.Equals("nvarchar"))
                                {
                                    output.Append($"{dicInsertName}.Add(\"{columnName}\",\"{string.Empty}\");\n");
                                }
                                else if (dataType.Equals("decimal"))
                                {
                                    output.Append($"{dicInsertName}.Add(\"{columnName}\",{0});\n");
                                }
                                else if (dataType.Equals("datetime"))
                                {
                                    output.Append($"{dicInsertName}.Add(\"{columnName}\",\"{DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss:fff")}\");\n");
                                }
                            }
                        }
                    }
                }
                output.Append($"crudDatatest.Insert(commonData, {dicInsertName} , \"{tableName}\", \"{dbName}\");\n");
                output.Append("#endregion\n");

            }
            return output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNameDictionary.Text = "dicDataFake";
            //string[] tbs = new string[] { "R_1_1_0_CM", "R_1_1_0_FI", "R_1_1_0_HR", "R_1_1_0_MN", "R_1_1_0_SC", "SSISDB" };
            cboDbName.DataSource = GetNameDatabase().ToList();
        }

        private List<string> GetNameDatabase()
        {
            List<string> output = new List<string>();
            List<string> select = new List<string>() { "name" };
            StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT name FROM sys.databases where name like 'R%'");
            sb.Append("SELECT name FROM sys.databases");
            CommonResult result = crudData.ExecuteQuery(null, sb);

            result = crudData.Select(null, "sys.databases", null, select);
            for (int i = 0; i < result.Data.Rows.Count; i++)
            {
                output.Add(result.Data.Rows[i]["name"].ToString());
            }
            return output;
        }

        private void reLoadCondition()
        {
            CheckConnectSQL();
            Validate();
            string columnCheck = cboColumnNull.Checked == true ? "NO" : "YES";

            cboKeyCondition.DataSource = null;
            
            #region Get key condition
            Dictionary<string, object> dicCondition = new Dictionary<string, object>();
            dicCondition["TABLE_NAME"] = tableName;

            result = crudData.Select(dicCondition, "INFORMATION_SCHEMA.COLUMNS", dbName, new List<string>() { "COLUMN_NAME" });

            if(result.Data.Rows.Count > 0)
            {
                cboKeyCondition.DataSource = result.Data.AsEnumerable()
                    .Select(row => row.Field<string>("COLUMN_NAME"))
                    .ToList();
            }
            else
            {
                cboKeyCondition.DataSource = null;
            }
            #endregion
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(richTextBox.Text))
            {
                Clipboard.SetText(richTextBox.Text);
                if (cbShowMessCopy.Checked == true)
                {
                    MessageBox.Show("Đã sao chép nội dung vào clipboard!");
                }
            }
        }

        private void btnSettingDatabase_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SettingDB(false).ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = ConvertToCamelCase(txtNameOldParam.Text.ToString().Trim());

            if(text != null && text.Length > 0)
            {
                text = char.ToLower(text[0]) + text.Substring(1);
            }
            string newText = "";
            string rex = "@#$%^&*(){}[]'.!`+/-";
            foreach (var item in text)
            {
                if (!rex.Contains(item))
                {
                    newText += item;
                }
            }
            txtNameNewParam.Text = newText;
        }

        private void cboDbName_TextChanged(object sender, EventArgs e)
        {
            Validate();
            #region Get table name
            result = crudData.Select(null, "INFORMATION_SCHEMA.TABLES", dbName, new List<string>() { "TABLE_NAME" });

            if (result.Data.Rows.Count > 0)
            {
                cboTableName.DataSource = result.Data.AsEnumerable()
                    .Select(row => row.Field<string>("TABLE_NAME"))
                    .ToList();
            }
            else
            {
                cboTableName.DataSource = null;
            }
            #endregion
            reLoadCondition();
        }

        private void cboTableName_TextChanged(object sender, EventArgs e)
        {
            reLoadCondition();
        }

        private void btnCopyNewParam_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNameNewParam.Text))
            {
                Clipboard.SetText(txtNameNewParam.Text);
                if (cbShowMessCopy.Checked == true)
                {
                    MessageBox.Show("Đã sao chép nội dung vào clipboard!");
                }
            }
        }
    }
}
