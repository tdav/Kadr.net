using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbQosnagradi
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        [StringLength(4)]
        public string DateGn { get; set; }

        [StringLength(400)]
        public string Nazvanie { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(400)]
        public string NazvanieRu { get; set; }
    }
}
