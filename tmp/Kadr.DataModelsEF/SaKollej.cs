using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing SA_KOLLEJ table
    /// </summary>
    public class SaKollej
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nameru { get; set; }

        [StringLength(100)]
        public string Nameuz { get; set; }

        public int? State { get; set; }

        public int? Obl { get; set; }

        [StringLength(100)]
        public string Rayon { get; set; }

        [StringLength(100)]
        public string Turi { get; set; }

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
            var x = obj as SaKollej;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
