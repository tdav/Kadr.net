using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Kadr.PluginManager;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Kadr.Users
{
    [Export(typeof(IPlugin))]
    public class Export : IPlugin
    {
        private BarButtonItem btn;
        private FrmUserManage frm;
        private RibbonForm frmMain;

        public string Version
        {
            get
            {
                return Assembly.GetAssembly(typeof(Export)).GetName().Version.ToString();
            }
        }

        public string Description => "Управления пользователями";


        public object Initialize(Dictionary<string, object> param)
        {
            var r = param["RPGMAIN"] as RibbonPageGroup;
            frmMain = param["THIS"] as RibbonForm;

            btn = new BarButtonItem();
            btn.Caption = Description;
            btn.ItemClick += OnItemClick;
            btn.ImageUri.Uri = "CustomizeGrid;Office2013";
            r.ItemLinks.Add(btn);
            return true;
        }

        void OnItemClick(object sender, ItemClickEventArgs e)
        {
            frm = new FrmUserManage();
            frm.MdiParent = frmMain;
            frm.Show();
        }

        public void Dispose()
        {
            frm?.Dispose();

            btn.ItemClick -= OnItemClick;
            btn.Dispose();
        }

        
        public object Initialize(object MainContainer, string conStr)
        {
            //TODO
            throw new System.NotImplementedException();
        }
    }
}
