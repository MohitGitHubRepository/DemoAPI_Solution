using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAPI.Services.UserService
{
    public class UserService : IUserService
    {
        IRepository<User> repository;

        public UserService(IRepository<User> Repository)
        {
            this.repository = Repository;
        }

        public string CreateUser(User user)
        {
            try
            {
                User userByEmail = this.GetUserByEmail(user.Email);
                User userbyPhone = GetUserByphone(user.MobilePhone);
                if (userByEmail == null && userbyPhone==null)
                {
                    repository.Insert(user);
                    repository.Commit();
                    return "Details saved successfully";
                }
                else
                {
                    //Exception
                    return "Email Id or phone number already registered";
                }
             
            }
            catch
            {
                //Exception 
                return "";
            }
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string userid)
        {
            IQueryable<User> users = GetUsers();
            return users.Where(a => a.Email == userid).FirstOrDefault();
        }
        public User GetUserByphone(string phone)
        {
            IQueryable<User> users = GetUsers();
            return users.Where(a => a.MobilePhone == phone).FirstOrDefault();
        }
        public IQueryable<User> GetUsers()
        {
            return repository.Collection();
        }

        public User MapUser(RegisterViewModel registerViewModel)
        {
            User user = new User();
            user.Email = registerViewModel.Email;
            user.MobilePhone = registerViewModel.MobilePhone;
            user.Password = registerViewModel.Password;
            return user;
        }

        public string UpdateUser(User userDetail)
        {
            throw new NotImplementedException();
        }
    }
}
