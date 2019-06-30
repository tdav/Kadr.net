using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbMain
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Firstname { get; set; }

        [StringLength(500)]
        public string Lastname { get; set; }

        [StringLength(500)]
        public string Patronymic { get; set; }

        [StringLength(500)]
        public string FioRel { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? Birthcountry { get; set; }

        public int? Birthregion { get; set; }

        public int? Birthtown { get; set; }

        public int? Nationality { get; set; }

        public int? Post { get; set; }

        public int? Sex { get; set; }

        public string Objlang { get; set; }

        public int? Married { get; set; }

        [StringLength(150)]
        public string Langs { get; set; }

        public int? Stateprizes { get; set; }

        public int? ContryPropiska { get; set; }

        public int? RegionPropiska { get; set; }

        public int? RayonPropiska { get; set; }

        [StringLength(150)]
        public string QishloqPropiska { get; set; }

        [StringLength(100)]
        public string KuchaPropiska { get; set; }

        [StringLength(150)]
        public string UyPropiska { get; set; }

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

        [StringLength(10)]
        public string PassSeries { get; set; }

        [StringLength(20)]
        public string PassNumber { get; set; }

        public DateTime? PassGivendate { get; set; }

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

        public int? StRegion { get; set; }

        public int? StRayon { get; set; }

        public int? StViducherejdeniya { get; set; }

        public int? VidGrajdanstvo { get; set; }

        public int? Vozrost { get; set; }

        public int? DetiKol { get; set; }

        public int? VidDoljnost { get; set; }

        public int? KategoriyaMastera { get; set; }

        public int? VidPrinNaRabotu { get; set; }

        [StringLength(50)]
        public string NumPrikaza { get; set; }

        public DateTime? DataPrikaza { get; set; }

        public int? PoShtatu { get; set; }

        public int? ObshiyStaj { get; set; }

        public int? PedStaj { get; set; }

        public int? DanDoljStaj { get; set; }

        public int? VidPredOsPredmet { get; set; }

        public int? NaimPredOsPredmet { get; set; }

        public int? YazikOsPrepodaet { get; set; }

        public int? SpecOsPredmet { get; set; }

        public int? VidPredDpPredmet { get; set; }

        public int? NaimPredDpPredmet { get; set; }

        public int? YazikDpPrepodaet { get; set; }

        public int? SpecDpPredmet { get; set; }

        public decimal? KolChasPredOsPredmet { get; set; }

        public decimal? KolChasPredDpPredmet { get; set; }

        public int? VsegoKolChasov { get; set; }

        public int? PedObraz { get; set; }

        public int? PedPerepod { get; set; }

        public int? PedPerepodGde { get; set; }

        public DateTime? DataPedPerepod { get; set; }

        [StringLength(50)]
        public string NumdiplomPedPere { get; set; }

        public int? PrivlechenieAttectac { get; set; }

        public int? DataPosledAttectac { get; set; }

        public int? ResAttectac { get; set; }

        public int? DoljnostAttectac { get; set; }

        public int? PrichiniNePrivAttectac { get; set; }

        [StringLength(50)]
        public string InostYazik { get; set; }

        public int? ZanyaKomputera { get; set; }

        public int? DanniyOtchPeriode { get; set; }

        [StringLength(300)]
        public string Prichina { get; set; }

        public decimal? StavkaChas { get; set; }

        public int? Toifa { get; set; }

        public int? Kolorlic { get; set; }

        [StringLength(150)]
        public string QishloqPropiskaRu { get; set; }

        [StringLength(100)]
        public string KuchaPropiskaRu { get; set; }

        [StringLength(150)]
        public string UyPropiskaRu { get; set; }

        [StringLength(10)]
        public string HonadonPropiskaRu { get; set; }

        [StringLength(300)]
        public string CworkdepartRu { get; set; }

        [StringLength(300)]
        public string ObjworkplaceRu { get; set; }

        [StringLength(100)]
        public string WorkphoneRu { get; set; }

        [StringLength(25)]
        public string HomephoneRu { get; set; }

        [StringLength(25)]
        public string CellphoneRu { get; set; }

        [StringLength(25)]
        public string FaxnumberRu { get; set; }

        [StringLength(150)]
        public string PassGivenbyRu { get; set; }

        [StringLength(250)]
        public string SudimostRodstRu { get; set; }

        [StringLength(300)]
        public string PrichinaRu { get; set; }

        public string DpInfo { get; set; }
    }
}
