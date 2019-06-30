using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbDbstruct
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TABLENAME { get; set; }

        [StringLength(50)]
        public string FIELDNAME { get; set; }

        [StringLength(10)]
        public string FIELDTYPE { get; set; }

        [StringLength(500)]
        public string DISPLAYNAMERU { get; set; }

        [StringLength(500)]
        public string DISPLAYNAMEUZ { get; set; }

        [StringLength(50)]
        public string SPTTABLE { get; set; }

        [StringLength(50)]
        public string SPTKOD { get; set; }

        [StringLength(50)]
        public string SPTLIST { get; set; }

        [StringLength(500)]
        public string OPERAT { get; set; }

        [StringLength(500)]
        public string VAL { get; set; }

        public int? ORDERINDEX { get; set; }


      
    }
}
