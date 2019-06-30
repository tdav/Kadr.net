using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadr.Models
{
    public partial class TbShat
    {
        public int Id { get; set; }
        public int? Oblast { get; set; }
        public int? Rayon { get; set; }
        public int? Kolej { get; set; }
        public decimal? KolChas { get; set; }
        public int? Doljnost { get; set; }
        public int? Predmet { get; set; }
        public DateTime? Editdate { get; set; }
        public int? State { get; set; }
    }
}
