using System;
using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;

namespace Apteka.Others
{
    public partial class FrmSelDistributor : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private spDistributor distributor;

        public FrmSelDistributor()
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) =>
            {
                distributor = db.Distributor.Get(cbDistributor.EditValue.ToGuid());
                db.Dispose();
            };

            cbDistributor.Properties.DataSource = db.Distributor.GetSp();

            CLang.Init(this);
        }

        public tbPriceDoc GetData()
        {
            var ph = new tbPriceDoc();
            ph.Id = Guid.NewGuid();
            ph.CreateDate = DateTime.Now;
            ph.CreateUser = Vars.UserId;
            ph.Distributor = distributor;
            ph.DistributorId = cbDistributor.EditValue.ToGuid();
            ph.Status = 1;

            return ph;
        }

        private void cbDistributor_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var fm = new FrmNewDistributor();
                if (fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    cbDistributor.Properties.DataSource = db.Distributor.GetSp();
                }
            }
        }
    }
}