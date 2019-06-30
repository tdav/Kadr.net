using System;
using System.Data;
using Asbt.Utils;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Asbt.Services
{
    public static class CheckDsign
    {
        public static bool isCheckSignature = false;
        public static string ParrentCertPath = @"d:\MyProjects\Passport-Viza\E-kalit\test keys\uzdst_1_root.cer";
        public static string CrlFilePath = @"c:\InvokedListCrl\uzdst.crl";
        public static bool isCheckParrent = false;
        public static bool isCheckCorrectParrent = true;
        public static bool isCheckInvocked = true;
        public static bool isRefreshInvocked = true;

        //public static string[] CheckSignature(string openData, string signedData, byte[] openCert)
        //{
        //    try
        //    {
        //        libesigner.net.Signature sign = new libesigner.net.Signature(signedData, true);
        //        Certificate cer = new Certificate(openCert, openCert.Length);

        //        #region Проверка дат сертификата

        //        if ((cer.GetNotBefore().ToLocalTime() > DateTime.Now) || (cer.GetNotAfter().ToLocalTime() < DateTime.Now))
        //            return new string[] { "103", "Сертификат санаси ўтган", "" };

        //        #endregion

        //        #region Проверка родителя сертификата
        //        if (isCheckParrent)
        //        {
        //            Certificate cerIssuer = new Certificate(ParrentCertPath);
        //            if (!cerIssuer.Verify(cerIssuer))
        //                return new string[] { "104", "Тасдиқловчи органи сертификатида ҳато", "" };
        //            if (isCheckCorrectParrent)
        //                if (!cer.Verify(cerIssuer))
        //                    return new string[] { "104", "Сертификат берилган орган тасдиқланмади", "" };
        //        }
        //        #endregion

        //        #region Проверка отозван ли сертификат

        //        if (isCheckInvocked)
        //        {
        //            Certificate cerIssuer1 = new Certificate(ParrentCertPath);
        //            Crl crl = null;
        //            bool isNotValid = true;
        //            try
        //            {
        //                if (File.Exists(CrlFilePath))
        //                {
        //                    crl = new Crl(CrlFilePath);
        //                    isNotValid = crl.GetLastUpdate() > DateTime.Now || crl.GetNextUpdate() < DateTime.Now;
        //                }
        //            }
        //            //catch (FileNotFoundException e)
        //            //{
        //            //    return new string[] { "104", "Тасдиқловчи сертификат топилмади", e.GetAllMessages() };
        //            //}
        //            catch (Exception e)
        //            {
        //                return new string[] { "104", "Тасдиқловчи сертификат ўқишда ҳато", e.GetAllMessages() };
        //            }
        //            if ((isNotValid) && (isRefreshInvocked))
        //            {
        //                String crlUrl = cer.GetCRLDistributionPoint();
        //                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(crlUrl);
        //                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //                Stream resStream = response.GetResponseStream();
        //                FileStream fs = new FileStream(CrlFilePath, FileMode.Create);
        //                resStream.CopyTo(fs);
        //                fs.Seek(0, SeekOrigin.Begin);
        //                crl = new Crl(fs);
        //            }
        //            if (crl != null)
        //            {
        //                if (!crl.Verify(cerIssuer1))
        //                    return new string[] { "104", "Қайтарилган сертификатлар рўйхати тасдиқланмаган", "Crl файл электрон имзосида ҳато" };

        //                Revocation revoke = crl.IsRevoked(cer);
        //                if (revoke.GetReason() > 0)
        //                    return new string[] { "102", "Сертификат қайтарилган", revoke.GetReasonText() };
        //            }
        //        }
        //        #endregion

        //        //byte[] b = openData.ToByteArray();
        //        Hash hash = new Hash();
        //        byte[] digestOfString = hash.OfString(openData);

        //        if (sign.Verify(digestOfString, cer))
        //            return new string[3] { "1", "OK", "" };
        //        else
        //            return new string[3] { "101", "Электрон имзода ҳато", "Электрон имзо текшириш натижаси манфий" };
        //    }
        //    catch (Exception err)
        //    {
        //        return new string[3] { "101", err.Message, err.GetAllMessages() };
        //    }
        //}

        //public static string[] CheckSignature(byte[] openData, string signedData, byte[] openCert)
        //{
        //    try
        //    {
        //        libesigner.net.Signature sign = new libesigner.net.Signature(signedData, true);
        //        Certificate cer = new Certificate(openCert, openCert.Length);

        //        #region Проверка дат сертификата

        //        if ((cer.GetNotBefore().ToLocalTime() > DateTime.Now) || (cer.GetNotAfter().ToLocalTime() < DateTime.Now))
        //            return new string[] { "103", "Сертификат санаси ўтган", "" };

        //        #endregion

        //        #region Проверка родителя сертификата
        //        if (isCheckParrent)
        //        {
        //            Certificate cerIssuer = new Certificate(ParrentCertPath);
        //            if (!cerIssuer.Verify(cerIssuer))
        //                return new string[] { "104", "Тасдиқловчи органи сертификатида ҳато", "" };
        //            if (isCheckCorrectParrent)
        //                if (!cer.Verify(cerIssuer))
        //                    return new string[] { "104", "Сертификат берилган орган тасдиқланмади", "" };
        //        }
        //        #endregion

        //        #region Проверка отозван ли сертификат

        //        if (isCheckInvocked)
        //        {
        //            Certificate cerIssuer1 = new Certificate(ParrentCertPath);
        //            Crl crl = null;
        //            bool isNotValid = true;
        //            try
        //            {
        //                if (File.Exists(CrlFilePath))
        //                {
        //                    crl = new Crl(CrlFilePath);
        //                    isNotValid = crl.GetLastUpdate() > DateTime.Now || crl.GetNextUpdate() < DateTime.Now;
        //                }
        //            }
        //            //catch (FileNotFoundException e)
        //            //{
        //            //    return new string[] { "104", "Тасдиқловчи сертификат топилмади", e.GetAllMessages() };
        //            //}
        //            catch (Exception e)
        //            {
        //                return new string[] { "104", "Тасдиқловчи сертификат ўқишда ҳато", e.GetAllMessages() };
        //            }
        //            if ((isNotValid) && (isRefreshInvocked))
        //            {
        //                String crlUrl = cer.GetCRLDistributionPoint();
        //                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(crlUrl);
        //                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //                Stream resStream = response.GetResponseStream();
        //                FileStream fs = new FileStream(CrlFilePath, FileMode.Create);
        //                resStream.CopyTo(fs);
        //                fs.Seek(0, SeekOrigin.Begin);
        //                crl = new Crl(fs);
        //            }
        //            if (crl != null)
        //            {
        //                if (!crl.Verify(cerIssuer1))
        //                    return new string[] { "104", "Қайтарилган сертификатлар рўйхати тасдиқланмаган", "Crl файл электрон имзосида ҳато" };

        //                Revocation revoke = crl.IsRevoked(cer);
        //                if (revoke.GetReason() > 0)
        //                    return new string[] { "102", "Сертификат қайтарилган", revoke.GetReasonText() };
        //            }
        //        }
        //        #endregion

        //        //byte[] b = openData.ToByteArray();
        //        Hash hash = new Hash();
        //        byte[] digestOfString = hash.OfBytes(openData, openData.Length);

        //        if (sign.Verify(digestOfString, cer))
        //            return new string[3] { "1", "OK", "" };
        //        else
        //            return new string[3] { "101", "Электрон имзода ҳато", "Электрон имзо текшириш натижаси манфий" };
        //    }
        //    catch (Exception err)
        //    {
        //        return new string[3] { "101", err.Message, err.GetAllMessages() };
        //    }
        //}


        //public static bool CheckSignature(DataSet dsData)
        //{
        //    try
        //    {
        //        String signData = Convert.ToBase64String((dsData.Tables["SIGNATURE"].Rows[0]["TB_SIGNATURE"] as byte[]));
        //        libesigner.net.Signature sign = new libesigner.net.Signature(signData, true);

        //        byte[] cerEKalitBytes = (dsData.Tables["CERTIFICATE"].Rows[0]["TB_CERTIFICATE"] as byte[]);
        //        Certificate cerEKalit = new Certificate(cerEKalitBytes, cerEKalitBytes.Length);

        //        byte[] b = GetByteArrayOfData(dsData.Tables["ALLDATA"]);
        //        Hash hash = new Hash();
        //        byte[] digestOfString = hash.OfBytes(b, b.Length);

        //        return (sign.Verify(digestOfString, cerEKalit));
        //    }
        //    catch (Exception err)
        //    {
        //        return false;
        //    }
        //}

        private static byte[] GetByteArrayOfData(DataTable dtData)
        {
            string base64 = string.Empty;
            foreach (DataColumn item in dtData.Columns)
            {
                if (item.DataType == Type.GetType("System.Byte[]"))
                    base64 += Convert.ToBase64String((dtData.Rows[0][item] as byte[]));
                else
                    base64 += dtData.Rows[0][item].ToStr();
            }
            return base64.ToByteArray();
        }

        public static string[] GetParamsFromDataSet(string inContent, out string outArm, 
                  out string[] outParams, out byte[] outSumParams, out string outSignedData, out byte[] outCert)
        {
            outArm = outSignedData = string.Empty;
            outSumParams = null;
            outCert = null;
            List<string>  op = new List<string>();
            outParams = null;
            
            try
            {
                DataSet ds = new DataSet("DATA");
                System.IO.MemoryStream mStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(inContent));
                ds.ReadXml(mStream, XmlReadMode.ReadSchema);

                if (ds.Tables.Contains("ALLDATA"))
                {
                    if (ds.Tables["ALLDATA"].Rows.Count > 0)
                    {
                        outArm = Asbt.Utils.CCrypt.DecryptRijndael(ds.Tables["ARM"].Rows[0]["TB_ARM"].ToStr());
                        outSignedData = Convert.ToBase64String((ds.Tables["SIGNATURE"].Rows[0]["TB_SIGNATURE"] as byte[]));
                        outCert = (ds.Tables["CERTIFICATE"].Rows[0]["TB_CERTIFICATE"] as byte[]);

                        foreach (DataColumn item in ds.Tables["ALLDATA"].Columns)
                        {
                            op.Add(ds.Tables["ALLDATA"].Rows[0][item].ToStr());
                            //if (item.DataType == Type.GetType("System.Byte[]"))
                            //    outSumParams += Convert.ToBase64String((ds.Tables["ALLDATA"].Rows[0][item] as byte[]));
                            //else
                            //    outSumParams += ds.Tables["ALLDATA"].Rows[0][item].ToStr();
                        }
                        op.Add("");

                        outSumParams = GetByteArrayOfData(ds.Tables["ALLDATA"]);
                        outParams = op.ToArray();

                        return new string[] { "1", "OK", "" };
                    }
                    else
                        return new string[] { "201", "Маълумотлар йўқ", "Юборилаётган XML файлда мажбурий маълумотлар йўқ" };
                }
                else
                    return new string[] { "201", "ALLDATA Маълумотлари йўқ", "Юборилаётган XML файлда ALLDATA маълумотлар йўқ" };
            }
            catch (Exception err)
            {
                CLog.Write(string.Format("GetParamsFromDataSet {0} {1}", inContent, err.GetAllMessages()));
                return new string[] { "0", "Сервисда ҳато", err.GetAllMessages() };
            }
        }

        public static string[] GetParamsFromDataTable(string inContent, out List<string> outParams, out string outSumParams)
        {
            outSumParams = string.Empty;
            outParams = new List<string>();
            try
            {
                DataTable dt_certificate = new DataTable("DATA");
                System.IO.MemoryStream mStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(inContent));
                dt_certificate.ReadXml(mStream);

                if (dt_certificate.Rows.Count > 0)
                {
                    foreach (DataColumn item in dt_certificate.Columns)
                    {
                        outParams.Add(dt_certificate.Rows[0][item].ToStr());
                        outSumParams += dt_certificate.Rows[0][item].ToStr();
                    }
                    outParams.Add("");
                    return new string[] { "1", "OK", "" };
                }
                else
                    return new string[] { "201", "Маълумотлар йўқ", "Юборилаётган XML файлда мажбурий маълумотлар йўқ" };
            }
            catch (Exception err)
            {
                Logging.Write(string.Format("GetParamsFromDataTable({0},...)", inContent), err);
                return new string[] { "0", "Сервисда ҳато", err.GetAllMessages() };
            }
        }

        public static string GetUserId(byte[] openCert)
        {
            try
            {
                Certificate userCert = new Certificate(openCert, openCert.Length);
                string usrId = userCert.GetSerialNumber();
                return usrId.ToUpper();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}