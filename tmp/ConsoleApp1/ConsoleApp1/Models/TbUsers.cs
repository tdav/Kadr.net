using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbUsers
    {
        public int Userid { get; set; }

        [StringLength(500)]
        public string Loginname { get; set; }

        [StringLength(500)]
        public string Fullname { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        public DateTime? Lastaccess { get; set; }

        public int? Enabled { get; set; }

        public DateTime? Createddate { get; set; }

        public DateTime? Lastacctime { get; set; }

        public DateTime? Createdtime { get; set; }

        public int? Accesscount { get; set; }

        [StringLength(2)]
        public string Lang { get; set; }

        [StringLength(1000)]
        public string Acsess { get; set; }
    }
}
