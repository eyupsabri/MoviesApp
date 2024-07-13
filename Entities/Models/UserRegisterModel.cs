﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
