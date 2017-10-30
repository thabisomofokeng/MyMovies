using System;

namespace MyMovies.Web.Models.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public string Location { get; set; }
    }
}
