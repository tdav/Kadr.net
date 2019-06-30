using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbFoto
    {
        public int Id { get; set; }

        public int Mainid { get; set; }

        public byte[] Foto { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        public int? Active { get; set; }
    }
}
