using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBATESTATIYA table
    /// </summary>
    public class Tbatestatiya
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Privlichen Yn")]
        public int? PrivlichenYn { get; set; }

        [Display(Name="Date At")]
        public DateTime? DateAt { get; set; }

        [Display(Name="Result Aa")]
        public int? ResultAa { get; set; }

        [Display(Name="Doljnost Posle")]
        public int? DoljnostPosle { get; set; }

        [Display(Name="Pichina Ne Privlicheniya")]
        [StringLength(500)]
        public string PichinaNePrivlicheniya { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Pichina Ne Privlicheniya Ru")]
        [StringLength(500)]
        public string PichinaNePrivlicheniyaRu { get; set; }

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
            var x = obj as Tbatestatiya;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
