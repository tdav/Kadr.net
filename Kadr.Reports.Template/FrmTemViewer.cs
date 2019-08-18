using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;

namespace Kadr.Template
{
    public partial class FrmTemViewer : RibbonForm
    {
        public delegate void DelegateOnCloseChildForm(object sender);

        private readonly bool _isTexp;

        public FrmTemViewer(bool IsTexp)
        {
            _isTexp = IsTexp;
            InitializeComponent();

            printPreviewRibbonPageGroup1.Visible = !IsTexp;
            printPreviewRibbonPageGroup7.Visible = !IsTexp;
        }

        public event DelegateOnCloseChildForm OnCloseChildForm;

        private void FrmTemViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnCloseChildForm != null)
                OnCloseChildForm(this);
        }

        private void btnDesiner_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyReport = Tag as XtraReport;
            MyReport.ShowDesignerDialog();
        }

        private void FrmTemViewer_Shown(object sender, EventArgs e)
        {
            var MyReport = Tag as XtraReport;

            MyReport.RequestParameters = false;
            MyReport.ShowPrintMarginsWarning = false;
            MyReport.ShowPrintStatusDialog = false;
            MyReport.PrintingSystem.StartPrint += (s, ep) =>
            {
                if (_isTexp)
                {
                    ep.PrintDocument.PrinterSettings.Copies = 1;
                    ep.PrintDocument.PrinterSettings.FromPage = 1;
                    ep.PrintDocument.PrinterSettings.ToPage = 1;
                    ep.PrintDocument.PrinterSettings.PrintRange = PrintRange.SomePages;
                }
            };
            docViewer.PrintingSystem = MyReport.PrintingSystem;
        }
    }
}