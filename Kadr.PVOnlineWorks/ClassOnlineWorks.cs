using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Kadr.MessageManager;
using Kadr.PVOnlineWorks.srUni;
using Kadr.Utils;
using Kadr.Utils.DataBase;

namespace Kadr.Global
{
    public static class ClassOnlineWorks
    {
        private static bool IsBus;

        public static string[] CheckUser(string user, string parol)
        {
            /*
            IwcServiceClient CurClient = new IwcServiceClient(GlobalVars.CurEndpoint);
            try
            {   
                byte[] Cert = Convert.FromBase64String(UserCert);
                byte[] data = CurClient.CheckLogin(inCurValue, inSignedCurValue, Cert, "3");
                if (data == null)
                {
                    File.Delete(GlobalVars.UsersPath + GlobalVars.UserId);
                    return new string[] { "3", "Бундай фойдаланувчи базада йўқ", "Бундай фойдаланувчи базада топилмади, илтимос администраторга мурожат қилинг" };
                }
                byte[] tmp = MiniLZO.Decompress(data);
                File.WriteAllBytes(GlobalVars.UsersPath + GlobalVars.UserId, tmp);
                return new string[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                CurClient.Close();

                CLog.Write(string.Format("ClassOnlineWorks.CheckUser({0},...,{1}) - {2}", inCurValue, "cert", err.GetAllMessages()));
                string[] a = Asbt.Utils.CError.GetLastException(err);
                if (a != null)
                    return new string[] { "5", a[1], a[2] };
                else
                    return new string[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
            }
             */
            return new string[3] { "1", "OK", "OK" };
        }

