using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Asbt.Data;
using Asbt.Utils;
using FirebirdSql.Data.FirebirdClient;

namespace GenInsSql
{
    public class MsSqlDbClass
    {

        private static string connStrMdb = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=D:\model_1_200499.mdb";
        public static DataTable GetTablesFromMdb()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStrMdb;
            try
            {
               conn.Open();
                DataTable dt = conn.GetSchema("Tables");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public static DataTable GetTablesFromFb()
        {
            FbConnection conn = ConnSingleton.GetDBConnection();
            {
                try
                {
                    DataTable dt = conn.GetSchema("Tables");
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to data source");
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
        }

           public static DataTable SelectFromMdb(string sql)
        {
            OleDbConnection conn = new OleDbConnection();  
            conn.ConnectionString = connStrMdb;
               DataTable result;
            try
            {
                result = new DataTable();
                using (OleDbDataAdapter MyAdapter = new OleDbDataAdapter(sql, connStrMdb))
                    MyAdapter.Fill(result);
            }
            catch (Exception err)
            {
                CLog.Write("DicoDB.GetRefTable(" + sql + ")-> " + err.Message);
                return null;
            }
            return result;
        }



        public static string CreateTable(string TableName, DataTable dt)
        {
            try
            {
               // if (SelectSQL(string.Format("select rdb$relation_name SPTABLE from rdb$relations where rdb$view_blr is null and (rdb$system_flag is null or rdb$system_flag = 0) and rdb$relation_name='{0}'", TableName)).Rows.Count == 0)
                {
                    string _createTable = "CREATE TABLE " + TableName + " (";
                    foreach (DataColumn item in dt.Columns)
                    {
                        _createTable += item.ColumnName;
                        switch (item.DataType.Name)
                        {
                            case "Int64":
                                _createTable += " BIGINT, ";
                                break;
                            case "Int32":
                                _createTable += " INTEGER, ";
                                break;
                            case "Int16":
                                _createTable += " SMALLINT, ";
                                break;
                            case "DateTime":
                                _createTable += " TIMESTAMP, ";
                                break;
                            default:
                                _createTable += " VARCHAR(100), ";
                                break;
                        }
                    }

                    var ss = _createTable.Trim().TrimEnd(',') + ")";
                    return ss+Environment.NewLine;
                }
               // else return "";
            }
            catch (Exception err)
            {
                return "";
            }
        }

        public static string[] InsUpdTable(string inTableName, DataRow inRow)
        {
            string _sql = string.Empty;
            DataTable dt = SelectSQL(string.Format("SELECT * FROM {0} WHERE SP_ID = {1}", inTableName, inRow["SP_ID"].ToStr()));

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SP_SCN"].ToObjInt64() <= inRow["SP_SCN"].ToObjInt64())
                {
                    string _data = string.Empty;
                    foreach (DataColumn item in inRow.Table.Columns)
                    {
                        if (inRow[item].ToStr().IsEmpty())
                            _data += item + " = null,";
                        else
                            _data += item + " = '" + inRow[item].ToStr().Replace("'", "''") + "',";
                    }
                    _data = _data.Trim().TrimEnd(',') + " WHERE SP_ID = " + inRow["SP_ID"].ToStr();
                    _sql = string.Format("UPDATE {0} SET {1}", inTableName, _data);
                    return ExecSQL(_sql);
                }
                else
                    return new string[] { "3", "Янги маълумотлар мавжуд", "" };
            }
            else
            {
                string _fields = "(";
                string _values = "(";
                foreach (DataColumn item in inRow.Table.Columns)
                {
                    _fields += item + ", ";
                    if (inRow[item].ToStr().IsEmpty())
                        _values += "null,";
                    else
                        _values += "'" + inRow[item].ToStr().Replace("'", "''") + "',";

                }
                _fields = _fields.Trim().TrimEnd(',') + ") ";
                _values = _values.Trim().TrimEnd(',') + ") ";
                _sql = string.Format("INSERT INTO {0} {1} VALUES {2}", inTableName, _fields, _values);
                return ExecSQL(_sql);
            }
        }

        public static string InsertTable(string inTableName, string tableNameFb="")
        {

            DataTable dt = SelectFromMdb("SELECT * FROM " + inTableName);
            string _sql = CreateTable(inTableName, dt);

            if (tableNameFb == "")
                tableNameFb = inTableName;

            foreach (DataRow inRow in dt.Rows)
            {
                string _fields = "(";
                string _values = "(";
                foreach (DataColumn item in dt.Columns)
                {
                    _fields += item + ", ";
                    if (inRow[item].ToStr().IsEmpty())
                        _values += "null,";
                    else
                        _values += "'" + inRow[item].ToStr().Replace("'", "''") + "',";

                }
                _fields = _fields.Trim().TrimEnd(',') + ") ";
                _values = _values.Trim().TrimEnd(',') + ") ";
                _sql += string.Format("INSERT INTO {0} {1} VALUES {2}", tableNameFb, _fields, _values) + ";" + Environment.NewLine;

            }
            return _sql;
        }


        public static string[] Merge(string TableName, DataRow dR)
        {
            string _sql = string.Empty;
            string _fields = string.Empty;
            string _values = string.Empty;
            string _valuesIns = string.Empty;

            _sql = "MERGE INTO " + TableName + " c USING (SELECT * FROM " + TableName + " WHERE SP_SCN >= " + dR["SP_SCN"].ToStr() + " AND SP_ID=" + dR["SP_ID"].ToStr() + ") cd" +
                   " ON (c.SP_ID = cd.SP_ID) WHEN MATCHED THEN UPDATE SET ";
            foreach (DataColumn item in dR.Table.Columns)
            {
                _fields += item.ColumnName + ", ";
                if (dR[item].ToStr().IsEmpty())
                    _values = "null";
                else
                    _values = "'" + dR[item].ToStr().Replace("'", "''") + "'";
                _valuesIns += _values + ",";
                _sql += item.ColumnName + "=" + _values + ",";
            }

            _sql = _sql.TrimEnd(',') + " WHEN NOT MATCHED THEN INSERT (" + _fields.Trim().TrimEnd(',') + ") VALUES (" + _valuesIns.Trim().TrimEnd(',') + ")";
            return ExecSQL(_sql);
        }

        public static string[] InsUpdTable(Dictionary<string, string> inParams, string inTableName)
        {
            string _sql = string.Empty;
            //if (SelectSQL(string.Format("select rdb$relation_name SPTABLE from rdb$relations where rdb$view_blr is null and (rdb$system_flag is null or rdb$system_flag = 0) and rdb$relation_name='{0}'", inTableName)).Rows.Count == 0)
            //    return "NOTABLE";

            if (SelectSQL(string.Format("SELECT COUNT(*) CO FROM {0} WHERE SP_ID = {1}", inTableName, inParams["SP_ID"])).Rows[0]["CO"].ToObjInt64() > 0)
            {
                string _data = string.Empty;
                foreach (string item in inParams.Keys)
                {
                    if (item != "SP_DATEENTER")
                        _data += item + " = '" + inParams[item].Replace("'", "''") + "',";
                    else
                        _data += item + " = ('" + Convert.ToDateTime(inParams[item]).ToString("yyyyMMdd") + "'), ";
                }
                _data = _data.TrimEnd(',') + " WHERE SP_ID = " + inParams["SP_ID"];
                _sql = string.Format("UPDATE {0} SET {1}", inTableName, _data);
                return ExecSQL(_sql);
            }
            else
            {
                string _fields = "(";
                string _values = "(";
                foreach (string item in inParams.Keys)
                {
                    _fields += item + ", ";
                    if (item != "SP_DATEENTER")
                        _values += "'" + inParams[item].Replace("'", "''") + "', ";
                    else
                        _values += "('" + Convert.ToDateTime(inParams[item]).ToString("yyyyMMdd") + "'), ";
                }
                _fields = _fields.TrimEnd(',') + ") ";
                _values = _values.TrimEnd(',') + ") ";
                _sql = string.Format("INSERT INTO {0} {1} VALUES {2}", inTableName, _fields, _values);
                return ExecSQL(_sql);
            }
        }


        public static string[] GetTableNames()
        {
            var sql = @"select distinct f.rdb$relation_name
                        from rdb$relation_fields f
                        join rdb$relations r on f.rdb$relation_name = r.rdb$relation_name
                        and r.rdb$view_blr is null 
                        and (r.rdb$system_flag is null or r.rdb$system_flag = 0)
                        and f.rdb$relation_name like 'SA%'";
            List<string> sl = new List<string>();
            DataTable dt = SelectSQL(sql);
            foreach (DataRow row in dt.Rows)
            {
                sl.Add(row[0].ToStr());
            }

            return sl.ToArray();
        }

        public static string[] ExecSQL(String InSQL)
        {
            try
            {
                FbCommand MyCommand = new FbCommand(InSQL, ConnSingleton.GetDBConnection());
                if (MyCommand.ExecuteNonQuery() == 0)
                    return new string[] { "202", "Маълумот ўзгартирилмади", "" };
                else
                    return new string[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("DicoDB.ExecSQL({0}) -> {1}", InSQL, err.GetAllMessages()));
                return new string[] { "2", "Маълумотларни ўзгартиришда ҳато", "" };
            }
        }

        public static DataTable SelectSQL(String InSQL)
        {
            DataTable result = new DataTable();
            try
            {
                var conn = ConnSingleton.GetDBConnection();
                using (FbDataAdapter MyAdapter = new FbDataAdapter(InSQL, conn))
                    MyAdapter.Fill(result);
            }
            catch (Exception err)
            {
                CEventLog.Write("DicoDB.GetRefTable(" + InSQL + ")-> " + err.Message);
                return null;
            }
            return result;
        }
    }
}
