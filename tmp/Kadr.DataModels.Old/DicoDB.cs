using Asbt.Data;
using Asbt.Utils;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Asbt.Global;

namespace Asbt.DictionaryDB
{
    public class DicoDB
    {
        
        public static DataTable dt_SA_HARBIY_UNVON;
        public static DataTable dt_SA_ATESTACIYA_RES;
        public static DataTable dt_SA_ATESTACIYA_YN;
        public static DataTable dt_SA_CITIZEN;
        public static DataTable dt_SA_COUNTRY;
        public static DataTable dt_SA_DOLJNOST;
        public static DataTable dt_SA_LANGS;
        public static DataTable dt_SA_MARRIED;
        public static DataTable dt_SA_NAGRADA;
        public static DataTable dt_SA_NAT;
        
        public static DataTable dt_SA_OBJLANG;
        public static DataTable dt_SA_OBLAST;
        public static DataTable dt_SA_OBRAZOVANIYA;
        public static DataTable dt_SA_PARTIYA;
        public static DataTable dt_SA_PEDAGOG_YN;
        public static DataTable dt_SA_PO_SHATATU;
        public static DataTable dt_SA_PROHODIL_YN;
        public static DataTable dt_SA_RAYON;
        public static DataTable dt_SA_RAYON_All;
        public static DataTable dt_SA_RODSTVENNIK;
        public static DataTable dt_SA_SCSTATUS;
        public static DataTable dt_SA_SEX;
        public static DataTable dt_SA_SPECIALIST_YN;
        public static DataTable dt_SA_SPECIALITY;
        public static DataTable dt_SA_UCHENIY_STEPEN;
        public static DataTable dt_SA_VID_OBUCHENIYA;
        public static DataTable dt_SA_VID_UCHEREJDENI;
        public static DataTable dt_SA_VUZ;
        public static DataTable dt_SA_YESNO;
        public static DataTable dt_SA_RABOTAET_YN;  
        
        public static DataTable dt_SA_KOLLEJ;
        public static DataTable dt_SA_PEDOBRAZOVANIE;
        public static DataTable dt_SA_PEDPEREPOD;
        public static DataTable dt_SA_PREDMET;

        public static DataTable dt_SA_VID_UCHEREJDENI_DIPLO;

