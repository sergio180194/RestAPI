using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class MockUserRepo : IUserRepo
    {
        public User GetUserById(int id)
        {
            return new User { Id = 0, GuId = "50295cef-bfe3-4d8c-8517-46fedac2e620" };
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>
            {
                new User { Id = 0, GuId = "50295cef-bfe3-4d8c-8517-46fedac2e620" },
                new User { Id = 1, GuId = "50295cef-bfe3-4d8c-8517-46fedac2e620" },
                new User { Id = 2, GuId = "50295cef-bfe3-4d8c-8517-46fedac2e620" }
            };
            return users;
        }

        public IEnumerable<string> GetUsers(string[] usersId)
        {
            var guIdUsers = new List<string>
            {
                "50295cef-bfe3-4d8c-8517-46fedac2e620",
                "50295cef-bfe3-4d8c-8517-46fedac2e620",
                "50295cef-bfe3-4d8c-8517-46fedac2e620"
            };
            return guIdUsers;
        }
    }
}
