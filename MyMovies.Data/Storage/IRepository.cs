using System;
using System.Data.Entity;

namespace MyMovies.Data.Storage
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);

        T Get(Guid id);

        void Update(T entity);
    }
}
