

using StorageApp.Entities;
using System;
using System.Collections.Generic;

namespace StorageApp.Repositories
{
    public class GenericRepository<T>
    {
        protected readonly List<T> _items = new List<T>();
        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryWithRemove<T> : GenericRepository<T> 
    { 
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}
