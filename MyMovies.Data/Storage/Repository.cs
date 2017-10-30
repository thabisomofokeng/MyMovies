using System;
using System.Data.Entity.Migrations;

namespace MyMovies.Data.Storage
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDataContext DataContext;

        public Repository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual T Create(T entity)
        {
            entity = DataContext.DbSet<T>().Add(entity);

            DataContext.SaveChanges();

            return entity;
        }

        public virtual T Get(Guid id)
        {
            return DataContext.DbSet<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            DataContext.DbSet<T>().AddOrUpdate(entity);

            DataContext.SaveChanges();
        }
    }
}
