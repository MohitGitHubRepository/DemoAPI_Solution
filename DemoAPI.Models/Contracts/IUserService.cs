﻿using DemoAPI.Core.ViewModels.AccountViewModel;
using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAPI.Core.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(string username);
        LoggedInUserViewModel LoginUser(string userId, string password);
        User MapUser(RegisterViewModel username);
        User GetUserByEmail(string userid);
        string CreateUser(User userDetail);
        string UpdateUser(UpdateUserInfoViewModel updatedUserDetail, User userDetail);
    }
}
