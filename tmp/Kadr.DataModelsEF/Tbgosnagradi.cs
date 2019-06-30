using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBGOSNAGRADI table
    /// </summary>
    public class Tbgosnagradi
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Date Gn")]
        [StringLength(4)]
        public string DateGn { get; set; }

        [StringLength(400)]
        public string Nazvanie { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Nazvanie Ru")]
        [StringLength(400)]
        public string NazvanieRu { get; set; }

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
            var x = obj as Tbgosnagradi;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
