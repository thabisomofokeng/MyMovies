using System;
using MyMovies.Data;
using MyMovies.Data.Storage;
using PagedList;

namespace MyMovies.Domain
{
    /// <summary>
    /// Facade implementation of the movies domain logic.
    /// Single Responsiblity Pattern implementation for movie CRUD operations.
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly IValidation<Movie> _validation;

        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _validation = new MovieValidation();
            _movieRepository = movieRepository;
        }

        public Movie Create(Movie movie)
        {
            _validation.Validate(movie);

            movie.Id = Guid.NewGuid();
            movie.CreatedAt = DateTimeOffset.Now;

            _movieRepository.Create(movie);

            return movie;
        }

        public Movie Get(Guid movieId)
        {
            if (movieId == null)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return _movieRepository.Get(movieId);
        }

        public void Update(Movie movie)
        {
            _validation.Validate(movie);

            var originalMovie = _movieRepository.Get(movie.Id);

            if (originalMovie == null)
            {
                throw new ArgumentException($"Specified movie '{movie.Id}' does not exist", nameof(movie.Id));
            }

            movie.CreatedAt = originalMovie.CreatedAt;
            movie.UpdatedAt = DateTimeOffset.Now;

            _movieRepository.Update(movie);
        }

        public void Delete(Guid movieId)
        {
            if (movieId == null)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            var movie = _movieRepository.Get(movieId);

            movie.DeletedAt = DateTimeOffset.Now;

            _movieRepository.Update(movie);
        }

        public IPagedList<Movie> Find(string title, string genre, int? year, string director, string actor, int page, int pageSize)
        {
            return _movieRepository.Find(title, genre, year, director, actor, page, pageSize);
        }
    }
}
