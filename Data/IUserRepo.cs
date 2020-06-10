using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPI.Models;

namespace RestAPI.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<String> GetUsers(string[] usersId);
        User GetUserById(int id);
    }
}
