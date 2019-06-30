using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing SA_RODSTVENNIK table
    /// </summary>
    public class SaRodstvennik
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nameuz { get; set; }

        [StringLength(200)]
        public string Nameru { get; set; }

        public int? Active { get; set; }

        public int? State { get; set; }

        public int? Orderindex { get; set; }

        public int? Rdsign { get; set; }

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
            var x = obj as SaRodstvennik;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
