using System.Data.Entity.ModelConfiguration;

namespace MyMovies.Data.EntityFramework
{
    public class MovieEntityConfig : EntityTypeConfiguration<Movie>
    {
        public MovieEntityConfig()
        {
        }
    }
}
