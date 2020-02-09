using DemoAPI.Core.Contracts;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.DataAccess.SQL
{
    public class DataContext: DbContext ,IDataContext
    {

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user_table = modelBuilder.Entity<User>();
            user_table
                .ToTable("Users");
            user_table
              .HasKey(n => n.Id);
            user_table
                .Property(n => n.UserName);
            user_table
              .Property(n => n.Email)
              .IsRequired();
            user_table
              .Property(n => n.MobilePhone)
              .IsRequired();
            user_table
                .Property(n => n.Password)
                .IsRequired();
            user_table
                .Property(n => n.FirstName);
            user_table
                .Property(n => n.LastName);
            user_table
                .Property(n => n.Role);
            user_table.Property(t => t.CreatedDateTime).HasColumnType("DateTime");
            user_table.Property(n => n.ModifiedDateTime).HasColumnType("DateTime"); 



        }
    }

}
