using Apteka.Utils;
using Kadr.Utils;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kadr.UtilsUI
{
    public partial class FrmTestConnectionSm : DevExpress.XtraEditors.XtraForm
    {
        public FrmTestConnectionSm()
        {
            InitializeComponent();

            CLang.Init(this);
        }

        private async void btnTestConn_ClickAsync(object sender, System.EventArgs e)
        {
            try
            {
                WaitFormManager.Show();
                //Data Source=(local)\AptekaSql;User ID=AptekaUser1;Password=123456;Persist Security Info=True;Initial Catalog=AptekaDataBase;
                //Data Source=(local)\AptekaSql;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AptekaDataBase;
                var s = $"Data Source={edValue.Text}\\aptekasql;User ID=AptekaUser1;Password=123456;Persist Security Info=True;Initial Catalog=AptekaDataBase";
                var conn = new SqlConnection(s);
                await conn.OpenAsync();

                CAppSettings.SaveConnectionString("AptekaDBConnectionString", s);

                MessageBoxDev.ShowInfo("Соединения успешно");
            }
            catch (System.Exception ee)
            {
                MessageBox.Show(ee.GetAllMessages());
            }
            finally
            {
                WaitFormManager.Close();
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}