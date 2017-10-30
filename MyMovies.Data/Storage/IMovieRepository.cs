using PagedList;

namespace MyMovies.Data.Storage
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IPagedList<Movie> Find(string title, string genre, int? year, string director, string actor, int page, int pageSize);
    }
}