        public static void InitSpTablesValue()
        {
            dt_SA_VID_UCHEREJDENI_DIPLO = GetSpTables("SA_VID_UCHEREJDENI_DIPLOM", GlobalVars.Lang);


            dt_SA_PREDMET= GetSpTables("SA_PREDMET", GlobalVars.Lang);
            dt_SA_KOLLEJ = GetSpTables("SA_KOLLEJ", GlobalVars.Lang);
            

            dt_SA_PEDOBRAZOVANIE = GetSpTables("SA_PEDOBRAZOVANIE", GlobalVars.Lang);
            dt_SA_PEDPEREPOD = GetSpTables("SA_PEDPEREPOD", GlobalVars.Lang);
            

            dt_SA_ATESTACIYA_RES = GetSpTables("SA_ATESTACIYA_RES", GlobalVars.Lang);
            dt_SA_ATESTACIYA_YN = GetSpTables("SA_ATESTACIYA_YN", GlobalVars.Lang);
            dt_SA_CITIZEN = GetSpTables("SA_COUNTRY", GlobalVars.Lang);
            dt_SA_COUNTRY = GetSpTables("SA_COUNTRY", GlobalVars.Lang);
            dt_SA_DOLJNOST = GetSpTables("SA_DOLJNOST", GlobalVars.Lang);
            dt_SA_LANGS = GetSpTables("SA_LANGS", GlobalVars.Lang);
            dt_SA_MARRIED = GetSpTables("SA_MARRIED", GlobalVars.Lang);
            dt_SA_NAGRADA = GetSpTables("SA_NAGRADA", GlobalVars.Lang);
            dt_SA_NAT = GetSpTables("SA_NAT", GlobalVars.Lang);
            
            dt_SA_OBJLANG = GetSpTables("SA_OBJLANG", GlobalVars.Lang);
            dt_SA_OBLAST = GetSpTables("SA_OBLAST", GlobalVars.Lang);
            dt_SA_RAYON_All= GetSpTables("SA_RAYON", GlobalVars.Lang);

            dt_SA_OBRAZOVANIYA = GetSpTables("SA_OBRAZOVANIYA", GlobalVars.Lang);
            dt_SA_PARTIYA = GetSpTables("SA_PARTIYA", GlobalVars.Lang);
            dt_SA_PEDAGOG_YN = GetSpTables("SA_PEDAGOG_YN", GlobalVars.Lang);
            dt_SA_PO_SHATATU = GetSpTables("SA_PO_SHATATU", GlobalVars.Lang);
            dt_SA_PROHODIL_YN = GetSpTables("SA_PROHODIL_YN", GlobalVars.Lang);
            dt_SA_RODSTVENNIK = GetSpTables("SA_RODSTVENNIK", GlobalVars.Lang);
            dt_SA_SCSTATUS = GetSpTables("SA_SCSTATUS", GlobalVars.Lang);
            dt_SA_SEX = GetSpTables("SA_SEX", GlobalVars.Lang);
            dt_SA_SPECIALIST_YN = GetSpTables("SA_SPECIALIST_YN", GlobalVars.Lang);
            dt_SA_SPECIALITY = GetSpTables("SA_SPECIALITY", GlobalVars.Lang);
            dt_SA_UCHENIY_STEPEN = GetSpTables("SA_UCHENIY_STEPEN", GlobalVars.Lang);
            dt_SA_VID_OBUCHENIYA = GetSpTables("SA_VID_OBUCHENIYA", GlobalVars.Lang);
            dt_SA_VID_UCHEREJDENI = GetSpTables("SA_VID_UCHEREJDENI", GlobalVars.Lang);
            dt_SA_VUZ = GetSpTables("SA_VUZ", GlobalVars.Lang);
            dt_SA_YESNO = GetSpTables("SA_YESNO", GlobalVars.Lang);
            dt_SA_RABOTAET_YN = GetSpTables("SA_RABOTAET_YN", GlobalVars.Lang);
            dt_SA_HARBIY_UNVON = GetSpTables("SA_HARBIY_UNVON", GlobalVars.Lang);
            


        }

        public static string GetVidUch(string v, string u)
        {
            string val = "";

            if (v == "")
                val = Dec_Dic("", u);
            else
                val = Dec_Dic("", u);

            return val;
        }

        public static object ExecuteScalar(string fieldName, string tableName, string whereVal)
        {
            object result = null;
            try
            {
                string s;
                if (whereVal == "")
                    s = String.Format("SELECT {0} FROM {1}", fieldName, tableName);
                else
                    s = String.Format("SELECT {0} FROM {1} WHERE {2}", fieldName, tableName, whereVal);

                var cmd = new FbCommand(s, ConnSingleton.getDbInstance());
                cmd.Prepare();
                result = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                result = e.Message;
                CLog.Write(e.GetAllMessages());
            }
            return result;
        }

        public static object ExecuteScalar(string sql, string sp)
        {
            object result = null;
            if (sp == "") return "";

            try
            {
                var cmd = new FbCommand(String.Format( sql, sp), ConnSingleton.getDbInstance());
                result = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                result = e.Message;
                CLog.Write(e.GetAllMessages());
            }
            return result;
        }

        public static DataTable SelectSQL(String InSQL)
        {
            var result = new DataTable();
            try
            {
                using (var MyAdapter = new FbDataAdapter(InSQL, ConnSingleton.getDbInstance()))
                {
                    MyAdapter.Fill(result);
                }
            }
            catch (Exception err)
            {
                CLog.Write("DicoDB.GetRefTable(" + InSQL + ")-> " + err.Message);
                return null;
            }

            return result;
        }

        

        public static String CheckDic(Dictionary<string, string> dic, string DicName)
        {
            return (dic.ContainsKey(DicName)) ? (dic[DicName]) : ("");
        }

        public static int ExecSQL(String InSQL)
        {
            var result = 0;
            try
            {
                var MyCommand = new FbCommand(InSQL, ConnSingleton.getDbInstance());
                result = MyCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.ExecSQL({0}) -> {1}", InSQL, err.Message));
            }

            return result;
        }

