using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Asbt.Utils;

namespace GenInsSql
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //GlobalVars.InitGlobalVars();

            lbCheckBok.DataSource = MsSqlDbClass.GetTablesFromMdb();
            cbTableNames.Properties.Items.AddRange(MsSqlDbClass.GetTableNames());

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            foreach (var item in lbCheckBok.CheckedItems)
            {
                
                DataRowView r = (item as DataRowView);
                var tb = r.Row["TABLE_NAME"].ToStr();

                memoEdit1.Text += MsSqlDbClass.InsertTable( tb, cbTableNames.Text );
            }
            
        }
    }
}
