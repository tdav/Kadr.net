using Apteka.Utils;
using Kadr.Database.Views;
using Kadr.GlobalVars;
using Kadr.Models;
using Kadr.Models.Core;
using Kadr.Utils;
using Kadr.UtilsUI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Kadr.Users
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork db;
        private tbSetup setup;

        public FrmLogin()
        {
            InitializeComponent();

            Vars.InitGlobalVars();
            db = new UnitOfWork();

            FormClosed += (s, e) => { db.Dispose(); };

            CLang.Init(this);

            pictureEdit1.LoadAsync(AppDomain.CurrentDomain.BaseDirectory + "logo.png");
            //var sc = SystemConfig.Get();
            //Vars.Version = sc?.InstalledVersion;
            //lbVer.Text = "Верия " + Vars.Version;

            var sl = CNet.GetGatewayAddresses();
            var na = CNet.LocalIpAddressAll(sl);
            if (na != "")
                lbIp.Text = $"Ip адрес {na}   шлюз {sl}";
            else
                lbIp.Text = "";

           

            if (Vars.IsDebug)
            {
                edLogin.Text = "admin";
                edPasw.Text = "6666666";
            }
        }

        public static DialogResult Execute()
        {
            FrmLogin frm = new FrmLogin();
            frm.edLogin.Focus();
            DialogResult res = frm.ShowDialog();
            frm.Dispose();
            return res;
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            

            var res = db.User.CheckLogin(edLogin.Text.Trim(),CCrypt.EncryptRijndael(edPasw.Text.Trim()));
            if (res.Item1?.Length == 0)
            {
                 

                SetSystemVariables(res.Item2, setup);

                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                AlertMessage.Show(res.Item1);
            }
        }

        private static void SetSystemVariables(viUser user, tbSetup setup)
        {
            Vars.UserId = user.Id;           
            Vars.UserFullName = $"{user.LastName} {user.FirstName} {user.FatherName}".Trim();


            Vars.SetAccess(user.UserAccess);
            Environment.SetEnvironmentVariable("AppUser", Vars.UserFullName);
        }

        private void sbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //if (Vars.DrugStoreId.ToString() == "00000000-0000-0000-0000-000000000000")
            //{
            //    Process.Start("Registration.exe");
            //    Close();
            //}
        }

        private void FrmLogin_ShownAsync(object sender, EventArgs e)
        {
            Application.DoEvents();
            ThreadPool.QueueUserWorkItem(async (t) =>
            {
                setup = await db.Setup.FirstOrDefaultAsync();
                // sbOK.Enabled = true;
            });
        }

        private void btnSetIpDatabase_Click(object sender, EventArgs e)
        {
            var f = new FrmTestConnectionSm();
            f.ShowDialog();
        }
    }
}