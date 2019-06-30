using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBMAIN table
    /// </summary>
    public class Tbmain
    {

        public Tbmain()
        {
            Tbatestatiyas = new List<Tbatestatiya>();
            Tbdeputies = new List<Tbdeputy>();
            Tbgosnagradis = new List<Tbgosnagradi>();
            Tbmestorabs = new List<Tbmestorab>();
            Tbpovishkvals = new List<Tbpovishkval>();
            Tbqarindoshs = new List<Tbqarindosh>();
            Tbunivers = new List<Tbuniver>();
        }
        
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Display(Name="Fio Rel")]
        [StringLength(200)]
        public string FioRel { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? Birthcountry { get; set; }

        public int? Birthregion { get; set; }

        public int? Birthtown { get; set; }

        public int? Nationality { get; set; }

        public int? Post { get; set; }

        public int? Sex { get; set; }

        [StringLength(2)]
        public string Objlang { get; set; }

        public int? Married { get; set; }

        [StringLength(150)]
        public string Lang { get; set; }

        public int? Stateprize { get; set; }

        [Display(Name="Contry Propiska")]
        public int? ContryPropiska { get; set; }

        [Display(Name="Region Propiska")]
        public int? RegionPropiska { get; set; }

        [Display(Name="Rayon Propiska")]
        public int? RayonPropiska { get; set; }

        [Display(Name="Qishloq Propiska")]
        [StringLength(150)]
        public string QishloqPropiska { get; set; }

        [Display(Name="Kucha Propiska")]
        [StringLength(100)]
        public string KuchaPropiska { get; set; }

        [Display(Name="Uy Propiska")]
        [StringLength(150)]
        public string UyPropiska { get; set; }

        [Display(Name="Honadon Propiska")]
        [StringLength(10)]
        public string HonadonPropiska { get; set; }

        public DateTime? Cworkdate { get; set; }

        public DateTime? Cworkleavedate { get; set; }

        public int? Cworkplace { get; set; }

        [StringLength(300)]
        public string Cworkdepart { get; set; }

        [StringLength(300)]
        public string Objworkplace { get; set; }

        [StringLength(100)]
        public string Workphone { get; set; }

        [StringLength(25)]
        public string Homephone { get; set; }

        [StringLength(25)]
        public string Cellphone { get; set; }

        [StringLength(25)]
        public string Faxnumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name="Pass Sery")]
        [StringLength(10)]
        public string PassSery { get; set; }

        [Display(Name="Pass Number")]
        [StringLength(20)]
        public string PassNumber { get; set; }

        [Display(Name="Pass Givendate")]
        public DateTime? PassGivendate { get; set; }

        [Display(Name="Pass Givenby")]
        [StringLength(150)]
        public string PassGivenby { get; set; }

        public int? Party { get; set; }

        public int? Education { get; set; }

        public int? Vuz { get; set; }

        public int? Speciality { get; set; }

        public int? Scstatus { get; set; }

        [StringLength(250)]
        public string Scdegree { get; set; }

        public int? Service { get; set; }

        public int? Zvanie { get; set; }

        [Display(Name="Sudimost Rodst")]
        [StringLength(250)]
        public string SudimostRodst { get; set; }

        [StringLength(20)]
        public string Cardnum { get; set; }

        public DateTime? Editdate { get; set; }

        public DateTime? Createdate { get; set; }

        public int? Edituser { get; set; }

        public int? Createuser { get; set; }

        public int? Active { get; set; }

        public int? Cardstate { get; set; }

        [Display(Name="St Region")]
        public int? StRegion { get; set; }

        [Display(Name="St Rayon")]
        public int? StRayon { get; set; }

        [Display(Name="St Viducherejdeniya")]
        public int? StViducherejdeniya { get; set; }

        [Display(Name="Vid Grajdanstvo")]
        public int? VidGrajdanstvo { get; set; }

        public int? Vozrost { get; set; }

        [Display(Name="Deti Kol")]
        public int? DetiKol { get; set; }

        [Display(Name="Vid Doljnost")]
        public int? VidDoljnost { get; set; }

        [Display(Name="Kategoriya Mastera")]
        public int? KategoriyaMastera { get; set; }

        [Display(Name="Vid Prin Na Rabotu")]
        public int? VidPrinNaRabotu { get; set; }

        [Display(Name="Num Prikaza")]
        [StringLength(50)]
        public string NumPrikaza { get; set; }

        [Display(Name="Data Prikaza")]
        public DateTime? DataPrikaza { get; set; }

        [Display(Name="Po Shtatu")]
        public int? PoShtatu { get; set; }

        [Display(Name="Obshiy Staj")]
        public int? ObshiyStaj { get; set; }

        [Display(Name="Ped Staj")]
        public int? PedStaj { get; set; }

        [Display(Name="Dan Dolj Staj")]
        public int? DanDoljStaj { get; set; }

        [Display(Name="Vid Pred Os Predmet")]
        public int? VidPredOsPredmet { get; set; }

        [Display(Name="Naim Pred Os Predmet")]
        public int? NaimPredOsPredmet { get; set; }

        [Display(Name="Yazik Os Prepodaet")]
        public int? YazikOsPrepodaet { get; set; }

        [Display(Name="Spec Os Predmet")]
        public int? SpecOsPredmet { get; set; }

        [Display(Name="Vid Pred Dp Predmet")]
        public int? VidPredDpPredmet { get; set; }

        [Display(Name="Naim Pred Dp Predmet")]
        public int? NaimPredDpPredmet { get; set; }

        [Display(Name="Yazik Dp Prepodaet")]
        public int? YazikDpPrepodaet { get; set; }

        [Display(Name="Spec Dp Predmet")]
        public int? SpecDpPredmet { get; set; }

        [Display(Name="Kol Chas Pred Os Predmet")]
        [Range(typeof(decimal), "0", "9")]
        public decimal? KolChasPredOsPredmet { get; set; }

        [Display(Name="Kol Chas Pred Dp Predmet")]
        [Range(typeof(decimal), "0", "9")]
        public decimal? KolChasPredDpPredmet { get; set; }

        [Display(Name="Vsego Kol Chasov")]
        public int? VsegoKolChasov { get; set; }

        [Display(Name="Ped Obraz")]
        public int? PedObraz { get; set; }

        [Display(Name="Ped Perepod")]
        public int? PedPerepod { get; set; }

        [Display(Name="Ped Perepod Gde")]
        public int? PedPerepodGde { get; set; }

        [Display(Name="Data Ped Perepod")]
        public DateTime? DataPedPerepod { get; set; }

        [Display(Name="Numdiplom Ped Pere")]
        [StringLength(50)]
        public string NumdiplomPedPere { get; set; }

        [Display(Name="Privlechenie Attectac")]
        public int? PrivlechenieAttectac { get; set; }

        [Display(Name="Data Posled Attectac")]
        public int? DataPosledAttectac { get; set; }

        [Display(Name="Res Attectac")]
        public int? ResAttectac { get; set; }

        [Display(Name="Doljnost Attectac")]
        public int? DoljnostAttectac { get; set; }

        [Display(Name="Prichini Ne Priv Attectac")]
        public int? PrichiniNePrivAttectac { get; set; }

        [Display(Name="Inost Yazik")]
        [StringLength(50)]
        public string InostYazik { get; set; }

        [Display(Name="Zanya Komputera")]
        public int? ZanyaKomputera { get; set; }

        [Display(Name="Danniy Otch Periode")]
        public int? DanniyOtchPeriode { get; set; }

        [StringLength(300)]
        public string Prichina { get; set; }

        [Display(Name="Stavka Cha")]
        [Range(typeof(decimal), "0", "9999999999999")]
        public decimal? StavkaCha { get; set; }

        public int? Toifa { get; set; }

        public int? Kolorlic { get; set; }

        [Display(Name="Qishloq Propiska Ru")]
        [StringLength(150)]
        public string QishloqPropiskaRu { get; set; }

        [Display(Name="Kucha Propiska Ru")]
        [StringLength(100)]
        public string KuchaPropiskaRu { get; set; }

        [Display(Name="Uy Propiska Ru")]
        [StringLength(150)]
        public string UyPropiskaRu { get; set; }

        [Display(Name="Honadon Propiska Ru")]
        [StringLength(10)]
        public string HonadonPropiskaRu { get; set; }

        [Display(Name="Cworkdepart Ru")]
        [StringLength(300)]
        public string CworkdepartRu { get; set; }

        [Display(Name="Objworkplace Ru")]
        [StringLength(300)]
        public string ObjworkplaceRu { get; set; }

        [Display(Name="Workphone Ru")]
        [StringLength(100)]
        public string WorkphoneRu { get; set; }

        [Display(Name="Homephone Ru")]
        [StringLength(25)]
        public string HomephoneRu { get; set; }

        [Display(Name="Cellphone Ru")]
        [StringLength(25)]
        public string CellphoneRu { get; set; }

        [Display(Name="Faxnumber Ru")]
        [StringLength(25)]
        public string FaxnumberRu { get; set; }

        [Display(Name="Pass Givenby Ru")]
        [StringLength(150)]
        public string PassGivenbyRu { get; set; }

        [Display(Name="Sudimost Rodst Ru")]
        [StringLength(250)]
        public string SudimostRodstRu { get; set; }

        [Display(Name="Prichina Ru")]
        [StringLength(300)]
        public string PrichinaRu { get; set; }

        [Display(Name="Dp Info")]
        public string DpInfo { get; set; }

        public virtual ICollection<Tbatestatiya> Tbatestatiyas { get; private set; }

        public virtual ICollection<Tbdeputy> Tbdeputies { get; private set; }

        public virtual ICollection<Tbgosnagradi> Tbgosnagradis { get; private set; }

        public virtual ICollection<Tbmestorab> Tbmestorabs { get; private set; }

        public virtual ICollection<Tbpovishkval> Tbpovishkvals { get; private set; }

        public virtual ICollection<Tbqarindosh> Tbqarindoshs { get; private set; }

        public virtual ICollection<Tbuniver> Tbunivers { get; private set; }

        #region overrides

        public override string ToString()
        {
            return "[Id] = " + Id;

        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Id)) return base.GetHashCode(); //transient instance
            return Id.GetHashCode();

        }

        public override bool Equals(object obj)
        {
            var x = obj as Tbmain;
            if (x == null) return false;
            if (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Id)) return object.ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
