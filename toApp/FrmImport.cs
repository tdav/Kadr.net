using Lcc.RFileClient;
using System;
using System.Collections.Generic;

namespace App
{
    public partial class FrmImport : DevExpress.XtraEditors.XtraForm
    {
        //private TbMainTableAdapter tm = new TbMainTableAdapter();
        //private TBFOTOTableAdapter tf = new TBFOTOTableAdapter();
        //private TBGOSNAGRADITableAdapter tg = new TBGOSNAGRADITableAdapter();
        //private TBATESTATIYATableAdapter ta = new TBATESTATIYATableAdapter();
        //private TBPOVISHKVALTableAdapter tp = new TBPOVISHKVALTableAdapter();
        //private TBUNIVERTableAdapter tu = new TBUNIVERTableAdapter();
        //private TBMESTORABTableAdapter tr = new TBMESTORABTableAdapter();
        //private TBQARINDOSHTableAdapter tq = new TBQARINDOSHTableAdapter();
        //private TBDEPUTYTableAdapter td = new TBDEPUTYTableAdapter();


        private string ImExDir = @"c:\KadrImportExport";
        private FileClient.FClient fc;
        private List<FileList> ls;

        public FrmImport()
        {
            InitializeComponent();
        }

        private void Import()
        {
            //var i = 0;
            //foreach (FileList f in ls)
            //{
            //    var filename = ImExDir + "\\" + Path.GetFileName(f.FileName);
            //    if (File.Exists(filename))
            //    {
            //        byte[] fa = File.ReadAllBytes(filename);
            //        byte[] bc = MiniLZO.Decompress(fa);
            //        DataSet ds = AdoNetHelper.DeserializeDataSet(bc);


            //        foreach (DataTable dt in ds.Tables)
            //        {
            //            switch (dt.TableName)
            //            {
            //                case "TBMAIN":
            //                    tm.IU_DT(dt as KdnDataSet.TbMainDataTable);
            //                    break;
            //                case "TBATESTATIYA":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        ta.IU_DT(dr);
            //                    }
            //                    break;
            //                case "TBFOTO":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tf.IU_DT(dr);
            //                    }
            //                    break;
            //                case "TBGOSNAGRADI":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tg.IU_DT(dr);
            //                    }
            //                    break;
            //                case "TBMESTORAB":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tr.IU_DT(dr);
            //                    }

            //                    break;
            //                case "TBPOVISHKVAL":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tp.IU_DT(dr);
            //                    }

            //                    break;
            //                case "TBQARINDOSH":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tq.IU_DT(dr);
            //                    }

            //                    break;
            //                case "TBSHAT":
            //                    //foreach (DataRow dr in dt.Rows)
            //                    //{
            //                    //    ts.IU_DT(dr);
            //                    //}
            //                    break;
            //                case "TBUNIVER":
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        tu.IU_DT(dr);
            //                    }

            //                    break;
            //            }
            //        }

            //    }

            //    i++;
            //    progressBarControl1.Position = i * 100 / ls.Count;
            //}
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            //WaitFormManager.Show();

            //fc = new FClient();
            //ls = fc.List("NewData");

            //var i = 0;
            //foreach (FileList f in ls)
            //{
            //    fc.DonwloadFile(f.FileName, ImExDir);

            //    var fs = Path.GetFileName(f.FileName);

            //    string[] sa = fs.Remove(fs.Length - 4, 4).Split('@');
            //    var obl = DicoDB.Dec_Dic("SA_OBLAST", sa[1]);
            //    var ray = DicoDB.Dec_Dic("SA_RAYON", sa[2]);
            //    var uch = DicoDB.Dec_Dic("SA_KOLLEJ", sa[3]);

            //    var li = listView1.Items.Add(sa[0]);
            //    li.SubItems.Add(obl); li.SubItems.Add(ray);
            //    li.SubItems.Add(uch); li.SubItems.Add(f.Size.ToStr());
            //    li.ImageIndex = 0;
            //    li.Tag = f;

            //    i++;
            //    progressBarControl1.Position = i * 100 / ls.Count;
            //}

            //WaitFormManager.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }
    }
}

