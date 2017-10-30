using System.Collections.Generic;
using MyMovies.Data;
using PagedList;

namespace MyMovies.Web.Models.Movies
{
    public class MovieListViewModel
    {
        public MovieListViewModel()
        {
            Page = 1;
            PageSize = 10;
        }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int? Year { get; set; }

        public string Director { get; set; }

        public string Actor { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<MovieFilterViewModel> Years { get; set; }

        public IEnumerable<MovieFilterViewModel> Directors { get; set; }

        public IPagedList<Movie> Items { get; set; }
    }
}