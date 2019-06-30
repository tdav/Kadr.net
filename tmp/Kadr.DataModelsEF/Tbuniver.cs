using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBUNIVER table
    /// </summary>
    public class Tbuniver
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="God Vipuska")]
        [StringLength(4)]
        public string GodVipuska { get; set; }

        [Display(Name="Obrazovatelniy Ucherj")]
        public int? ObrazovatelniyUcherj { get; set; }

        [Display(Name="Specialnost Podiplomu")]
        [StringLength(400)]
        public string SpecialnostPodiplomu { get; set; }

        [Display(Name="Vid Obucheniya")]
        public int? VidObucheniya { get; set; }

        [Display(Name="Profesianal Obraz")]
        public int? ProfesianalObraz { get; set; }

        [Display(Name="Ob Type")]
        public int? ObType { get; set; }

        [StringLength(5)]
        public string Seriya { get; set; }

        public int? Num { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Specialnost Podiplomu Ru")]
        [StringLength(400)]
        public string SpecialnostPodiplomuRu { get; set; }

        public virtual Tbmain Main { get; set; }

        #region overrides

        public override string ToString()
        {
            return "[Id] = " + Id;

        }

        public override int GetHashCode()
        {
            if (Id == 0) return base.GetHashCode(); //transient instance
            return Id;

        }

        public override bool Equals(object obj)
        {
            var x = obj as Tbuniver;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
