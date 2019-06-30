using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBPOVISHKVAL table
    /// </summary>
    public class Tbpovishkval
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Date Pk")]
        public DateTime? DatePk { get; set; }

        [Display(Name="Mesto Pk")]
        public int? MestoPk { get; set; }

        [Display(Name="Posledniy Pk")]
        public int? PosledniyPk { get; set; }

        [Display(Name="Num Sertificat")]
        [StringLength(15)]
        public string NumSertificat { get; set; }

        [Display(Name="Srok Paln Pk")]
        public int? SrokPalnPk { get; set; }

        public int? Pedobrazovaniepk { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

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
            var x = obj as Tbpovishkval;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