        public static string[] CheckUser(string inCurValue, string inSignedCurValue, string UserCert)
        {
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                var Cert = Convert.FromBase64String(UserCert);
                var data = CurClient.CheckLogin(inCurValue, inSignedCurValue, Cert, "3");
                if (data == null)
                {
                    File.Delete(Vars.UsersPath + Vars.UserId);
                    return new[]
                    {
                        "3", "Бундай фойдаланувчи базада йўқ",
                        "Бундай фойдаланувчи базада топилмади, илтимос администраторга мурожат қилинг"
                    };
                }
                var tmp = data.Decompress();
                File.WriteAllBytes(Vars.UsersPath + Vars.UserId, tmp);
                return new[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                CurClient.Close();
                CLog.Write(string.Format("ClassOnlineWorks.CheckUser({0},...,{1}) - {2}", inCurValue, "cert",
                    err.GetAllMessages()));
              
                    return new[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
            }
        }

        public static string[] GetServerTime(DateTime clientTime, out string outTime)
        {
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            outTime = string.Empty;
            try
            {
                WaitFormManager.Show();
                var data = CurClient.GetServerTime(clientTime.ToString());
                var servTime = DateTime.Now;
                servTime = Convert.ToDateTime(data);
                outTime = string.Format("Сервер вақти {0}: {1} с. олинди", servTime,
                    Math.Round((clientTime - servTime).TotalSeconds, 3));
                return new[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                AlertMessage.ShowError(err.GetAllMessages());
                CLog.Write(string.Format("ClassOnlineWorks.GetServerTime({0}) - {1}", clientTime, err.GetAllMessages()));
             
                    return new[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }

        public static string GetServerTime(DateTime clientTime)
        {
            var result = "";
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                WaitFormManager.Show();
                try
                {
                    CurClient.GetServerTimeCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                        {
                            var data = ex.Result;
                            var servTime = DateTime.Now;
                            try
                            {
                                servTime = Convert.ToDateTime(data);
                                result = string.Format("Сервер вақти {0}: {1} с. олинди", servTime,
                                    Math.Round((clientTime - servTime).TotalSeconds, 3));
                            }
                            catch (Exception err)
                            {
                                CLog.Write(string.Format("ClassOnlineWorks.GetServerTime.Convert({0}) - {1}", servTime,
                                    err.Message));
                                result = "NOCONNECTION";
                            }
                        }
                        else
                            AlertMessage.ShowError(ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.GetServerTimeAsync(clientTime.ToString());

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;


                    return result;
                }
                catch (Exception err)
                {
                    CurClient.Close();
                    CLog.Write(string.Format("ClassOnlineWorks.GetServerTime({0}) - {1}", clientTime, err.Message));
                    return "NOCONNECTION";
                }
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }

        public static string MailService(string content)
        {
            var data = "";
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                WaitFormManager.Show();
                try
                {
                    CurClient.MailServiceCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                        {
                            data = ex.Result;

                            //if (_dt.Rows.Count == 0)
                            //    AlertMessage.Show("Натижа", "Маълумот йўқ...");                            
                        }
                        else
                            AlertMessage.ShowError(ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.MailServiceAsync("", content);

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;

                    return data;
                }
                catch (Exception err)
                {
                    WaitFormManager.Close();

                    CurClient.Close();
                    AlertMessage.ShowError(err.GetAllMessages());
                    CLog.Write(string.Format("ClassOnlineWorks.MailService({0}) - {1}", content, err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }

        public static DataTable GetProcedureDataTable(string[] inParams, string inProcName, bool IsShowWaitForm = true)
        {
            var _dt = new DataTable();
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);

            try
            {
                if (IsShowWaitForm)
                    WaitFormManager.Show();
                try
                {
                    CurClient.GetDataTableProcedureCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                        {
                            byte[] va = MiniLZO.Decompress(ex.Result);
                            _dt = AdoNetHelper.DeserializeDataTable(va);

                            if (_dt.Rows.Count == 0)
                                AlertMessage.Show("Натижа", "Маълумот йўқ...");
                        }
                        else
                            AlertMessage.ShowError(ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.GetDataTableProcedureAsync(inParams, inProcName.ToUpper());

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    };
                    return _dt;
                }
                catch (Exception err)
                {
                    WaitFormManager.Close();

                    CurClient.Close();
                    AlertMessage.ShowError(err.GetAllMessages());
                    CLog.Write(string.Format("ClassOnlineWorks.GetProcedureDataTable({0}) - {1}", inProcName,
                        err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                if (IsShowWaitForm)
                    WaitFormManager.Close();
            }
        }

        


        public static DataSet GetProcedureDataSet(string[] inParams, string inProcName, bool IsShowSplash = true)
        {
            DataSet result = null;
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                if (IsShowSplash)
                    WaitFormManager.Show();

                try
                {
                    CurClient.GetDataSetProcedureCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                        {
                            var data = ex.Result;
                            var tmp = data.Decompress();
                            result = AdoNetHelper.DeserializeDataSet(tmp);
                        }
                        else
                            AlertMessage.ShowError(ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.GetDataSetProcedureAsync(inParams, inProcName.ToUpper());

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;

                    return result;
                }
                catch (Exception err)
                {
                    WaitFormManager.Close();

                    CurClient.Close();
                    AlertMessage.ShowError(err.GetAllMessages());
                    CLog.Write(string.Format("ClassOnlineWorks.GetProcedureDataSet({0}) - {1}", inProcName, err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                if (IsShowSplash) WaitFormManager.Close();
            }
        }

        public static string[] SendDataProcedureBlock(string inIp, string inContent, bool IsShowSplash = true)
        {
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                if (IsShowSplash)
                    WaitFormManager.Show();

                var data = CurClient.MailService(inIp, inContent);
                var ans = data.Split('|');
                return new[] { ans[0], ans[1], ans[2] };
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("ClassOnlineWorks.SendDataProcedure({0}, inContent) - {1}", inIp,
                    err.GetAllMessages()));
              
                    return new[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
                if (IsShowSplash)
                    WaitFormManager.Close();
            }
        }

        public static string SendDataProcedureAsync(string inIp, string inContent)
        {
            var result = "";
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                WaitFormManager.Show();

                try
                {
                    CurClient.MailServiceCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                            result = ex.Result;
                        else
                            AlertMessage.Show("Хато", ex.Error.GetAllMessages());
                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.MailServiceAsync(inIp, inContent);

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;


                    return result;
                }
                catch (Exception err)
                {
                    WaitFormManager.Close();

                    CurClient.Close();
                    CLog.Write(string.Format("ClassOnlineWorks.SendDataProcedure({0}, inContent) - {1}", inIp,
                        err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }

        public static string[] GetRefreshDico(string inScn, string inIp, string inDivType, string inDivision,
            out DataSet outDs)
        {
            outDs = new DataSet();
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                var data = CurClient.GetDicoUpdate(inScn, inIp, inDivType, inDivision);
                var tmp = data.Decompress();
                outDs = AdoNetHelper.DeserializeDataSet(tmp);
                return new[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("ClassOnlineWorks.GetRefreshDico({0},{1},{2},{3}) - {4}", inScn, inIp,
                    inDivType, inDivision, err.GetAllMessages()));
               
                    return new[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
            }
        }

        public static string[] GetDico(string inTable, string inWhere, string inLn, out DataTable outDt)
        {
            outDt = new DataTable();
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                var data = CurClient.GetReference(inTable, inWhere, inLn);
                var tmp = data.Decompress();
                outDt = AdoNetHelper.DeserializeDataTable(tmp);
                return new[] { "1", "OK", "" };
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("ClassOnlineWorks.GetDico({0},{1},{2}) - {3}", inTable, inWhere, inLn,
                    err.GetAllMessages()));
                
                    return new[] { "5", "Алоқа уланишда ҳато", err.GetAllMessages() };
            }
            finally
            {
                CurClient.Close();
            }
        }

    
     
        public static byte[] GetFoto(string id)
        {
            byte[] result = null;
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                WaitFormManager.Show();
                try
                {
                    CurClient.GetPhotoCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                            result = ex.Result;
                        else
                            AlertMessage.Show("Хато", ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.GetPhotoAsync(id);

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;


                    return result;
                }
                catch (Exception err)
                {
                    CurClient.Close();
                    CLog.Write(string.Format("ClassOnlineWorks.GetFoto({0}) - {1}", id, err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }

        public static DataSet GetDynamicRpcDataSet(byte[] sendData, string p)
        {
            DataSet result = null;
            var CurClient = new IwcServiceClient(Vars.CurEndpoint);
            try
            {
                WaitFormManager.Show();

                try
                {
                    CurClient.DoRPCWorkCompleted += (s, ex) =>
                    {
                        if (ex.Error == null)
                        {
                            if (ex.Result != null)
                            {
                                var data = ex.Result;
                                var tmp = data.Decompress();
                                result = AdoNetHelper.DeserializeDataSet(tmp);
                            }
                        }
                        else
                            AlertMessage.ShowError(ex.Error.GetAllMessages());

                        IsBus = false;
                    };

                    IsBus = true;
                    CurClient.DoRPCWorkAsync(p, sendData);

                    while (IsBus)
                    {
                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    ;

                    return result;
                }
                catch (Exception err)
                {
                    CurClient.Close();
                    AlertMessage.ShowError(err.GetAllMessages());
                    CLog.Write(string.Format("ClassOnlineWorks.DoRPCWorkAsync {0} - {1}", p, err.Message));
                    return null;
                }
            }
            finally
            {
                CurClient.Close();
                WaitFormManager.Close();
            }
        }
    }
}