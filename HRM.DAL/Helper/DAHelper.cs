using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using System.Data;
using System.Data.SqlClient;
using HRM.DAL.Entity;

namespace HRM.DAL.Helper
{
    public class DAHelper<T> where T : new()
    {
        public static object Insert(List<T> lstObject)
        {
            object identity = null;
            string tableName = string.Empty;
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            string insertStatementTemplate = @"INSERT INTO {0}({1}) VALUES ({2}); select @@identity";
            Type objectType = null;
            foreach (T t in lstObject)
            {
                if (null == objectType)
                {
                    objectType = t.GetType();
                    tableName = objectType.Name.Replace("Entity", string.Empty);

                }
                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    if (propertyInfo.Name.Equals("idenNo") ||
                        propertyInfo.Name.Equals("ID"))
                    {
                        continue;
                    }
                    object value = propertyInfo.GetValue(t, null);

                    if (null == value)/*|| 0 ==Convert.ToInt32( value)*/
                        continue;
                    else
                    {
                        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                        {
                            value = value.ToString().Equals("False") ? 0 : 1;
                        }
                    }
                    if (sbColumns.Length == 0)
                    {
                        sbColumns.Append(propertyInfo.Name);
                        if (value is string)
                            sbValues.Append(string.Format("'{0}'", null != value ? value : string.Empty));
                        else
                            sbValues.Append(value);
                    }
                    else
                    {
                        sbColumns.AppendFormat(",{0}", propertyInfo.Name);
                        if (value is string)
                            sbValues.AppendFormat(",{0}", string.Format("'{0}'", null != value ? value : string.Empty));
                        else
                            sbValues.AppendFormat(",{0}", value);

                    }

                }
                string sqlString = string.Format(insertStatementTemplate, tableName, sbColumns.ToString(), sbValues.ToString());
                identity = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);
                sbColumns.Remove(0, sbColumns.ToString().Length);
                sbValues.Remove(0, sbValues.ToString().Length);
            }



