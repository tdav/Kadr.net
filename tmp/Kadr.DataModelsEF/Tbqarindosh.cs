using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBQARINDOSH table
    /// </summary>
    public class Tbqarindosh
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        public int? Qarindoshligi { get; set; }

        [StringLength(4)]
        public string Dataroj { get; set; }

        [StringLength(300)]
        public string Birthcountry { get; set; }

        public int? Country { get; set; }

        public int? Region { get; set; }

        public int? Rayon { get; set; }

        [StringLength(400)]
        public string Yashashjoyi { get; set; }

        [StringLength(400)]
        public string Ishjoyi { get; set; }

        [StringLength(4)]
        public string Death { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [Display(Name="Yashashjoyi Ru")]
        [StringLength(400)]
        public string YashashjoyiRu { get; set; }

        [Display(Name="Ishjoyi Ru")]
        [StringLength(400)]
        public string IshjoyiRu { get; set; }

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
            var x = obj as Tbqarindosh;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
