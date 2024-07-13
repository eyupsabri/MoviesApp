using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IUserService
    {
        public Task<User> AuthenticateUser(string email, string password);
        public Task<User> GetUserByEmail(string email);
        public Task<bool> RegisterUser(UserModel user);
    }
}
