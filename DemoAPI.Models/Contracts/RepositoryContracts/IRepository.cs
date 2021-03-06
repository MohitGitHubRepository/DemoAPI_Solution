﻿using DemoAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAPI.Core.Contracts
{
    public interface IRepository<T> where T:BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(T Item);
        void Edit(T item);
        T Find(string id);
        void Insert(T item);
    }
}
