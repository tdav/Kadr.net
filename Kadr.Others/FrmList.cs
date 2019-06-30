namespace Apteka.Others
{
    public partial class FrmTestList : DevExpress.XtraEditors.XtraForm
    {
        public FrmTestList(object list)
        {
            InitializeComponent();

            gridControl.DataSource = list;
        } 
    }
}