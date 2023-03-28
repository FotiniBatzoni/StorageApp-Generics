using StorageApp.Entities;

namespace StorageApp.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T item);
        T GetById(int id);
        void Remove(T item);
        void Save();
    }
}