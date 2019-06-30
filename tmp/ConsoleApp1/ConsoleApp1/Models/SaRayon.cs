using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class SaRayon
    {
        public int Id { get; set; }

        public int? Obl { get; set; }

        [StringLength(400)]
        public string NameUz { get; set; }

        [StringLength(400)]
        public string NameRu { get; set; }

        public int? Active { get; set; }
        public int? State { get; set; }
    }
}
