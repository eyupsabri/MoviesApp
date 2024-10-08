﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepository
    {
        public Task<User> GetUserByEmail(string email);
        public Task<bool> RegisterUser(User user);
    }
}
