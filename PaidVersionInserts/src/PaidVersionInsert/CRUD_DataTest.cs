using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaidVersionInsert
{
    class CRUD_DataTest
    {
        private string DBServer;
        private string UserServer;
        private string PassServer;

        public CRUD_DataTest(InFoDatabase inFoDatabase)
        {
            DBServer = inFoDatabase.ServerName;
            UserServer = inFoDatabase.Login;
            PassServer = inFoDatabase.Password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="dicData"></param>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        //public CommonResult Insert( Dictionary<string, object> dicData, string tableName, string dbName)
        //{
        //    CommonResult commonResult = ValidateData(dicData, new Dictionary<string, object>(), "INSERT", tableName, dbName);
        //    if (!commonResult.Status)
        //    {
        //        return commonResult;
        //    }
        //    SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
        //    cn.Open();
        //    SqlTransaction tr = cn.BeginTransaction();
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE " + dbName);
        //    try
        //    {
        //        sb.Append(" INSERT INTO " + tableName);
        //        sb.Append(" (   ");
        //        // Bind column into Insert query
        //        foreach (var data in dicData)
        //        {
        //            sb.Append("   " + data.Key + ',');
        //        }
        //        sb.Length--; // remove last charactor (,)
        //        sb.Append(" ) VALUES ( ");
        //        // Bind data into Insert query
        //        foreach (var data in dicData)
        //        {
        //            if (data.Value.GetType().Name == "String")
        //            {
        //                sb.Append("   N'");
        //                sb.Append(data.Value);
        //                sb.Append("',");
        //            }
        //            else
        //            {
        //                sb.Append("   " + data.Value);
        //                sb.Append(",");
        //            }
        //        }
        //        sb.Length--; // remove last charactor (,)
        //        sb.Append(" )");
        //        SqlCommand cm = new SqlCommand(sb.ToString(), cn, tr);
        //        DBTimeout.setTimeout(cm, commonData);
        //        cm.ExecuteNonQuery();
        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        commonResult.Status = false;
        //        commonResult.StringQuery = sb.ToString();
        //        commonResult.Messsage = ex.ToString();
        //    }
        //    finally
        //    {
        //        tr.Dispose();
        //        cn.Close();
        //    }
        //    return commonResult;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="dicCondition"></param>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public CommonResult Select(Dictionary<string, object> dicCondition, string tableName, string dbName, List<String> output = null)
        {
            CommonResult commonResult = new CommonResult();
            try
            {
                SqlConnection cn = new SqlConnection($"Data Source={DBServer};User ID={UserServer};Password={PassServer};Connection Timeout=5;");
                cn.Open();
                DataTable dt = new DataTable();
                StringBuilder sb = new StringBuilder();
                if (dbName != null)
                {
                    sb.Append("USE " + dbName);
                }
                try
                {
                    sb.Append($" SELECT ");
                    if (output != null && output.Count > 0)
                    {

                        for (int i = 0; i < output.Count; i++)
                        {
                            sb.Append($" {output[i]},");
                        }
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else
                    {
                        sb.Append($" * ");
                    }
                    sb.Append($" FROM {tableName}");
                    // Add WHERE Clause
                    if (dicCondition != null && dicCondition.Count > 0)
                    {
                        sb.Append(" WHERE ");
                        foreach (var condition in dicCondition)
                        {
                            if (condition.Value.GetType().Name == "String")
                            {
                                sb.Append("   " + condition.Key + " = N'" + condition.Value + "'   AND");
                            }
                            else
                            {
                                sb.Append("   " + condition.Key + " = " + condition.Value + "   AND");
                            }
                        }
                        sb.Remove(sb.Length - 3, 3);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), cn);
                    da.Fill(dt);
                    commonResult.Data = dt;
                }
                catch (Exception ex)
                {
                    commonResult.Status = false;
                    commonResult.StringQuery = sb.ToString();
                    commonResult.Messsage = ex.ToString();
                }
                finally
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                commonResult.Status = false;
                commonResult.Messsage = ex.ToString();
            }
            return commonResult;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="dbName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public CommonResult ExecuteQuery(string dbName, StringBuilder query, SqlParameterCollection sqlParameterCollection = null)
        {
            CommonResult commonResult = new CommonResult();
            using (SqlConnection cn = new SqlConnection($"Data Source={DBServer};User ID={UserServer};Password={PassServer};Connection Timeout=5"))
            {
                try
                {
                    cn.Open();
                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        StringBuilder sb = new StringBuilder();
                        if (dbName != null)
                        {
                            sb.Append("USE " + dbName);
                        }
                        try
                        {
                            sb.Append($" {query.ToString()}");
                            using (SqlCommand cm = new SqlCommand(sb.ToString(), cn, tx))
                            {
                                if (sqlParameterCollection != null)
                                {
                                    SqlParameterCollection parameters = cm.Parameters;
                                    foreach (SqlParameter parameter in sqlParameterCollection)
                                    {
                                        SqlParameter newParameter = new SqlParameter(parameter.ParameterName, parameter.Value);
                                        newParameter.SqlDbType = parameter.SqlDbType;
                                        newParameter.Size = parameter.Size;
                                        newParameter.Direction = parameter.Direction;
                                        newParameter.Precision = parameter.Precision;
                                        newParameter.Scale = parameter.Scale;
                                        newParameter.IsNullable = parameter.IsNullable;
                                        newParameter.SourceColumn = parameter.SourceColumn;
                                        newParameter.SourceVersion = parameter.SourceVersion;
                                        parameters.Add(newParameter);
                                    }
                                }
                                cm.ExecuteNonQuery();
                            }
                            tx.Commit();
                        }
                        catch (Exception ex)
                        {
                            commonResult.Status = false;
                            commonResult.StringQuery = sb.ToString();
                            commonResult.Messsage = ex.ToString();
                        }
                        finally
                        {
                            cn.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    commonResult.Status = false;
                }
                
            }
            return commonResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="dicData"></param>
        /// <param name="dicCondition"></param>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        //public CommonResult Update(CommonData commonData, Dictionary<string, object> dicData, Dictionary<string, object> dicCondition, string tableName, string dbName)
        //{
        //    CommonResult commonResult = ValidateData(dicData, dicCondition, "UPDATE", tableName, dbName);
        //    if (!commonResult.Status)
        //    {
        //        return commonResult;
        //    }
        //    SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
        //    cn.Open();
        //    SqlTransaction tr = cn.BeginTransaction();
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE " + dbName);
        //    try
        //    {
        //        sb.Append(" UPDATE " + tableName);
        //        sb.Append(" SET ");
        //        foreach (var data in dicData)
        //        {
        //            if (data.Value.GetType().Name == "String" && data.Value.ToString().ToUpper() != "NULL")
        //            {
        //                sb.Append("   " + data.Key + " = N'" + data.Value + "',");
        //            }
        //            else
        //            {
        //                sb.Append("   " + data.Key + " = " + data.Value + ",");
        //            }
        //        }
        //        sb.Length--;
        //        // WHERE condition
        //        if (dicCondition.Count > 0)
        //        {
        //            sb.Append("   WHERE   ");
        //            foreach (var condition in dicCondition)
        //            {
        //                if (condition.Value.GetType().Name == "String" && condition.Value.ToString().ToUpper() != "NULL")
        //                {
        //                    sb.Append("   " + condition.Key + " = N'" + condition.Value + "'   AND");
        //                }
        //                else
        //                {
        //                    sb.Append("   " + condition.Key + " = " + condition.Value + "   AND");
        //                }
        //            }
        //            sb.Remove(sb.Length - 3, 3);
        //        }
        //        SqlCommand cm = new SqlCommand(sb.ToString(), cn, tr);
        //        DBTimeout.setTimeout(cm, commonData);
        //        cm.ExecuteNonQuery();
        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        commonResult.Status = false;
        //        commonResult.StringQuery = sb.ToString();
        //        commonResult.Messsage = ex.ToString();
        //    }
        //    finally
        //    {
        //        tr.Dispose();
        //        cn.Close();
        //    }
        //    return commonResult;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="dicCondition"></param>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        //public CommonResult Delete(CommonData commonData, Dictionary<string, object> dicCondition, string tableName, string dbName)
        //{
        //    CommonResult commonResult = ValidateData(new Dictionary<string, object>(), dicCondition, "DELETE", tableName, dbName);
        //    if (!commonResult.Status)
        //    {
        //        return commonResult;
        //    }
        //    SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
        //    cn.Open();
        //    SqlTransaction tr = cn.BeginTransaction();
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE " + dbName);
        //    try
        //    {
        //        sb.Append(" DELETE FROM " + tableName);
        //        sb.Append(" WHERE ");
        //        // WHERE condition
        //        foreach (var condition in dicCondition)
        //        {
        //            if (condition.Value.GetType().Name == "String" && condition.Value.ToString().ToUpper() != "NULL")
        //            {
        //                sb.Append("   " + condition.Key + " = N'" + condition.Value + "'   AND");
        //            }
        //            else
        //            {
        //                sb.Append("   " + condition.Key + " = " + condition.Value + "   AND");
        //            }
        //        }
        //        sb.Remove(sb.Length - 3, 3);
        //        SqlCommand cm = new SqlCommand(sb.ToString(), cn, tr);
        //        DBTimeout.setTimeout(cm, commonData);
        //        cm.ExecuteNonQuery();
        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        commonResult.Status = false;
        //        commonResult.StringQuery = sb.ToString();
        //        commonResult.Messsage = ex.ToString();
        //    }
        //    finally
        //    {
        //        tr.Dispose();
        //        cn.Close();
        //    }
        //    return commonResult;
        //}
        public CommonResult ValidateData(Dictionary<string, object> dicData, Dictionary<string, object> dicCondition, string action, string tblName, string dbName)
        {
            CommonResult commonResult = new CommonResult();
            if (String.IsNullOrEmpty(tblName) || String.IsNullOrEmpty(dbName))
            {
                commonResult.Status = false;
                commonResult.Messsage = "Param: TableName, DBName is null or blank";
            }
            if (action.Equals("INSERT") && dicData.Count <= 0)
            {
                commonResult.Status = false;
                commonResult.Messsage = "Validate fail data.";
            }
            else if ((action.Equals("UPDATE") || action.Equals("DELETE")) && dicCondition.Count < 1)
            {
                commonResult.Status = false;
                commonResult.Messsage = "Update or Delete requires a condition for the where clause.";
            }
            return commonResult;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CommonResult
    {
        public CommonResult()
        {
            Status = true;
            Messsage = "Success";
            StringQuery = "";
            Data = new DataTable();
        }
        public bool Status { get; set; }
        public string StringQuery { get; set; }
        public string Messsage { get; set; }
        public DataTable Data { get; set; }
    }
}

