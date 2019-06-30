using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbDeputy
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        [StringLength(600)]
        public string Deputy { get; set; }

        [StringLength(4)]
        public string Date1 { get; set; }

        [StringLength(4)]
        public string Date2 { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(600)]
        public string DeputyRu { get; set; }
    }
}