        public static String FindFIO(String InFIO, String RefName, String _ln)
        {
            var result = "";
            try
            {
                var MyAdapter = new FbDataAdapter("SELECT SP_NAME03 SPNAME FROM " + RefName + " WHERE " +
                                                  " SP_NAME" + _ln + "='" + InFIO.Trim().Replace("'", "''") +
                                                  "' AND SP_ACTIVE=1", ConnSingleton.getDbInstance());
                var resSQL = new DataTable();
                MyAdapter.Fill(resSQL);
                if (resSQL.Rows.Count > 0)
                    result = resSQL.Rows[0]["SPNAME"].ToString();
                else
                    result = "";
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.FindFIO({0},{1},{2}) -> {3}", InFIO, RefName, _ln, err.Message));
                result = "";
            }
            return result;
        }

        public static DataTable Get_Dic(String TableName, String TableLang)
        {
            return SelectSQL("SELECT SP_NAME" + TableLang + " SPNAME FROM " + TableName);
        }

        public static string Dec_Dic(string TableName, string id)
        {
            string result = id.Trim();
            var _ln = GlobalVars.Lang;
            try
            {
                if (id.Trim().Length != 0)
                {
                    result = ExecuteScalar("SELECT NAME" + _ln + " FROM " + TableName + " WHERE ID={0}", id).ToStr();
                }
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.dec_dic "+ err.GetAllMessages()));
            }
            return result;
        }

        public static String RefToLang(String inLn)
        {
            var _outLn = "1";
            try
            {
                _outLn = (Convert.ToInt16(inLn) + 1).ToString();
                return _outLn;
            }
            catch
            {
                return "1";
            }
        }

