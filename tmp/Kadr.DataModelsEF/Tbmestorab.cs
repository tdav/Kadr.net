using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBMESTORAB table
    /// </summary>
    public class Tbmestorab
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Date 1")]
        [StringLength(4)]
        public string Date1 { get; set; }

        [Display(Name="Date 2")]
        [StringLength(4)]
        public string Date2 { get; set; }

        [StringLength(150)]
        public string Ishjoyi { get; set; }

        public int? Workplace { get; set; }

        [StringLength(500)]
        public string Lavozim { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Ishjoyi Ru")]
        [StringLength(150)]
        public string IshjoyiRu { get; set; }

        [Display(Name="Lavozim Ru")]
        [StringLength(500)]
        public string LavozimRu { get; set; }

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
            var x = obj as Tbmestorab;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
