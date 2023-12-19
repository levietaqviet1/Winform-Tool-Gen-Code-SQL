# Winform-Tool-Gen-Code-SQL

## Xuất dữ liệu so sánh từ datatable
```C#
 public void PrintObjectDatatable(DataTable dataTable, string nameProperty)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("#region Assertion\n");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    DataColumn column = dataTable.Columns[j];
                    DataRow row = dataTable.Rows[i];
                    if (row[column].GetType() == typeof(decimal) || row[column].GetType() == typeof(int))
                    {
                        sb.Append($"Assert.AreEqual({nameProperty}.Rows[{i}][\"{column.ColumnName}\"], {row[column]});\n");
                    }
                    else
                    {
                        sb.Append($"Assert.AreEqual({nameProperty}.Rows[{i}][\"{column.ColumnName}\"].ToString(), \"{row[column]}\");\n");
                    }
                }
            }
            sb.Append($"\n");
            sb.Append("#endregion");
            string filePath = "../../iAmViet.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
```

## Xuất dữ liệu so sánh từ object 

```C#
 public void PrintObjectProperties<T>(T obj, string nameProperty)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("#region Assertion\n");
            Type objectType = typeof(T);
            PropertyInfo[] properties = objectType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(obj, null);
                if(propertyValue == null)
                {
                    sb.Append($"Assert.AreEqual({nameProperty + "." + propertyName}, null);\n");
                }
                else if (propertyValue.GetType() == typeof(decimal) || propertyValue.GetType() == typeof(int)) { 
                    sb.Append($"Assert.AreEqual({nameProperty + "." + propertyName}, {propertyValue});\n");
                }else if (propertyValue.GetType() == typeof(string))
                {
                    sb.Append($"Assert.AreEqual({nameProperty + "." + propertyName}, \"{propertyValue}\");\n");
                }
                else if (propertyValue.GetType() == typeof(DateTime))
                {
                    sb.Append($"Assert.AreEqual({nameProperty + "." + propertyName}.ToString(\"yyyy-MM-dd HH:mm:ss\"), \"{ ( (DateTime)propertyValue).ToString("yyyy-MM-dd HH:mm:ss")}\");\n");
                }
                else if (propertyValue is DataTable dataTable)
                {
                    sb.Append($"\n //DataTable {propertyName}\n");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            DataColumn column = dataTable.Columns[j];
                            DataRow row = dataTable.Rows[i];
                            if(row[column].GetType() == typeof(decimal) || row[column].GetType() == typeof(int))
                            {
                                sb.Append($"Assert.AreEqual({nameProperty}.{propertyName}.Rows[{i}][\"{column.ColumnName}\"], {row[column]});\n");
                            }
                            else
                            {
                                sb.Append($"Assert.AreEqual({nameProperty}.{propertyName}.Rows[{i}][\"{column.ColumnName}\"].ToString(), \"{row[column]}\");\n");
                            }
                        }
                    }
                    sb.Append($"\n");
                }
                else
                {
                    sb.Append($"Assert.AreEqual({nameProperty + "." + propertyName}.ToString(), \"{propertyValue}\");\n");
                }
            }
            sb.Append("#endregion");
            string filePath = "../../iAmViet.txt"; 

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    
                    writer.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
```
