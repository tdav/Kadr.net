using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Asbt.Utils;
using FirebirdSql.Data.FirebirdClient;

namespace Asbt.Data
{
    public class ConnSingleton
    {
        public static bool isMessageShowen;

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Asbt.Data.Properties.Settings.ConnectionString"].ConnectionString;
            //@"character set=UNICODE_FSS;data source=localhost;initial catalog=D:\Work_New\Kadr.net\DataBase\REFERENCE.FDB;user id=sysdba;password=masterkey";

        private static FbConnection conn = new FbConnection();

        private ConnSingleton()
        {
        }

       

        public static FbConnection GetDBConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {

                    conn.ConnectionString = ConnectionString;
                    conn.Open();
                }
            }
            catch (FbException err)
            {
                CLog.Write("DicoDB.CreateConn() -> " + err.GetAllMessages());
                CLog.Write("DicoDB.CreateConn() -> " + conn.ConnectionString);
                if (!isMessageShowen)
                    MessageBox.Show("Луғатлар базаси билан уланишда ҳато", "Ҳато", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                isMessageShowen = true;
                return null;
            }
            return conn;
        }

        public static FbConnection getDbInstance()
        {


            if (conn.State != ConnectionState.Open)
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
            }

            return conn;
        }
    }
}