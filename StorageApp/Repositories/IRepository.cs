﻿using StorageApp.Entities;
using System.Collections;
using System.Collections.Generic;

namespace StorageApp.Repositories
{
    public interface IReadRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IRepository<T> : IReadRepository<T> where T : IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}