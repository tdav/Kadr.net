using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing SA_SPECIALITY table
    /// </summary>
    public class SaSpeciality
    {
        [Key]
        public int Id { get; set; }

        [StringLength(400)]
        public string Nameuz { get; set; }

        [StringLength(400)]
        public string Nameru { get; set; }

        public int? Active { get; set; }

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
            var x = obj as SaSpeciality;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
