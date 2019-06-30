using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{

    /// <summary>
    /// таблица Пользователи
    /// </summary>
    public partial class tbUser
    {
        public Guid Id { get; set; }
        public int? ServerId { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string FatherName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
        public spRole Role { get; set; }

        [Required]
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }

        [DefaultValue(0)]
        public int Send { get; set; }
        [DefaultValue(0)]
        public int Version { get; set; }

        public tbUser()
        {
            Status = 1;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {FatherName}";
        }

    }
}
