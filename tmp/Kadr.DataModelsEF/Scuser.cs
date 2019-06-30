using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing SCUSERS table
    /// </summary>
    public class Scuser
    {
        [Key]
        public int Userid { get; set; }

        [StringLength(50)]
        public string Loginname { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public DateTime? Lastaccess { get; set; }

        public int? Enabled { get; set; }

        public DateTime? Createddate { get; set; }

        public DateTime? Lastacctime { get; set; }

        public DateTime? Createdtime { get; set; }

        public int? Accesscount { get; set; }

        [StringLength(2)]
        public string Lang { get; set; }

        [StringLength(1000)]
        public string Acsess { get; set; }

        #region overrides

        public override string ToString()
        {
            return "[Userid] = " + Userid;

        }

        public override int GetHashCode()
        {
            if (Userid == 0) return base.GetHashCode(); //transient instance
            return Userid;

        }

        public override bool Equals(object obj)
        {
            var x = obj as Scuser;
            if (x == null) return false;
            if (Userid == 0 && x.Userid == 0) return ReferenceEquals(this, x);
            return (Userid == x.Userid);

        }
        #endregion
    }
}
