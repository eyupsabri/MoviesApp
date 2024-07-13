using AutoMapper;
using DAL;
using Entities;
using Entities.Models;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
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

        public async Task<bool> RegisterUser(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            var result = await _userRepo.RegisterUser(entity);
            return result;
        }
    }
}
