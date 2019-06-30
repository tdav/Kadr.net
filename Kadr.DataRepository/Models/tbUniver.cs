using System;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    public partial class tbUniver
    {
        public int Id { get; set; }
        public int Mainid { get; set; }

        [StringLength(4)]
        public string GodVipuska { get; set; }

        public int? ObrazovatelniyUcherj { get; set; }

        [StringLength(400)]
        public string SpecialnostPodiplomu { get; set; }

        public int? VidObucheniya { get; set; }

        public int? ProfesianalObraz { get; set; }

        public int? ObType { get; set; }

        [StringLength(5)]
        public string Seriya { get; set; }

        public int? Num { get; set; }

        public DateTime? Editdate { get; set; }

        public int? Edituser { get; set; }

        [StringLength(400)]
        public string SpecialnostPodiplomuRu { get; set; }
    }
}
