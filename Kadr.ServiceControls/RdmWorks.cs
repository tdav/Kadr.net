using Asbt.ServiceControls;
using Asbt.Utils;
using System;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.Threading;
using FirebirdSql.Data.FirebirdClient;

namespace Asbt.Services
{
    public static class RdmWorks
    {
        private static bool IsRemoteExec = false;

        private static string SpName = "";

        private static int OutputParam = 0;

        public static string connectstring;

        private static FbConnection connection;

     //   private static ConcurrentDictionary<string, DataTable> rdp = new ConcurrentDictionary<string, DataTable>();

        private static void ConnOpen(FbConnection connection)
        {
            //  connection.Disposed += OnConnectionDisposed;
            var retries = 3;

            while (retries >= 0 && connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    retries--;
                    Thread.Sleep(30);
                }
                catch (Exception e)
                {
                    CLog.Write(string.Format("ConnectionNewAndOpen {0} {1}", retries, e.GetAllMessages()));
                }

            }

            if (connection.State != ConnectionState.Open)
            {
                CLog.Write(string.Format("ConnectionNewAndOpen {0} {1}", -1, "Барибир булмади..."));
                throw new FaultException(string.Format("{0}|{1}|", "0", "Сервисда ҳато"));
            }

            //UWSPerformanceCounter.SetTotalConnection(true);
        }

        static void OnConnectionDisposed(object sender, EventArgs e)
        {
            // UWSPerformanceCounter.SetTotalConnection(false); 
        }


        public static T GetProcedure<T>(string[] p_Params, string ProcedureName) where T : class
        {
            T result = null;
            string Ip = wsUtils.GetIP();
            SpName = ProcedureName;
            IsRemoteExec =  SpName.Contains("REMOTESQLEXEC");


            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                using (FbCommand ocmd = FillCommand(new FbCommand(), ProcedureName, p_Params))
                {
                    ocmd.Connection = conn;
                    try
                    {
                        ocmd.ExecuteNonQuery();
                        result = (T)GetValue(typeof(T), ocmd);
                    }
                    catch (Exception err)
                    {
                        CLog.Write(string.Format("GetDataTableProcedure {0} {1} {2}", Ip, ProcedureName, err.GetAllMessages()));
                        throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато", err.GetAllMessages()));
                    }
                }
            }

