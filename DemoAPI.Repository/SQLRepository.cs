using DemoAPI.Core.Contracts;
using DemoAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbset;
        public SQLRepository(DataContext dataContext)
        {
            context = dataContext;
            this.dbset = context.Set<T>();

        }
        public IQueryable<T> Collection()
        {
            return dbset.AsQueryable();
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Delete(T Item)
        {
            this.dbset.Remove(Item);
        }

        public void Edit(T item)
        {
            var newItem = this.dbset.Where(a => a.Id == item.Id).FirstOrDefault();
            if (newItem != null)
            {
                newItem = item;
            }
        }

        public T Find(string id)
        {
            return this.dbset.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Insert(T item)
        {
            this.dbset.Add(item);
        }
    }
}
