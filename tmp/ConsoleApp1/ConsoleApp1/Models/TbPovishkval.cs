using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbPovishkval
    {
        public int Id { get; set; }

        public int Mainid { get; set; }

        public DateTime? DatePk { get; set; }

        public int? MestoPk { get; set; }

        public int? PosledniyPk { get; set; }

        [StringLength(15)]
        public string NumSertificat { get; set; }

        public int? SrokPalnPk { get; set; }

        public int? Pedobrazovaniepk { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }
    }
}
