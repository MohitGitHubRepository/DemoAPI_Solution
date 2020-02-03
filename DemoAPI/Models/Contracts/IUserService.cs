using DemoAPI.Models;
using DemoAPI.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAPI.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(string username);
        User MapUser(RegisterViewModel username);
        User GetUserByEmail(string userid);
        string CreateUser(User userDetail);
        string UpdateUser(User userDetail);
    }
}
