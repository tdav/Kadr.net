using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class SaMarried
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string NameUz { get; set; }

        [StringLength(1000)]
        public string NameRu { get; set; }

        public int? Active { get; set; }

        public int? State { get; set; }
    }
}
