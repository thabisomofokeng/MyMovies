using System;
using MyMovies.Data;

namespace MyMovies.Domain
{
    public class MovieValidation : IValidation<Movie>
    {
        public void Validate(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
        }
    }
}
