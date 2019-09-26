using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> AddNewUser(User user);

        Task<IEnumerable<User>> GetAll();
    }
}
