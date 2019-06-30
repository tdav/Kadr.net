using System;
using System.Data;
using Asbt.Utils;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using libesigner.net;
using System.Text;

namespace Asbt.Services
{
    public static class AddClass
    {
        public static bool CheckSignature(string openData, string signedData, byte[] openCert)
        {
            try
            {
                libesigner.net.Signature sign = new libesigner.net.Signature(signedData, true);
                Certificate cerEKalit = new Certificate(openCert, openCert.Length);

                byte[] b = openData.ToByteArray();
                Hash hash = new Hash();
                byte[] digestOfString = hash.OfBytes(b, b.Length);

                return (sign.Verify(digestOfString, cerEKalit));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static bool CheckSignature(DataSet dsData)
        {
            try
            {
                String signData = Convert.ToBase64String((dsData.Tables["SIGNATURE"].Rows[0]["TB_SIGNATURE"] as byte[]));
                libesigner.net.Signature sign = new libesigner.net.Signature(signData, true);

                byte[] cerEKalitBytes = (dsData.Tables["CERTIFICATE"].Rows[0]["TB_CERTIFICATE"] as byte[]);
                Certificate cerEKalit = new Certificate(cerEKalitBytes, cerEKalitBytes.Length);

                byte[] b = GetByteArrayOfData(dsData.Tables["ALLDATA"]);
                Hash hash = new Hash();
                byte[] digestOfString = hash.OfBytes(b, b.Length);

                return (sign.Verify(digestOfString, cerEKalit));
            }
            catch (Exception err)
            {
                return false;
            }
        }

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

        public static string[] GetParamsFromDataSet(string inContent, out string outArm, out List<string> outParams, out string outSumParams, out string outSignedData, out byte[] outCert)
        {
            outArm = outSumParams = outSignedData = string.Empty;
            outCert = null;
            outParams = new List<string>();
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
                            outParams.Add(ds.Tables["ALLDATA"].Rows[0][item].ToStr());
                            if (item.DataType == Type.GetType("System.Byte[]"))
                                outSumParams += Convert.ToBase64String((ds.Tables["ALLDATA"].Rows[0][item] as byte[]));
                            else
                                outSumParams += ds.Tables["ALLDATA"].Rows[0][item].ToStr();
                        }
                        outParams.Add("");
                        return new string[] { "1", "OK", "" };
                    }
                    else
                        return new string[] { "3", "Маълумотлар йўқ", "Юборилаётган XML файлда маълумотлар йўқ" };
                }
                else
                    return new string[] { "3", "ALLDATA Маълумотлари йўқ", "Юборилаётган XML файлда ALLDATA маълумотлар йўқ" };
            }
            catch (Exception err)
            {
                Logging.Write(string.Format("GetParamsFromDataSet({0},...)", inContent), err);
                return new string[] { "3", "Сервисда ҳато", err.GetAllMessages() };
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
                    return new string[] { "3", "Маълумотлар йўқ", "Юборилаётган XML файлда маълумотлар йўқ" };
            }
            catch (Exception err)
            {
                Logging.Write(string.Format("GetParamsFromDataTable({0},...)", inContent), err);
                return new string[] { "3", "Сервисда ҳато", err.GetAllMessages() };
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