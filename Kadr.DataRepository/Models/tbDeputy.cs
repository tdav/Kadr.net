using System;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbDeputy
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
