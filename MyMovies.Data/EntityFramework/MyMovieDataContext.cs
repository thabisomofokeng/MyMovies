using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using MyMovies.Data.Storage;

namespace MyMovies.Data.EntityFramework
{
    public class MyMovieDataContext : DbContext, IDataContext
    {
        public IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public MyMovieDataContext() : base("MyMoviesConnection")
        {
        }

        public MyMovieDataContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
