using Apteka.Utils;
using Kadr.Utils;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kadr.UtilsUI
{
    public partial class FrmTestConnection : DevExpress.XtraEditors.XtraForm
    {
        public FrmTestConnection()
        {
            InitializeComponent();

            CLang.Init(this);
        }

        private async void btnTestConn_ClickAsync(object sender, System.EventArgs e)
        {
            try
            {
                WaitFormManager.Show();
                var s = $"Data Source={edValue.Text};Initial Catalog=AptekaDataBase;Integrated Security=True";
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

        private void cbTypeConn_EditValueChanged(object sender, System.EventArgs e)
        {
            layoutControlItem3.Enabled = cbTypeConn.SelectedIndex == 1;
            layoutControlItem4.Enabled = cbTypeConn.SelectedIndex == 1;
        }
    }
}