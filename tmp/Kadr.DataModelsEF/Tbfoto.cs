using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    /// <summary>
    /// Class representing TBFOTO table
    /// </summary>
    public class Tbfoto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Mainid { get; set; }

        public System.Byte[] Foto { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        public int? Active { get; set; }

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
            var x = obj as Tbfoto;
            if (x == null) return false;
            if (Id == 0 && x.Id == 0) return ReferenceEquals(this, x);
            return (Id == x.Id);

        }
        #endregion
    }
}
