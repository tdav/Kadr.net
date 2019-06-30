using Kadr.Database.Views;
using Kadr.Utils;
using System;
using System.Data;


namespace App
{
    public partial class FrmTable : DevExpress.XtraEditors.XtraForm
    {
        public FrmTable()
        {
            InitializeComponent();
            CLang.Init(this);

            panelControl1.Visible = true;
        }


        public FrmTable(string table, int i)
        {
            InitializeComponent();

            this.Text = table;
            LoadSpTable(i);
        }


        private void LoadSpTable(int i)
        { 
            gridViewTable.Columns.Clear();
            string ts = GetTableName();
            gcTable.DataSource = DicoDB.SelectSQL("select * from " + ts);
        }

        private string GetTableName(string tn="")
        {
            string ts="";
            string tb = (tn == "" ? cbTables.Text : tn);
            switch (tb)
            {
                case "Давлат мукофотлари":
                    ts = "SA_NAGRADA";
                    break;
                case "Ҳарбий унвон":
                    ts = "SA_HARBIY_UNVON";
                    break;
                case "Вид учреждения":
                    ts = "SA_VID_UCHEREJDENI";
                    break;
                case "Илмий даражаси":
                    ts = "SA_UCHENIY_STEPEN";
                    break;
                case "Вид должности":
                    ts = "SA_DOLJNOST";
                    break;
                case "Национальность":
                    ts = "SA_NAT";
                    break;
                case "Район (город)":
                    ts = "SA_RAYON";
                    break;
                case "Педагогическое образование":
                    ts = "SA_PEDOBRAZOVANIE";
                    break;
                case "Пол":
                    ts = "SA_SEX";
                    break;
                case "Родственик":
                    ts = "SA_RODSTVENNIK";
                    break;
                case "Повышения квалификации":
                    ts = "SA_PEDPEREPOD";
                    break;
                case "Семейны полжения":
                    ts = "SA_MARRIED";
                    break;
                case "Вузы":
                    ts = "SA_VUZ";
                    break;
                case "Ученый степень":
                    ts = "SA_SCSTATUS";
                    break;
                case "Давлат":
                    ts = "SA_COUNTRY";
                    break;
                case "Чет тиллари":
                    ts = "SA_LANGS";
                    break;
                case "Маълумоти":
                    ts = "SA_OBRAZOVANIYA";
                    break;
                case "Тип обучения":
                    ts = "SA_VID_UCHEREJDENI_DIPLOM";
                    break;
                case "Спеециалность":
                    ts = "SA_SPECIALITY";
                    break;
                case "В данной отчетом периоде":
                    ts = "SA_RABOTAET_YN";
                    break;
                case "Категория":
                    ts = "SA_MASTER_KATEGORIYA";
                    break;
                case "Предмет":
                    ts = "SA_PREDMET";
                    break;
                case "Принят на работу":
                    ts = "SA_PINYAT_NA_RABOTU";
                    break;
                case "Вид преподоваемого дополнительного предмет":
                    ts = "SA_VID_PREDMETA";
                    break;
                case "Партии":
                    ts = "SA_PARTIYA";
                    break;
                case "Педагог":
                    ts = "SA_PEDAGOG_YN";
                    break;
                case "Место прохождение ПК":
                    ts = "SA_PROHODIL_YN";
                    break;
                case "Коллеж":
                    ts = "SA_KOLLEJ";
                    break;
                case "Лицей":
                    ts = "SA_LICEY";
                    break;
                case "Вид обучения":
                    ts = "SA_VID_OBUCHENIYA";
                    break;
                case "Штат":
                    ts = "SA_PO_SHATATU";
                    break;

                case "Привлечение к аттестац":
                    ts = "SA_ATESTACIYA_YN";
                    break;
                case "Резултат атестатции":
                    ts = "SA_ATESTACIYA_RES";
                    break;
            }
            return ts;
        }

        private void cbTable_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSpTable(cbTables.SelectedIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable diu;
            DataTable dt = gcTable.DataSource as DataTable;
            

            diu = dt.GetChanges(DataRowState.Added);
            if (diu != null)
            {
                foreach (DataRow row in diu.Rows)
                {
                    sql = DicoDB.InsUpdTable(GetTableName(cbTables.Text), row);
                    DicoDB.ExecSQL(sql);
                }
            }

            diu = dt.GetChanges(DataRowState.Modified);
            if (diu != null)
            {
                foreach (DataRow row in diu.Rows)
                {
                    sql = DicoDB.InsUpdTable(GetTableName(cbTables.Text), row);
                    DicoDB.ExecSQL(sql);
                }
            }
        }
    }
}