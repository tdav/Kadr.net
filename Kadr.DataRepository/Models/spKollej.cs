using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class SaKollej
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string NameRu { get; set; }

        [StringLength(500)]
        public string NameUz { get; set; }

        public int? State { get; set; }

        public int? Obl { get; set; }

        [StringLength(100)]
        public string Rayon { get; set; }

        [StringLength(100)]
        public string Turi { get; set; }
    }
}
