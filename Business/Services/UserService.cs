using AutoMapper;
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
        //private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            //_mapper = mapper;
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

        public async Task<bool> RegisterUser(User user)
        {
            //var entity = _mapper.Map<User>(user);
            var checkUserExist = await GetUserByEmail(user.Email);
            if(checkUserExist == null)
            {
                var result = await _userRepo.RegisterUser(user);
                return result;
            }
            
            return false;
        }
    }
}
