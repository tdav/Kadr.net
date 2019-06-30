using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBMAIN table
    /// </summary>
    public class TbmainMapping : EntityTypeConfiguration<Tbmain>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbmainMapping()
        {
            //table
ToTable("TBMAIN");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasMaxLength(50).IsRequired();
            Property(x => x.Firstname).HasColumnName("FIRSTNAME").HasMaxLength(50);
            Property(x => x.Lastname).HasColumnName("LASTNAME").HasMaxLength(50);
            Property(x => x.Patronymic).HasColumnName("PATRONYMIC").HasMaxLength(50);
            Property(x => x.FioRel).HasColumnName("FIO_REL").HasMaxLength(200);
            Property(x => x.Birthdate).HasColumnName("BIRTHDATE");
            Property(x => x.Birthcountry).HasColumnName("BIRTHCOUNTRY");
            Property(x => x.Birthregion).HasColumnName("BIRTHREGION");
            Property(x => x.Birthtown).HasColumnName("BIRTHTOWN");
            Property(x => x.Nationality).HasColumnName("NATIONALITY");
            Property(x => x.Post).HasColumnName("POST");
            Property(x => x.Sex).HasColumnName("SEX");
            Property(x => x.Objlang).HasColumnName("OBJLANG").HasMaxLength(2);
            Property(x => x.Married).HasColumnName("MARRIED");
            Property(x => x.Lang).HasColumnName("LANGS").HasMaxLength(150);
            Property(x => x.Stateprize).HasColumnName("STATEPRIZES");
            Property(x => x.ContryPropiska).HasColumnName("CONTRY_PROPISKA");
            Property(x => x.RegionPropiska).HasColumnName("REGION_PROPISKA");
            Property(x => x.RayonPropiska).HasColumnName("RAYON_PROPISKA");
            Property(x => x.QishloqPropiska).HasColumnName("QISHLOQ_PROPISKA").HasMaxLength(150);
            Property(x => x.KuchaPropiska).HasColumnName("KUCHA_PROPISKA").HasMaxLength(100);
            Property(x => x.UyPropiska).HasColumnName("UY_PROPISKA").HasMaxLength(150);
            Property(x => x.HonadonPropiska).HasColumnName("HONADON_PROPISKA").HasMaxLength(10);
            Property(x => x.Cworkdate).HasColumnName("CWORKDATE");
            Property(x => x.Cworkleavedate).HasColumnName("CWORKLEAVEDATE");
            Property(x => x.Cworkplace).HasColumnName("CWORKPLACE");
            Property(x => x.Cworkdepart).HasColumnName("CWORKDEPART").HasMaxLength(300);
            Property(x => x.Objworkplace).HasColumnName("OBJWORKPLACE").HasMaxLength(300);
            Property(x => x.Workphone).HasColumnName("WORKPHONE").HasMaxLength(100);
            Property(x => x.Homephone).HasColumnName("HOMEPHONE").HasMaxLength(25);
            Property(x => x.Cellphone).HasColumnName("CELLPHONE").HasMaxLength(25);
            Property(x => x.Faxnumber).HasColumnName("FAXNUMBER").HasMaxLength(25);
            Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(50);
            Property(x => x.PassSery).HasColumnName("PASS_SERIES").HasMaxLength(10);
            Property(x => x.PassNumber).HasColumnName("PASS_NUMBER").HasMaxLength(20);
            Property(x => x.PassGivendate).HasColumnName("PASS_GIVENDATE");
            Property(x => x.PassGivenby).HasColumnName("PASS_GIVENBY").HasMaxLength(150);
            Property(x => x.Party).HasColumnName("PARTY");
            Property(x => x.Education).HasColumnName("EDUCATION");
            Property(x => x.Vuz).HasColumnName("VUZ");
            Property(x => x.Speciality).HasColumnName("SPECIALITY");
            Property(x => x.Scstatus).HasColumnName("SCSTATUS");
            Property(x => x.Scdegree).HasColumnName("SCDEGREE").HasMaxLength(250);
            Property(x => x.Service).HasColumnName("SERVICE");
            Property(x => x.Zvanie).HasColumnName("ZVANIE");
            Property(x => x.SudimostRodst).HasColumnName("SUDIMOST_RODST").HasMaxLength(250);
            Property(x => x.Cardnum).HasColumnName("CARDNUM").HasMaxLength(20);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Createdate).HasColumnName("CREATEDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.Createuser).HasColumnName("CREATEUSER");
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.Cardstate).HasColumnName("CARDSTATE");
            Property(x => x.StRegion).HasColumnName("ST_REGION");
            Property(x => x.StRayon).HasColumnName("ST_RAYON");
            Property(x => x.StViducherejdeniya).HasColumnName("ST_VIDUCHEREJDENIYA");
            Property(x => x.VidGrajdanstvo).HasColumnName("VID_GRAJDANSTVO");
            Property(x => x.Vozrost).HasColumnName("VOZROST");
            Property(x => x.DetiKol).HasColumnName("DETI_KOL");
            Property(x => x.VidDoljnost).HasColumnName("VID_DOLJNOST");
            Property(x => x.KategoriyaMastera).HasColumnName("KATEGORIYA_MASTERA");
            Property(x => x.VidPrinNaRabotu).HasColumnName("VID_PRIN_NA_RABOTU");
            Property(x => x.NumPrikaza).HasColumnName("NUM_PRIKAZA").HasMaxLength(50);
            Property(x => x.DataPrikaza).HasColumnName("DATA_PRIKAZA");
            Property(x => x.PoShtatu).HasColumnName("PO_SHTATU");
            Property(x => x.ObshiyStaj).HasColumnName("OBSHIY_STAJ");
            Property(x => x.PedStaj).HasColumnName("PED_STAJ");
            Property(x => x.DanDoljStaj).HasColumnName("DAN_DOLJ_STAJ");
            Property(x => x.VidPredOsPredmet).HasColumnName("VID_PRED_OS_PREDMET");
            Property(x => x.NaimPredOsPredmet).HasColumnName("NAIM_PRED_OS_PREDMET");
            Property(x => x.YazikOsPrepodaet).HasColumnName("YAZIK_OS_PREPODAET");
            Property(x => x.SpecOsPredmet).HasColumnName("SPEC_OS_PREDMET");
            Property(x => x.VidPredDpPredmet).HasColumnName("VID_PRED_DP_PREDMET");
            Property(x => x.NaimPredDpPredmet).HasColumnName("NAIM_PRED_DP_PREDMET");
            Property(x => x.YazikDpPrepodaet).HasColumnName("YAZIK_DP_PREPODAET");
            Property(x => x.SpecDpPredmet).HasColumnName("SPEC_DP_PREDMET");
            Property(x => x.KolChasPredOsPredmet).HasColumnName("KOL_CHAS_PRED_OS_PREDMET").HasPrecision(3, 2);
            Property(x => x.KolChasPredDpPredmet).HasColumnName("KOL_CHAS_PRED_DP_PREDMET").HasPrecision(3, 2);
            Property(x => x.VsegoKolChasov).HasColumnName("VSEGO_KOL_CHASOV");
            Property(x => x.PedObraz).HasColumnName("PED_OBRAZ");
            Property(x => x.PedPerepod).HasColumnName("PED_PEREPOD");
            Property(x => x.PedPerepodGde).HasColumnName("PED_PEREPOD_GDE");
            Property(x => x.DataPedPerepod).HasColumnName("DATA_PED_PEREPOD");
            Property(x => x.NumdiplomPedPere).HasColumnName("NUMDIPLOM_PED_PERE").HasMaxLength(50);
            Property(x => x.PrivlechenieAttectac).HasColumnName("PRIVLECHENIE_ATTECTAC");
            Property(x => x.DataPosledAttectac).HasColumnName("DATA_POSLED_ATTECTAC");
            Property(x => x.ResAttectac).HasColumnName("RES_ATTECTAC");
            Property(x => x.DoljnostAttectac).HasColumnName("DOLJNOST_ATTECTAC");
            Property(x => x.PrichiniNePrivAttectac).HasColumnName("PRICHINI_NE_PRIV_ATTECTAC");
            Property(x => x.InostYazik).HasColumnName("INOST_YAZIK").HasMaxLength(50);
            Property(x => x.ZanyaKomputera).HasColumnName("ZANYA_KOMPUTERA");
            Property(x => x.DanniyOtchPeriode).HasColumnName("DANNIY_OTCH_PERIODE");
            Property(x => x.Prichina).HasColumnName("PRICHINA").HasMaxLength(300);
            Property(x => x.StavkaCha).HasColumnName("STAVKA_CHAS").HasPrecision(15, 2);
            Property(x => x.Toifa).HasColumnName("TOIFA");
            Property(x => x.Kolorlic).HasColumnName("KOLORLIC");
            Property(x => x.QishloqPropiskaRu).HasColumnName("QISHLOQ_PROPISKA_RU").HasMaxLength(150);
            Property(x => x.KuchaPropiskaRu).HasColumnName("KUCHA_PROPISKA_RU").HasMaxLength(100);
            Property(x => x.UyPropiskaRu).HasColumnName("UY_PROPISKA_RU").HasMaxLength(150);
            Property(x => x.HonadonPropiskaRu).HasColumnName("HONADON_PROPISKA_RU").HasMaxLength(10);
            Property(x => x.CworkdepartRu).HasColumnName("CWORKDEPART_RU").HasMaxLength(300);
            Property(x => x.ObjworkplaceRu).HasColumnName("OBJWORKPLACE_RU").HasMaxLength(300);
            Property(x => x.WorkphoneRu).HasColumnName("WORKPHONE_RU").HasMaxLength(100);
            Property(x => x.HomephoneRu).HasColumnName("HOMEPHONE_RU").HasMaxLength(25);
            Property(x => x.CellphoneRu).HasColumnName("CELLPHONE_RU").HasMaxLength(25);
            Property(x => x.FaxnumberRu).HasColumnName("FAXNUMBER_RU").HasMaxLength(25);
            Property(x => x.PassGivenbyRu).HasColumnName("PASS_GIVENBY_RU").HasMaxLength(150);
            Property(x => x.SudimostRodstRu).HasColumnName("SUDIMOST_RODST_RU").HasMaxLength(250);
            Property(x => x.PrichinaRu).HasColumnName("PRICHINA_RU").HasMaxLength(300);
            Property(x => x.DpInfo).HasColumnName("DP_INFO").IsMaxLength();
            // Navigation properties
//Foreign key to TBATESTATIYA (Tbatestatiya)
HasMany(x => x.Tbatestatiyas);
//Foreign key to TBDEPUTY (Tbdeputy)
HasMany(x => x.Tbdeputies);
//Foreign key to TBGOSNAGRADI (Tbgosnagradi)
HasMany(x => x.Tbgosnagradis);
//Foreign key to TBMESTORAB (Tbmestorab)
HasMany(x => x.Tbmestorabs);
//Foreign key to TBPOVISHKVAL (Tbpovishkval)
HasMany(x => x.Tbpovishkvals);
//Foreign key to TBQARINDOSH (Tbqarindosh)
HasMany(x => x.Tbqarindoshs);
//Foreign key to TBUNIVER (Tbuniver)
HasMany(x => x.Tbunivers);
        }
    }
}
