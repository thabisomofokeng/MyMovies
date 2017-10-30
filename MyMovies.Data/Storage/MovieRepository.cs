using System.Linq;
using PagedList;

namespace MyMovies.Data.Storage
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public IPagedList<Movie> Find(string title, string genre, int? year, string director, string actor, int page, int pageSize)
        {
            IQueryable<Movie> query = DataContext.DbSet<Movie>();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(m => m.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m => m.Genre.Contains(genre));
            }

            if (year.HasValue)
            {
                query = query.Where(m => m.Year == year);
            }

            if (!string.IsNullOrEmpty(director))
            {
                query = query.Where(m => m.Director.Contains(director));
            }

            if (!string.IsNullOrEmpty(actor))
            {
                query = query.Where(m => m.Actors.Contains(actor));
            }

            return query.Where(m => m.DeletedAt == null).OrderByDescending(m => m.CreatedAt)
                .ToPagedList(page, pageSize);
        }
    }
}
