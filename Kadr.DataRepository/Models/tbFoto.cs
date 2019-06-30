using System;

namespace Kadr.Models
{
    public partial class tbFoto
    {
        public int Id { get; set; }

        public int Mainid { get; set; }

        public byte[] Foto { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        public int? Active { get; set; }
    }
}
