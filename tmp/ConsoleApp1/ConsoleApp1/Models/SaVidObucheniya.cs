using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class SaVidObucheniya
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string NameUz { get; set; }

        [StringLength(500)]
        public string NameRu { get; set; }

        public int? State { get; set; }
    }
}
