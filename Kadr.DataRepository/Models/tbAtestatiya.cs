using System;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbAtestatiya
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        public int? PrivlichenYn { get; set; }

        public DateTime? DateAt { get; set; }

        public int? ResultAa { get; set; }

        public int? DoljnostPosle { get; set; }

        [StringLength(500)]
        public string PichinaNePrivlicheniya { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(500)]
        public string PichinaNePrivlicheniyaRu { get; set; }
    }
}
