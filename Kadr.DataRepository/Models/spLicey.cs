using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class SaLicey
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string NameRu { get; set; }

        [StringLength(500)]
        public string NameUz { get; set; }

        public int? State { get; set; }
    }
}
