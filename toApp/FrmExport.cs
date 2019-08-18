using Kadr.MessageManager;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Kadr.GlobalVars;
using Apteka.Utils;
using Apteka.Utils.DataBase;

namespace App
{
    public partial class FrmExport : DevExpress.XtraEditors.XtraForm
    {
        private string ImExDir = @"c:\KadrImportExport\";

        public FrmExport()
        {
            InitializeComponent();
        }

        private void OnFind(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {
            //string sql = "SELECT 0 as CBOX, t.id, t.firstname, t.lastname, t.patronymic FROM tbmain t ";
            //var bAny = edFam.Text != "" || edImya.Text != "" || edOtch.Text != "";
            //sql += (bAny ? " WHERE " : "");

            //sql += (edFam.Text != "" ? " lower(t.firstname) like  " + edFam.Text.ToLower().ToQuote() + " and " : "");
            //sql += (edImya.Text != "" ? " lower(t.lastname) like " + edImya.Text.ToLower().ToQuote() + " and " : "");
            //sql += (edOtch.Text != "" ? " lower(t.patronymic) like " + edOtch.Text.ToLower().ToQuote() + " and " : "");

            //if (bAny)
            //    sql = sql.Substring(0, sql.Length - 5);

            //DataTable dt = DicoDB.SelectSQL(sql);
            //gridControl1.DataSource = dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Vars.Oblast == 0 || Vars.Rayon == 0 || Vars.Ucherejdeniya == 0)
            {
                MessageBox.Show("Созлашга киринг... " + Environment.NewLine + "Тизим параметралини кўрсатинг...");
                return;
            }

            string id = "";
            DataTable dt = gridControl1.DataSource as DataTable;
            foreach (DataRow row in dt.Rows)
            {
                if (row["CBOX"].ToInt() == 1)
                    id += row["ID"].ToStr().ToQuote() + ",";
            }
            if (dt.Rows.Count > 0)
            {
                #region Export
                DataSet ds = new DataSet();
                //DataTable d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBMAIN t  WHERE  t.id in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //d1.TableName = "TBMAIN";
                //ds.Tables.Add(d1);

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBATESTATIYA t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBATESTATIYA";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBDEPUTY t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBDEPUTY";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBFOTO t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBFOTO";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBGOSNAGRADI t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBGOSNAGRADI";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBMESTORAB t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBMESTORAB";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBPOVISHKVAL t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBPOVISHKVAL";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBQARINDOSH t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBQARINDOSH";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBSHAT t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBSHAT";
                //    ds.Tables.Add(d1);
                //}

                //d1 =
                //    DicoDB.SelectSQL(String.Format("SELECT * FROM TBUNIVER t  WHERE  t.mainid in ({0})",
                //        id.Substring(0, id.Length - 1)));
                //if (d1 != null)
                //{
                //    d1.TableName = "TBUNIVER";
                //    ds.Tables.Add(d1);
                //}
                #endregion

                byte[] ba = AdoNetHelper.SerializeDataSet(ds);
                byte[] bc = MiniLZO.Compress(ba);
                if (!Directory.Exists(ImExDir))
                    Directory.CreateDirectory(ImExDir);
                
                string filename = ImExDir +   GenFileName() + ".kdx";
                File.WriteAllBytes(filename, bc);

                SendFile(filename);
                File.Delete(filename);
            }    
        }

        private void SendFile(string filename)
        {
            WaitFormManager.ShowUpload();

            string s1, s2;
            FileClient.FClient fc;

            s1 = filename;
            s2 = "NewData|" + CFile.GetFileName( s1);

            fc = new FileClient.FClient();
            fc.SendFile(s1, s2);

            WaitFormManager.Close();
        }
        private string GenFileName()
        {
            var obl = Vars.Oblast.ToStr();
            var ray = Vars.Rayon.ToStr();
            var uch = Vars.Ucherejdeniya.ToStr();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + "@" + obl + "@" + ray + "@" + uch;
        }
 
    }
}

