using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbMestorab
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        [StringLength(4)]
        public string Date1 { get; set; }

        [StringLength(4)]
        public string Date2 { get; set; }

        [StringLength(150)]
        public string Ishjoyi { get; set; }

        public int? Workplace { get; set; }

        [StringLength(500)]
        public string Lavozim { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(150)]
        public string IshjoyiRu { get; set; }

        [StringLength(500)]
        public string LavozimRu { get; set; }
    }
}
