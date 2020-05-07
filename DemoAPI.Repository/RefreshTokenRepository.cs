using DemoAPI.DataAccess.SQL;
using Survey.Core.Model;
using Survey.DataAccess.SQL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.DataAccess.SQL
{
    public class RefreshTokenRepository :IRefreshTokenRepository
    {
        IDataContext context;

        public RefreshTokenRepository(DataContext Repository)
        {
            this.context = Repository;
        }

        public string getRefreshToken(string email)
        {
            var user = context.User.FirstOrDefault(a => a.Email == email);
            if (user != null)
            {
                return user.RefreshToken;
            }
            else
            {
                return string.Empty;
            }
        }

        void IRefreshTokenRepository.deleteRefreshToken(string token, string email)
        {
            var user = context.User.FirstOrDefault(a => a.Email == email);
            if (user != null)
            {
                user.RefreshToken = string.Empty;
            }
            context.SaveChanges();
        }

       

        void IRefreshTokenRepository.saveRefreshToken(string token, string email)
        {
            var user = context.User.FirstOrDefault(a => a.Email == email);
            if (user != null)
            {
                user.RefreshToken = token;
            }
            context.SaveChanges();
        }
    }
}
