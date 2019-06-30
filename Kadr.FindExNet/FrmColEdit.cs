using System;
using DevExpress.XtraEditors;

namespace Kadr.FindExNet
{
    public partial class FrmColEdit : XtraForm
    {
        public FrmColEdit()
        {
            InitializeComponent();
        }

        private SerListExportFields CreateExportFields()
        {
            var ef = new SerListExportFields();
            ef.Add(new SerExportFields { DisplayName = "РИБ/ТРИБ", FieldName = "TB_DIVISION", Visible = true });
            ef.Add(new SerExportFields { DisplayName = "Олдинги риб/триб коди", FieldName = "TB_OLDREO", Visible = true });
            
            ef.Add(new SerExportFields {DisplayName = "ДРБ", FieldName = "TB_GOSNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Техп Сер.", FieldName = "TB_SERY", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Техп №.", FieldName = "TB_NUMBER", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Кузов тури", FieldName = "KUZOV", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "ТВ Тури", FieldName = "AUTOTYPE", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "TB модели", FieldName = "MARKA", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Умимий ранги", FieldName = "COLOR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Ранги", FieldName = "TB_VSUBCOLOR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Йили", FieldName = "CAR_YEAR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "ФИО", FieldName = "FIO", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Туг. йил", FieldName = "TB_DATEBIRTH", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Фукаролиги", FieldName = "TB_CITIZEN", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Вилоят", FieldName = "OBLAST", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Туман", FieldName = "RAYON", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Манзили", FieldName = "MAZIL", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Тех. жараён", FieldName = "JARAYON", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Кирит. сана", FieldName = "TB_DATEREG", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Двиг. №", FieldName = "TB_MOTORNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Кузов №", FieldName = "TB_KUZOVNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Шасси №", FieldName = "TB_SHASSINUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Статус", FieldName = "ACTIVE", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Тегиш.", FieldName = "CARDTYPE", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "СТИР", FieldName = "STIR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Кв. серия № сумма", FieldName = "KVSERNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Ёқилғи", FieldName = "YOQILGI", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Газ №", FieldName = "GAZNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Газ ўрнат. корх.", FieldName = "GAZFIRMA", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Холати", FieldName = "TB_DOCKIND", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Ишончнома", FieldName = "OWNFIO", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Хужжат тури", FieldName = "TB_DOCTYPEB", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Паспорт серия", FieldName = "TB_PASPSERY", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Паспорт №", FieldName = "TB_PASPNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Эгалик хужжати", FieldName = "TB_SCHETSPR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Реестр", FieldName = "TB_REESTR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Бланк серия", FieldName = "TB_BLSERY", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Бланк №", FieldName = "TB_BLNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Сана", FieldName = "TB_BLDATE", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "ДНИ номи", FieldName = "NATARISUSNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Натариус ФИО", FieldName = "NATARISUSFIO", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Автосалон номи", FieldName = "AVTOSALON", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Ишлаб чиқ. йили", FieldName = "TB_YEAR", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Вазни", FieldName = "TB_MASSA", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Куввати", FieldName = "TB_POWER", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "ТВ с/о бахоси", FieldName = "TV_NARHI", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Ўриндиклар сони", FieldName = "TV_SEDENI", Visible = true});
            ef.Add(new SerExportFields
            {
                DisplayName = "Олдинги Тех. п серия",
                FieldName = "TB_OLDTEXPSERY",
                Visible = true
            });
            ef.Add(new SerExportFields {DisplayName = "№", FieldName = "TB_OLDTEXPNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Олдинги ДРБ", FieldName = "TB_OLDGOSNUM", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Алохи.белгилар", FieldName = "TB_AL_BELGIKARI", Visible = true});
            ef.Add(new SerExportFields {DisplayName = "Телефон", FieldName = "TB_TEL", Visible = true});

            ef.Add(new SerExportFields { DisplayName = "Хабарнома серия", FieldName = "TB_XABARSERY", Visible = true });
            ef.Add(new SerExportFields { DisplayName = "Хабарнома №", FieldName = "TB_XABARNUM", Visible = true });
                                                                       
            ef.Add(new SerExportFields {DisplayName = "Қўшимча маълумот", FieldName = "TB_COMMENT", Visible = true});
            return ef;
        }

        private void btnDefalt_Click(object sender, EventArgs e)
        {
            gridCol.DataSource = CreateExportFields();
        }
    }
}