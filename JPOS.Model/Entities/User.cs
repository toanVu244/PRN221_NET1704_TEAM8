﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNum { get; set; }
        public string? Address { get; set; }
        public int RoleID { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public virtual Role? Role { get; set; }
    }
}
