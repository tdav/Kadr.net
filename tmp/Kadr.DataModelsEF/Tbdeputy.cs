using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBDEPUTY table
    /// </summary>
    public class Tbdeputy
    {
        [Key]
        public int Id { get; set; }

        [StringLength(600)]
        public string Deputy { get; set; }

        [Display(Name="Date 1")]
        [StringLength(4)]
        public string Date1 { get; set; }

        [Display(Name="Date 2")]
        [StringLength(4)]
        public string Date2 { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Deputy Ru")]
        [StringLength(600)]
        public string DeputyRu { get; set; }

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
            var x = obj as Tbdeputy;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
