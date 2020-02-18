using DemoAPI.Core.Model;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.Contracts
{
    public interface IDataContext
    {
        DbSet<User> User { get; set; }
        DbSet<Survey> Survey { get; set; }
        int SaveChanges();
         
    }
}
