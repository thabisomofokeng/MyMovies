using System.Data.Entity;

namespace MyMovies.Data.Storage
{
    public interface IDataContext
    {
        IDbSet<T> DbSet<T>() where T: class;

        int SaveChanges();
    }
}
