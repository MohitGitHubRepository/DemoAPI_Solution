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
            throw new NotImplementedException();
        }
        public LoggedInUserViewModel LoginUser(string UserNameOrPhoneNumber,string Password)
        {
            throw new NotImplementedException();
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

       

        public string UpdateUser(UpdateUserInfoViewModel updateUserDetail,User userDetail )
        {
            try
            {
                UpdateUserInfoMap(updateUserDetail, userDetail);
                this.repository.Edit(userDetail);
                this.repository.Commit();
                return "Details Updted Successfully";

            }
            catch
            {
                throw new Exception("Not Updated");
            }

            

        }

        private static void UpdateUserInfoMap(UpdateUserInfoViewModel updateUserDetail, User userDetail)
        {
            userDetail.FirstName = updateUserDetail.FirstName;
            userDetail.LastName = updateUserDetail.LastName;
            userDetail.MobilePhone = updateUserDetail.MobilePhone;
            userDetail.ModifiedDateTime = DateTime.Now;
            userDetail.Role = updateUserDetail.Role;
            userDetail.UserName = updateUserDetail.UserName;
        }
    }
}
