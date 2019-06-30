using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBSHAT table
    /// </summary>
    public class Tbshat
    {
        [Key]
        public int Id { get; set; }

        public int? Oblast { get; set; }

        public int? Rayon { get; set; }

        public int? Kolej { get; set; }

        [Display(Name="Kol Cha")]
        [Range(typeof(decimal), "0", "9")]
        public decimal? KolCha { get; set; }

        public int? Doljnost { get; set; }

        public int? Predmet { get; set; }

        public DateTime? Editdate { get; set; }

        public int? State { get; set; }

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
            var x = obj as Tbshat;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
