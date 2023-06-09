﻿

using Microsoft.EntityFrameworkCore;
using StorageApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageApp.Repositories
{

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;

        private readonly DbSet<T> _dbSet;


        public SqlRepository(DbContext dbContext, Action<T> itemAddedCallback = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public event EventHandler<T> ItemAdded;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }


        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
