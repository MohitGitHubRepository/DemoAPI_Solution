
using Microsoft.EntityFrameworkCore;
using Survey.Core.Model;

namespace Survey.DataAccess.SQL.Contracts
{
    public interface IDataContext
    {
        DbSet<User> User { get; set; }
        DbSet<Survey.Core.Model.Survey> Survey { get; set; }
        int SaveChanges();
         
    }
}
