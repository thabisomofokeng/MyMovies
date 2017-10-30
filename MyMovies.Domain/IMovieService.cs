using System;
using MyMovies.Data;
using PagedList;

namespace MyMovies.Domain
{
    /// <summary>
    /// Facade interface that defines the attributes and operations
    /// for processing movies domain logic.
    /// </summary>
    public interface IMovieService
    {
        Movie Create(Movie movie);

        Movie Get(Guid movieId);

        void Update(Movie movie);

        void Delete(Guid movieId);

        IPagedList<Movie> Find(string title = null, string genre = null, int? year = null, string director = null, string actor = null, int page = 1, int pageSize = 50);
    }
}
