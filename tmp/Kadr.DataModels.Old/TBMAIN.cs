//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asbt.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBMAIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBMAIN()
        {
            this.TBATESTATIYAs = new HashSet<TBATESTATIYA>();
            this.TBDEPUTies = new HashSet<TBDEPUTY>();
            this.TBFOTOes = new HashSet<TBFOTO>();
            this.TBGOSNAGRADIs = new HashSet<TBGOSNAGRADI>();
            this.TBMESTORABs = new HashSet<TBMESTORAB>();
            this.TBPOVISHKVALs = new HashSet<TBPOVISHKVAL>();
            this.TBQARINDOSHes = new HashSet<TBQARINDOSH>();
            this.TBUNIVERs = new HashSet<TBUNIVER>();
        }
    
        public string ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string PATRONYMIC { get; set; }
        public string FIO_REL { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<int> BIRTHCOUNTRY { get; set; }
        public Nullable<int> BIRTHREGION { get; set; }
        public Nullable<int> BIRTHTOWN { get; set; }
        public Nullable<int> NATIONALITY { get; set; }
        public Nullable<int> POST { get; set; }
        public Nullable<int> SEX { get; set; }
        public string OBJLANG { get; set; }
        public Nullable<int> MARRIED { get; set; }
        public string LANGS { get; set; }
        public Nullable<int> STATEPRIZES { get; set; }
        public Nullable<int> CONTRY_PROPISKA { get; set; }
        public Nullable<int> REGION_PROPISKA { get; set; }
        public Nullable<int> RAYON_PROPISKA { get; set; }
        public string QISHLOQ_PROPISKA { get; set; }
        public string KUCHA_PROPISKA { get; set; }
        public string UY_PROPISKA { get; set; }
        public string HONADON_PROPISKA { get; set; }
        public Nullable<System.DateTime> CWORKDATE { get; set; }
        public Nullable<System.DateTime> CWORKLEAVEDATE { get; set; }
        public Nullable<int> CWORKPLACE { get; set; }
        public string CWORKDEPART { get; set; }
        public string OBJWORKPLACE { get; set; }
        public string WORKPHONE { get; set; }
        public string HOMEPHONE { get; set; }
        public string CELLPHONE { get; set; }
        public string FAXNUMBER { get; set; }
        public string EMAIL { get; set; }
        public string PASS_SERIES { get; set; }
        public string PASS_NUMBER { get; set; }
        public Nullable<System.DateTime> PASS_GIVENDATE { get; set; }
        public string PASS_GIVENBY { get; set; }
        public Nullable<int> PARTY { get; set; }
        public Nullable<int> EDUCATION { get; set; }
        public Nullable<int> VUZ { get; set; }
        public Nullable<int> SPECIALITY { get; set; }
        public Nullable<int> SCSTATUS { get; set; }
        public string SCDEGREE { get; set; }
        public Nullable<int> SERVICE { get; set; }
        public Nullable<int> ZVANIE { get; set; }
        public string SUDIMOST_RODST { get; set; }
        public string TAVSIFNOMA { get; set; }
        public string ADDITIONAL_INFO { get; set; }
        public string CARDNUM { get; set; }
        public Nullable<System.DateTime> EDITDATE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<int> EDITUSER { get; set; }
        public Nullable<int> CREATEUSER { get; set; }
        public Nullable<int> ACTIVE { get; set; }
        public Nullable<int> CARDSTATE { get; set; }
        public Nullable<int> ST_REGION { get; set; }
        public Nullable<int> ST_RAYON { get; set; }
        public Nullable<int> ST_VIDUCHEREJDENIYA { get; set; }
        public Nullable<int> VID_GRAJDANSTVO { get; set; }
        public Nullable<int> VOZROST { get; set; }
        public Nullable<int> DETI_KOL { get; set; }
        public Nullable<int> VID_DOLJNOST { get; set; }
        public Nullable<int> KATEGORIYA_MASTERA { get; set; }
        public Nullable<int> VID_PRIN_NA_RABOTU { get; set; }
        public string NUM_PRIKAZA { get; set; }
        public Nullable<System.DateTime> DATA_PRIKAZA { get; set; }
        public Nullable<int> PO_SHTATU { get; set; }
        public Nullable<int> OBSHIY_STAJ { get; set; }
        public Nullable<int> PED_STAJ { get; set; }
        public Nullable<int> DAN_DOLJ_STAJ { get; set; }
        public Nullable<int> VID_PRED_OS_PREDMET { get; set; }
        public Nullable<int> NAIM_PRED_OS_PREDMET { get; set; }
        public Nullable<int> YAZIK_OS_PREPODAET { get; set; }
        public Nullable<int> SPEC_OS_PREDMET { get; set; }
        public Nullable<int> VID_PRED_DP_PREDMET { get; set; }
        public Nullable<int> NAIM_PRED_DP_PREDMET { get; set; }
        public Nullable<int> YAZIK_DP_PREPODAET { get; set; }
        public Nullable<int> SPEC_DP_PREDMET { get; set; }
        public Nullable<int> VSEGO_KOL_CHASOV { get; set; }
        public Nullable<int> PED_OBRAZ { get; set; }
        public Nullable<int> PED_PEREPOD { get; set; }
        public Nullable<int> PED_PEREPOD_GDE { get; set; }
        public Nullable<System.DateTime> DATA_PED_PEREPOD { get; set; }
        public string NUMDIPLOM_PED_PERE { get; set; }
        public Nullable<int> PRIVLECHENIE_ATTECTAC { get; set; }
        public Nullable<int> DATA_POSLED_ATTECTAC { get; set; }
        public Nullable<int> RES_ATTECTAC { get; set; }
        public Nullable<int> DOLJNOST_ATTECTAC { get; set; }
        public Nullable<int> PRICHINI_NE_PRIV_ATTECTAC { get; set; }
        public Nullable<int> INOST_YAZIK { get; set; }
        public Nullable<int> ZANYA_KOMPUTERA { get; set; }
        public Nullable<int> DANNIY_OTCH_PERIODE { get; set; }
        public Nullable<int> PRICHINA { get; set; }
        public Nullable<decimal> STAVKA_CHAS { get; set; }
        public Nullable<int> TOIFA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBATESTATIYA> TBATESTATIYAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDEPUTY> TBDEPUTies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBFOTO> TBFOTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBGOSNAGRADI> TBGOSNAGRADIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBMESTORAB> TBMESTORABs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBPOVISHKVAL> TBPOVISHKVALs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBQARINDOSH> TBQARINDOSHes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBUNIVER> TBUNIVERs { get; set; }
    }
}