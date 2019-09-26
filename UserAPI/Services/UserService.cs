using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Interfaces.Services;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddNewUser(User user)
        {
            return await _userRepository.AddNewUser(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
    }
}