            return identity;
        }


        public static object InsertEmpCode(List<T> lstObject)
        {
            object identity = null;
            string tableName = "EmpCodeTemp";// string.Empty;

            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            string insertStatementTemplate = @"INSERT INTO {0}({1}) VALUES ({2})";// @"INSERT INTO EmpCodeTemp (EmpCode) VALUES ({2})"; //@"INSERT INTO {0}({1}) VALUES ({2}); select @@identity";
            Type objectType = null;
            foreach (T t in lstObject)
            {
                if (null == objectType)
                {
                    objectType = t.GetType();
                    tableName = "EmpCodeTemp";// objectType.Name.Replace("Entity", string.Empty);

                }
                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    //    if (propertyInfo.Name.Equals("idenNo") ||
                    //        propertyInfo.Name.Equals("ID"))
                    //    {
                    //        continue;
                    //    }
                    object value = propertyInfo.GetValue(t, null);

                    //    if (null == value)/*|| 0 ==Convert.ToInt32( value)*/
                    //        continue;
                    //    else
                    //    {
                    //        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                    //        {
                    //            value = value.ToString().Equals("False") ? 0 : 1;
                    //        }
                    //    }
                    //    if (sbColumns.Length == 0)
                    //    {
                    //        sbColumns.Append(propertyInfo.Name);
                    //        if (value is string)
                    //            sbValues.Append(string.Format("'{0}'", null != value ? value : string.Empty));
                    //        else
                    //            sbValues.Append(value);
                    //    }
                    //    else
                    //    {
                    //        sbColumns.AppendFormat(",{0}", propertyInfo.Name);
                    //        if (value is string)
                    //            sbValues.AppendFormat(",{0}", string.Format("'{0}'", null != value ? value : string.Empty));
                    //        else
                    //            sbValues.AppendFormat(",{0}", value);

                    //   }

                    //}
                    if (null == value)/*|| 0 ==Convert.ToInt32( value)*/
                        continue;

                    string colValue = string.Empty;
                    colValue = value.ToString();

                    if (Convert.ToInt32(colValue) == 0)
                        continue;


                    string sqlString = string.Format(insertStatementTemplate, tableName, "EmpCode", colValue);
                    identity = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);
                    sbColumns.Remove(0, sbColumns.ToString().Length);
                    sbValues.Remove(0, sbValues.ToString().Length);
                }
            }



            return identity;
        }
        private static string GetInsertScript(List<object> lstObject)
        {
            string tableName = string.Empty;
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbInsertScript = new StringBuilder();
            string insertStatementTemplate = @"INSERT INTO {0}({1}) VALUES ({2}); ";
            Type objectType = lstObject.First().GetType();

            foreach (object t in lstObject)
            {
                tableName = objectType.Name.Replace("Entity", string.Empty);

                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    if (propertyInfo.Name.Equals("idenNo") ||
                        propertyInfo.Name.Equals("ID"))
                    {
                        continue;
                    }
                    object value = propertyInfo.GetValue(t, null);

                    if (null == value)
                        continue;
                    else
                    {
                        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                        {
                            value = value.ToString().Equals("False") ? 0 : 1;
                        }
                    }
                    if (sbColumns.Length == 0)
                    {
                        sbColumns.Append(propertyInfo.Name);
                        if (value is string)
                            sbValues.Append(string.Format("'{0}'", null != value ? value : string.Empty));
                        else
                            sbValues.Append(value);
                    }
                    else
                    {
                        sbColumns.AppendFormat(",{0}", propertyInfo.Name);
                        if (value is string)
                            sbValues.AppendFormat(",{0}", string.Format("'{0}'", null != value ? value : string.Empty));
                        else
                            sbValues.AppendFormat(",{0}", value);

                    }

                }
                string sqlString = string.Format(insertStatementTemplate, tableName, sbColumns.ToString(), sbValues.ToString());
                sbInsertScript.AppendLine(sqlString);
                sbColumns.Remove(0, sbColumns.ToString().Length);
                sbValues.Remove(0, sbValues.ToString().Length);
            }



            return sbInsertScript.ToString();
        }


        public static object InsertInsideTransaction(Dictionary<int, List<object>> dicInsertable)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.Transaction = trans;
            try
            {
                Type T = null;
                foreach (int key in dicInsertable.Keys)
                {
                    List<object> currentList = dicInsertable[key];
                    T = currentList.First().GetType();
                    string insertStatement = GetInsertScript(currentList);
                    command.CommandType = CommandType.Text;
                    command.CommandText = insertStatement;
                    command.ExecuteNonQuery();
                }
                trans.Commit();
                result = true;
            }
            catch
            {
                trans.Rollback();

            }
            connection.Close();
            return result;
        }

        public static object SaveInsideTransaction(Dictionary<int, List<object>> dicInsertable)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.Transaction = trans;
            try
            {
                Type T = null;
                foreach (int key in dicInsertable.Keys)
                {
                    List<object> currentList = dicInsertable[key];
                    T = currentList.First().GetType();
                    string sqlString = string.Empty;
                    BaseEntity baseType = currentList.First() as BaseEntity;
                    if (baseType.ID > 0)
                        sqlString = GetUpdateScript(currentList);
                    else
                        sqlString = GetInsertScript(currentList);
                    command.CommandType = CommandType.Text;
                    command.CommandText = sqlString;
                    command.ExecuteNonQuery();
                }
                trans.Commit();
                result = true;
            }
            catch
            {
                trans.Rollback();

            }
            connection.Close();
            return result;
        }

        public static string GetFilter(Dictionary<string, object> dicFilterField)
        {
            string filterString = string.Empty;
            StringBuilder sbFilterString = new StringBuilder();
            string filterStringTemplate = " where {0}";
            foreach (string key in dicFilterField.Keys)
            {
                if (sbFilterString.ToString().Length > 0)
                {
                    sbFilterString.Append(" and ");
                    sbFilterString.Append(key);
                    sbFilterString.Append("=");
                    sbFilterString.Append(dicFilterField[key]);
                }
                else
                {

                    sbFilterString.Append(key);
                    sbFilterString.Append("=");
                    sbFilterString.Append(dicFilterField[key]);
                }
            }
            filterString = string.Format(filterStringTemplate, sbFilterString.ToString());
            return filterString;
        }

        public static string GetFilter(Dictionary<string, Dictionary<int, object>> dicFilterField)
        {
            string filterString = string.Empty;
            StringBuilder sbFilterString = new StringBuilder();
            string filterStringTemplate = " {0} = '{1}' ";
            string filterNonStringTemplate = " {0} = {1} ";
            string filterBetweenStringTemplate = " {0} BETWEEN '{1}' AND '{2}' ";
            string filterBetweenNonStringTemplate = " {0} BETWEEN {1} AND {2} ";
            foreach (string key in dicFilterField.Keys)
            {
                Dictionary<int, object> values = dicFilterField[key] as Dictionary<int, object>;

                if (sbFilterString.ToString().Length > 0)
                {
                    sbFilterString.Append(" and ");
                }
                if (values.Count == 1)
                {
                    if (values[1] is string)
                        sbFilterString.Append(string.Format(filterStringTemplate, key, values[1]));
                    else
                        sbFilterString.Append(string.Format(filterNonStringTemplate, key, values[1]));

                }
                else if (values.Count == 2)
                {
                    if (values[1] is string)
                        sbFilterString.Append(string.Format(filterBetweenStringTemplate, key, values[1], values[2]));
                    else
                        sbFilterString.Append(string.Format(filterBetweenNonStringTemplate, key, values[1], values[2]));

                }

            }
            filterString = sbFilterString.ToString();
            return filterString;
        }

        internal static object Update(List<T> lstData)
        {
            Object s = null;
            string updatestring = GetUpdateScript(lstData);

            s = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, updatestring);
            return s;
        }

        private static string GetUpdateScript(List<T> lstObject)
        {
            string tableName = string.Empty;

            StringBuilder sbUpdateStatement = new StringBuilder();

            string updateStatementTemplate = @"UPDATE {0} SET {1} WHERE ID = {2}";
            Type objectType = lstObject.First().GetType();
            object idvalue = null;

            foreach (object t in lstObject)
            {
                StringBuilder sbSetStatement = new StringBuilder();
                tableName = objectType.Name.Replace("Entity", string.Empty);

                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    if (propertyInfo.Name.Equals("ID"))
                    {
                        idvalue = propertyInfo.GetValue(t, null);
                        continue;
                    }
                    object value = propertyInfo.GetValue(t, null);

                    if (null == value)
                        continue;
                    else
                    {
                        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                        {
                            value = value.ToString().Equals("False") ? 0 : 1;
                        }
                    }
                    if (sbSetStatement.Length == 0)
                    {
                        if (value is string)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }
                    else
                    {
                        sbSetStatement.Append(" , ");
                        if (value is string)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }

                }
                sbUpdateStatement.AppendLine(string.Format(updateStatementTemplate, tableName, sbSetStatement.ToString(), idvalue));
            }
            return sbUpdateStatement.ToString();
        }

        internal static object UpdateWithoutID(List<T> lstData, string UpdateField)
        {
            Object s = null;
            string updatestring = GetUpdateScriptWithoutID(lstData, UpdateField);

            s = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, updatestring);
            return s;
        }

        private static string GetUpdateScriptWithoutID(List<T> lstObject, string UpdateField)
        {
            string tableName = string.Empty;

            StringBuilder sbUpdateStatement = new StringBuilder();

            string updateStatementTemplate = @"UPDATE {0} SET {1} WHERE {3} = '{2}'";
            Type objectType = lstObject.First().GetType();
            object idvalue = null;

            foreach (object t in lstObject)
            {
                StringBuilder sbSetStatement = new StringBuilder();
                tableName = objectType.Name.Replace("Entity", string.Empty);

                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    if (propertyInfo.Name.Equals(UpdateField))
                    {
                        idvalue = propertyInfo.GetValue(t, null);
                        continue;
                    }
                    object value = propertyInfo.GetValue(t, null);

                    if (null == value)
                        continue;
                    else
                    {
                        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                        {
                            value = value.ToString().Equals("False") ? 0 : 1;
                        }
                    }
                    if (sbSetStatement.Length == 0)
                    {
                        if (value is string || value is DateTime)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }
                    else
                    {
                        sbSetStatement.Append(" , ");
                        if (value is string || value is DateTime)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }

                }
                sbUpdateStatement.AppendLine(string.Format(updateStatementTemplate, tableName, sbSetStatement.ToString(), idvalue, UpdateField));
            }
            return sbUpdateStatement.ToString();
        }

        private static string GetUpdateScript(List<object> lstObject)
        {
            string tableName = string.Empty;

            StringBuilder sbUpdateStatement = new StringBuilder();

            string updateStatementTemplate = @"UPDATE {0} SET {1} WHERE ID = {2}";
            Type objectType = lstObject.First().GetType();
            object idvalue = null;

            foreach (object t in lstObject)
            {
                StringBuilder sbSetStatement = new StringBuilder();
                tableName = objectType.Name.Replace("Entity", string.Empty);

                PropertyInfo[] lstProperty = t.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in lstProperty)
                {
                    if (propertyInfo.Name.Equals("ID"))
                    {
                        idvalue = propertyInfo.GetValue(t, null);
                        continue;
                    }
                    object value = propertyInfo.GetValue(t, null);

                    if (null == value)
                        continue;
                    else
                    {
                        if (value.ToString().Equals("False") || value.ToString().Equals("True"))
                        {
                            value = value.ToString().Equals("False") ? 0 : 1;
                        }
                    }
                    if (sbSetStatement.Length == 0)
                    {
                        if (value is string)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }
                    else
                    {
                        sbSetStatement.Append(" , ");
                        if (value is string)
                            sbSetStatement.Append(string.Format("{0} = '{1}'", propertyInfo.Name, null != value ? value : string.Empty));
                        else
                            sbSetStatement.Append(string.Format("{0} = {1}", propertyInfo.Name, value));
                    }

                }
                sbUpdateStatement.AppendLine(string.Format(updateStatementTemplate, tableName, sbSetStatement.ToString(), idvalue));
            }
            return sbUpdateStatement.ToString();
        }

        internal static object UpdateTeamLeaderEmpCode(string EmpCode, int ID)
        {
            Object s = null;
            string updatestring = string.Format("Update Team set EmpCode='{0}'  WHERE ID='{1}'", EmpCode, ID);

            s = SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.Text, updatestring);
            return s;
        }

        internal static object UpdateContractMasterStatusID(int StatusId,int ID)
        {
            Object s = null;
            string updatestring = string.Format("Update dbo.vwContractMaster set StatusId={0} WHERE ID={1}",StatusId, ID);

            s = SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.Text, updatestring);
            return s;
        }
    }
}
