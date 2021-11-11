using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUsersById(int id);
        User AddUsers(User user);
        void UpdateUsers(int id, User user);
        void DeleteUsers(int id);

    }
}