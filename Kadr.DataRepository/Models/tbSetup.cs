using System;

namespace Kadr.Models
{
    public partial class tbSetup
    {
        public int Id { get; set; }
        public Int64 EKIH { get; set; }
        public int Oblast { get; set; }
        public int Rayon { get; set; }
        public int Turi { get; set; }
        public int Ucherejdeniya { get; set; }
        public int DivisionId { get; set; }
    }
}