            return result;
        }



        public static byte[] GetProcedurePBN(string[] p_Params, string ProcedureName)
        {
            string Ip = wsUtils.GetIP();

            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                using (FbCommand ocmd = FillCommand(new FbCommand(), ProcedureName, p_Params))
                {
                    ocmd.Connection = conn;
                    try
                    {
                        ocmd.ExecuteNonQuery();
                        return GetDataTableValuePBN(ocmd);
                    }
                    catch (Exception err)
                    {
                        CLog.Write(string.Format("GetDataTableProcedure {0} {1} {2}", Ip, ProcedureName, err.GetAllMessages()));
                        throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато", err.GetAllMessages()));
                    }
                }
            }
            return null;
        }


        #region Get Value
        private static object GetValue(Type resType, FbCommand c)
        {
            switch (resType.FullName)
            {
                case "System.Data.DataSet":
                    return GetDataSetValue(c);

                case "System.Data.DataTable":
                    return GetDataTableValue(c);

                case "System.String":
                    return GetFirstStringValue(c);

                case "ProtoBuf.Data.ProtoDataStream":
                    return GetDataTableValuePBN(c);

                default:
                    return null;
            }
        }

        private static object GetFirstStringValue(FbCommand c)
        {
            for (int i = 0; i < c.Parameters.Count; i++)
            {
                if (IsOutParam(c.Parameters[i].Direction))
                {
                    switch (c.Parameters[i].FbDbType)
                    {
                        case FbDbType.Date:
                        case FbDbType.Decimal:
                        case FbDbType.Double:
                        case FbDbType.Integer:
                        case FbDbType.BigInt:
                        case FbDbType.VarChar:
                        case FbDbType.Char:
                            return c.Parameters[i].Value.ToString();
                    }
                }
            }
            return string.Empty;
        }

        private static object GetDataTableValue(FbCommand c)
        {
            DataTable result = new DataTable();

            //for (int i = 0; i < c.Parameters.Count; i++)
            //{
            //    if ((IsOutParam(c.Parameters[i].Direction)) && (c.Parameters[i].FbDbType == FbDbType.RefCursor))
            //    {
            //        FbRefCursor rc = c.Parameters[i].Value as FbRefCursor;
            //        if (rc != null)
            //        {
            //            using (FbDataAdapter aa = new FbDataAdapter())
            //            {
            //                try
            //                {
            //                    if (IsRemoteExec)
            //                        rc.FetchSize = rc.RowSize * 15000;
            //                    else
            //                        rc.FetchSize = rc.RowSize * 200;

            //                    aa.Fill(result, rc);
            //                }
            //                catch (Exception err)
            //                {
            //                    CLog.Write("GetRefCursorValue " + err.GetAllMessages());
            //                    throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато", err.GetAllMessages()));
            //                }
            //            }

            //            return result;
            //        }
            //    }
            //}
            return result;
        }

        private static object GetDataSetValue(FbCommand c)
        {
            DataSet result = new DataSet();

            //for (int i = 0; i < c.Parameters.Count; i++)
            //{
            //    if ((IsOutParam(c.Parameters[i].Direction)) && (c.Parameters[i].FbDbType == FbDbType.RefCursor))
            //    {
            //        FbRefCursor rc = c.Parameters[i].Value as FbRefCursor;
            //        if (rc != null)
            //        {
            //            using (FbDataAdapter aa = new FbDataAdapter())
            //            {
            //                DataTable dt = new DataTable();
            //                if (IsRemoteExec)
            //                    rc.FetchSize = rc.RowSize*15000;
            //                else
            //                    rc.FetchSize = rc.RowSize * 200;
                            
            //                aa.Fill(dt, rc);
            //                dt.TableName = c.Parameters[i].ParameterName;
            //                result.Tables.Add(dt);
            //            }

            //        }
            //    }
            //}
            return result;
        }



       

        #endregion

        #region RDM Utils
        private static FbCommand FillCommand(FbCommand oc, string procname, string[] values)
        {
            oc.CommandText = procname;
            oc.CommandType = CommandType.StoredProcedure;

            using (DataTable dt = GetRdpParams(procname))
            {
                if (dt == null)
                {
                    CLog.Write(string.Format("FillCommand dt==null  {0}", procname));
                    throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато FillCommand dt==null"));
                }
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FbParameter p = FillParameter(i, dt, values);
                        if (p != null) oc.Parameters.Add(p);
                    }
                }
                catch (Exception err)
                {
                    CLog.Write(string.Format("FillCommand  {0} {1}", procname, err.GetAllMessages()));
                    throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато", err.GetAllMessages()));
                }
            }

            return oc;
        }

        private static FbParameter FillParameter(int cind, DataTable dt, string[] values)
        {
            FbParameter po = new FbParameter();
            if (string.IsNullOrEmpty(dt.Rows[cind][0].ToString()))
            {
                po.ParameterName = "RETURN_RESULT";
                po.Size = 250;
            }
            else
                po.ParameterName = dt.Rows[cind][0].ToString();

            po.Direction = StrToDirection(dt.Rows[cind][2].ToString(), po.ParameterName);

            string ot = dt.Rows[cind][1].ToString();
            switch (ot)
            {
                case "BLOB": po.FbDbType = FbDbType.Binary;
                    if (IsInParam(po.Direction))
                        if (!string.IsNullOrEmpty(values[cind]))
                            po.Value = System.Text.Encoding.Default.GetBytes(values[cind]);
                        else po.Value = DBNull.Value;
                    break;
                case "CLOB": po.FbDbType = FbDbType.Text;
                    if (IsInParam(po.Direction))
                        if (!string.IsNullOrEmpty(values[cind]))
                            po.Value = values[cind];
                        else
                            po.Value = DBNull.Value;
                    break;
                case "DATE":
                    po.FbDbType = FbDbType.Date;
                    if (IsInParam(po.Direction))
                        if (!string.IsNullOrEmpty(values[cind]))
                            po.Value = values[cind].ToDataTime();
                        else po.Value = DBNull.Value;
                    break;
                case "NUMBER":
                    po.FbDbType = FbDbType.Decimal;
                    if (IsInParam(po.Direction))
                        if (!string.IsNullOrEmpty(values[cind]))
                            po.Value = values[cind].ToDecimal();
                        else po.Value = DBNull.Value;
                    break;
                case "VARCHAR":
                    po.FbDbType = FbDbType.VarChar;
                    if (IsInParam(po.Direction))
                    {
                        if (!string.IsNullOrEmpty(values[cind]))
                            po.Value = values[cind];
                        else
                            po.Value = DBNull.Value;
                    }
                    else
                        po.Size = 200;
                    break;
                
            }
            return po;
        }

        private static ParameterDirection StrToDirection(string vd, string pn)
        {
            bool RR = pn == "RETURN_RESULT";
            ParameterDirection pd = new ParameterDirection();
            if (vd == "IN") pd = ParameterDirection.Input;
            else
                if (vd == "IN/OUT") pd = ParameterDirection.InputOutput;
                else
                    if (vd == "OUT" && !RR) pd = ParameterDirection.Output;
                    else
                        if (vd == "OUT" && RR) pd = ParameterDirection.ReturnValue;
            if (vd != "IN") OutputParam++;
            return pd;
        }

        private static bool IsInParam(ParameterDirection pd)
        {
            return pd == ParameterDirection.Input || pd == ParameterDirection.InputOutput;
        }

        private static bool IsOutParam(ParameterDirection pd)
        {
            return pd != ParameterDirection.Input;
        }

        public static DataTable GetRdpParams(string proname)
        {
            string owner_name = "";
            string object_name = "";
            string package_name = "";

            try
            {
                int index = proname.IndexOf(".");
                owner_name = proname.Substring(0, index);
                proname = proname.Remove(0, index + 1);

                index = proname.IndexOf(".");
                package_name = proname.Substring(0, index);
                object_name = proname.Substring(index + 1);
                return GetSQL(" SELECT /*+ result_cache */ ua.argument_name, ua.data_type , ua.IN_OUT " +
                               " FROM all_arguments ua WHERE ua.owner='" + owner_name + "' and  ua.object_name = '" + object_name + "'" +
                               " AND ua.package_name = '" + package_name + "'" +
                               " ORDER  by ua.position ", true);


            }
            catch (Exception err)
            {
                CLog.Write(string.Format("WSDbWorks.GetRdpParams {0}, {1} ", proname, err.GetAllMessages()));
                return null;
            }

        }

        public static DataTable GetSQL(string sql, bool AddToStatementCache = false)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                try
                {
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.AddToStatementCache = AddToStatementCache;
                        using (FbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            result.Load(dr);
                        }
                    }
                }
                catch (Exception e)
                {
                    CLog.Write(string.Format("WSDbWorks.GetSQL {0} {1}", sql, e.GetAllMessages()));
                }

            }
            return result;
        }

        #endregion

        #region Utils
        public static MemoryStream DoSingleFile(string tb_id)
        {
            byte[] buffer = new byte[1];
            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                try
                {
                    using (FbCommand da = new FbCommand("SELECT GET_FILE(" + tb_id + ") FROM dual", conn))
                    {
                        using (FbDataReader dr = da.ExecuteReader())
                        {
                            if (dr.Read() && dr.GetValue(0) != DBNull.Value)
                            {
                                using (FbBlob ob = dr.GetFbBlob(0))
                                {
                                    if (ob != null)
                                    {
                                        buffer = ob.Value;
                                        MemoryStream ms = new MemoryStream(buffer);
                                        return ms;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return null;
        }

        public static string DoInsertFile(string p_Table, string p_Table_id, string p_Comment, string p_File_name,
                                          string p_User, byte[] p_Image, string p_File_type)
        {
            string result = string.Empty;
            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                using (FbCommand oc = new FbCommand())
                {
                    oc.Connection = conn;
                    oc.CommandText = "PVIZA.FORM_WORKS.INS_FILE";
                    oc.CommandType = CommandType.StoredProcedure;

                    oc.Parameters.Add("p_Table", FbDbType.Varchar2).Value = p_Table;
                    oc.Parameters.Add("p_Table_id", FbDbType.Int32).Value = p_Table_id;
                    oc.Parameters.Add("p_Comment", FbDbType.Varchar2).Value = p_Comment;
                    oc.Parameters.Add("p_File_name", FbDbType.Varchar2).Value = p_File_name;
                    oc.Parameters.Add("p_User", FbDbType.Int32).Value = p_User;
                    oc.Parameters.Add("p_Image", FbDbType.Blob).Value = p_Image;
                    oc.Parameters.Add("p_File_type", FbDbType.Varchar2).Value = p_File_type;
                    oc.Parameters.Add("p_Result", FbDbType.Varchar2).Direction = System.Data.ParameterDirection.Output;
                    oc.Parameters["p_Result"].Size = 200;

                    oc.ExecuteNonQuery();

                    result = oc.Parameters["p_Result"].Value.ToString();
                }
            }
            return result;
        }

        public static string GetTime()
        {
            System.Data.DataTable result = new System.Data.DataTable();
            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                using (FbDataAdapter da = new FbDataAdapter("SELECT SYSDATE SD FROM DUAL", conn))
                {
                    da.Fill(result);
                }
            }
            return ((result.Rows.Count > 0) ? result.Rows[0]["SD"].ToString() : "2");
        }

        public static byte[] GetPhoto(string sql)
        {
            byte[] buffer = new byte[1];
            using (FbConnection conn = new FbConnection(connectstring))
            {
                ConnOpen(conn);
                try
                {
                    using (FbCommand da = new FbCommand(sql, conn))
                    {
                        using (FbDataReader dr = da.ExecuteReader())
                            if (dr.Read() && dr.GetValue(0) != DBNull.Value)
                            {
                                using (FbBlob ob = dr.GetFbBlob(0))
                                    if (ob != null) buffer = ob.Value;
                            }
                    }
                }
                catch (Exception err)
                {
                    CLog.Write(string.Format("GetPhoto  {0} {1}", sql, err.GetAllMessages()));
                    throw new FaultException(string.Format("{0}|{1}|{2}", "0", "Сервисда ҳато", err.GetAllMessages()));
                }
            }
            return buffer;
        }

        #endregion
    }
}