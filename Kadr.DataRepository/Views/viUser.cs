using System;

namespace Kadr.Database.Views
{
    public class viUser
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Login { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Role { get; set; }
        public string UserAccess { get; set; }
    }
}
