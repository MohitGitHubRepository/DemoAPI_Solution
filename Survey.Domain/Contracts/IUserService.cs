using Survey.Core.Model;
using Survey.Core.ViewModels.AccountViewModel;
using System.Linq;

namespace Surve.Domain.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(string username);
        LoggedInUserViewModel LoginUser(string userId, string password);
        User MapUser(RegisterViewModel username);
        User GetUserByEmail(string userid);
        string CreateUser(User userDetail);
        string UpdateUser(User updatedUserDetail, User userDetail);
    }
}
