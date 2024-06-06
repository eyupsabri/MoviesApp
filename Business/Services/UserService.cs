using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var user = await _userRepo.GetUserByEmail(email);
            if (user == null)
                return null;

            if (user.Password == password)
                return user;
            else
                return null;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userRepo.GetUserByEmail(email);
            return user;
        }
    }
}
