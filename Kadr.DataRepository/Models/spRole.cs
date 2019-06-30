﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kadr.Models
{
    /// <summary>
    /// таблица Роли пользователь
    /// </summary>
    public partial class spRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string UserAccess { get; set; }

        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }

        [DefaultValue(0)]
        public int Send { get; set; }
        [DefaultValue(0)]
        public int Version { get; set; }

        public spRole()
        {
            Status = 1;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
