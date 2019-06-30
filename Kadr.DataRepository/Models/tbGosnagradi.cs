using System;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbGosnagradi
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
