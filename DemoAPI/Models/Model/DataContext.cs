using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.DataAccess.SQL
{
    public class DataContext : DbContext
    {
         

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<User> User { get; set; }
    }
}