        public static String GetDateOfBirth(String inDateOfBirth, String inComplitness)
        {
            try
            {
                var outDateOfBirth = Convert.ToDateTime(inDateOfBirth).ToString("dd.MM.yyyy");
                switch (inComplitness)
                {
                    case "1":
                        outDateOfBirth = outDateOfBirth.Replace("01.01.", "XX.XX.");
                        break;
                    case "2":
                        outDateOfBirth = "XX." + outDateOfBirth.Substring(3);
                        break;
                    default:
                        break;
                }
                return outDateOfBirth;
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.GetDateOfBirth({0},{1},{2}) -> {3}", inDateOfBirth, inComplitness,
                    err.Message));
                return "";
            }
        }

        public static String GetDateOfBirthCompleteness(String inDateOfBirth)
        {
            try
            {
                var result = "0";
                if (inDateOfBirth.Contains("XX."))
                {
                    result = "2";
                    if (inDateOfBirth.Contains("XX.XX."))
                        result = "1";
                }
                return result;
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.GetDateOfBirthCompleteness({0}) -> {1}", inDateOfBirth, err.Message));
                return "";
            }
        }

        public static String GetDateFormat(String inDate)
        {
            try
            {
                var outDate = Convert.ToDateTime(inDate.Replace("XX.", "01.")).ToString("dd.MM.yyyy");
                return outDate;
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.GetDateOfBirth({0}) -> {1}", inDate, err.Message));
                return "";
            }
        }

        public static String GetNationRu(String Nation, String Sex)
        {
            try
            {
                if (!Nation.Contains("/")) return Nation;
                if (Sex == "1")
                {
                    return Nation.Substring(0, Nation.IndexOf('/'));
                }
                return Nation.Substring(Nation.IndexOf('/') + 1, Nation.Length - Nation.IndexOf('/') - 1);
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("DicoDB.GetNationRu({0},{1}) -> {2}", Nation, Sex, err.Message));
                return Nation;
            }
        }

        public static int GetDictionaryVersion()
        {
            var maxVersion = 0;
            var curVersion = 0;
            using (var dt_tables = SelectSQL("SELECT SP_TABLE SPTABLE FROM SP_TABLES"))
            {
                foreach (DataRow item in dt_tables.Rows)
                {
                    //if ((item["SPTABLE"].ToString() != "SP_NAME") && (item["SPTABLE"].ToString() != "SP_SURNAME") && (item["SPTABLE"].ToString() != "SP_PATRONYM"))
                    //{
                    try
                    {
                        var vl =
                            ExecuteScalar("SELECT MAX(SP_SCN) MX FROM {0} WHERE SP_SCN < 999999999", item["SPTABLE"].ToStr());
                        if (vl != null)
                            curVersion = Convert.ToInt32(vl);

                        if (curVersion > maxVersion) maxVersion = curVersion;
                    }
                    catch (Exception err)
                    {
                        CLog.Write(err.Message);
                    }
                    //}
                }
            }
            return maxVersion;
        }

        public static string Transliter(string inStr)
        {
            return inStr.Replace('Ѓ', 'Ғ').Replace('Ќ', 'Қ').Replace('Ћ', 'Ҳ');
        }

        public static string InsUpdTable(string inTableName, DataRow inRow)
        {
            var _sql = string.Empty;

            var dt = SelectSQL(string.Format("SELECT * FROM {0} WHERE ID = {1}", 
                inTableName, inRow["ID"].ToStr()));

            if (dt.Rows.Count > 0)
            {
                //if (dt.Rows[0]["SP_SCN"].ToObjInt64() <= inRow["SP_SCN"].ToObjInt64())
                {
                    var _data = string.Empty;
                    foreach (DataColumn item in inRow.Table.Columns)
                    {
                        if (inRow[item].ToStr() == "")
                            _data += item + " = null,";
                        else
                            _data += item + " = '" + inRow[item].ToStr().Replace("'", "''") + "',";
                    }
                    _data = _data.Trim().TrimEnd(',') + " WHERE ID = " + inRow["ID"].ToStr();
                    _sql = string.Format("UPDATE {0} SET {1}", inTableName, _data);
                    return ((ExecSQL(_sql) == 0) ? "NOROWS" : "UPDATED");
                }
                return "NOROWS";
            }
            var _fields = "(";
            var _values = "(";
            foreach (DataColumn item in inRow.Table.Columns)
            {
                _fields += item + ", ";
                if (inRow[item].ToStr() == "")
                    _values += "null,";
                else
                    _values += "'" + inRow[item].ToStr().Replace("'", "''") + "',";
            }
            _fields = _fields.Trim().TrimEnd(',') + ") ";
            _values = _values.Trim().TrimEnd(',') + ") ";
            _sql = string.Format("INSERT INTO {0} {1} VALUES {2}", inTableName, _fields, _values);
            return ((ExecSQL(_sql) == 0) ? "NOROWS" : "INSERTED");
        }

        public static DataTable GetSpTables(string TableName, string ln)
        {
            return SelectSQL(string.Format("SELECT ID, NAME{0} NAME FROM {1}  Order by NAME{0} ", ln, TableName));
        }
        

        public static DataTable GetDicoAll(string TableName, string ln = "")
        {
            if (TableName.Substring(2) == "ST")
                ln = GlobalVars.Lang_T;
            else
                ln = GlobalVars.Lang;

            return
                SelectSQL(string.Format("SELECT SP_ID SPID, SP_NAME{0} SPNAME FROM {1} ORDER BY SPNAME", ln, TableName));
        }

        public static DataTable GetDicoActive(string TableName, string ln)
        {
            return
                SelectSQL(string.Format("SELECT SP_ID SPID, SP_NAME{0} SPNAME FROM {1} WHERE SP_ACTIVE > 0 ORDER BY SPNAME",ln, TableName));
        }

        public static void Batch(string TableName)
        {
            //var sqlText = "Ins....";
            //var fbe = new FbBatchExecution(ConnSingleton.getDbInstance().GetDBConnection());
            ////loop through your commands here
            //{
            //    fbe.SqlStatements.Add(sqlText);
            //}
            //fbe.Execute();
        }

        public static string Get_DocTypeSm(object p)
        {
            int va;
            if (TryConvert.ToInt32(p, out va))
            {
                if (va == 0) return "";
                string v = ExecuteScalar("SELECT COALESCE(SP_NAME3, '')||'='||SP_NAME1 FROM ST_DOCTYPE WHERE SP_ID={0}", va.ToStr()).ToStr();
                string[] sa = v.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (sa.Length == 1)
                    return sa[0];
                else if (sa[0] == "")
                    return sa[1];
                else
                    return sa[0];
            }
            return "";
        }

        public static string DivisionById(string divisionId)
        {
            return ExecuteScalar("SELECT SP_NAME1 FROM st_division  WHERE SP_ID={0}",  divisionId).ToStr();
        }
    }
}