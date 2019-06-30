using System;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbQarindosh
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        public int? Qarindoshligi { get; set; }

        [StringLength(4)]
        public string Dataroj { get; set; }

        [StringLength(300)]
        public string Birthcountry { get; set; }

        public int? Country { get; set; }

        public int? Region { get; set; }

        public int? Rayon { get; set; }

        [StringLength(400)]
        public string Yashashjoyi { get; set; }

        [StringLength(400)]
        public string Ishjoyi { get; set; }

        [StringLength(4)]
        public string Death { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(400)]
        public string YashashjoyiRu { get; set; }

        [StringLength(400)]
        public string IshjoyiRu { get; set; }
    }
}
