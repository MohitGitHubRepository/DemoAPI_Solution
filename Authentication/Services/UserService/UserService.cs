using DemoAPI.Core.Contracts;
using DemoAPI.Core.ViewModels.AccountViewModel;
using DemoAPI.Models;
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
            catch(Exception ex)
            {
                //Exception 
                return "";
            }
        }
        public LoggedInUserViewModel LoginUser(string UserNameOrPhoneNumber,string Password)
        {
            LoggedInUserViewModel loggedInUser = new LoggedInUserViewModel();
            User userbyEmail= GetUserByEmail(UserNameOrPhoneNumber);
            User userbyphone = GetUserByphone(UserNameOrPhoneNumber);
           
            if (!ReferenceEquals(userbyEmail, null))
            {
                if(userbyEmail.Password == Password)
                {
                    MapUserToLoggedInViewModel(loggedInUser, userbyEmail);
                }
            }
            else if(!ReferenceEquals(userbyphone, null))
            {
                if (userbyphone.Password == Password)
                {
                    MapUserToLoggedInViewModel(loggedInUser, userbyphone);
                }

            }

            return loggedInUser;
        }

        private static void MapUserToLoggedInViewModel(LoggedInUserViewModel loggedInUser, User userbyEmail)
        {
            loggedInUser.Email = userbyEmail.Email;
            loggedInUser.FirstName = userbyEmail.FirstName;
            loggedInUser.LastName = userbyEmail.LastName;
            loggedInUser.MobilePhone = userbyEmail.MobilePhone;
            loggedInUser.Role = userbyEmail.Role;
            loggedInUser.UserName = userbyEmail.UserName;
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
            user.ModifiedDateTime = DateTime.Now;
            return user;
        }

       

        public string UpdateUser(UpdateUserInfoViewModel updatedUserDetail, User userDetail)
        {
            throw new NotImplementedException();
        }
    }
}
