using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> AddNewUser(User user);
    }
}
