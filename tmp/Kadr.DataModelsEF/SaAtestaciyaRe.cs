using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing SA_ATESTACIYA_RES table
    /// </summary>
    public class SaAtestaciyaRe
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nameuz { get; set; }

        [StringLength(50)]
        public string Nameru { get; set; }

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
            var x = obj as SaAtestaciyaRe;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
