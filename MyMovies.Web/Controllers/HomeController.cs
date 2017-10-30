using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using MyMovies.Data;
using MyMovies.Domain;
using MyMovies.Web.Models.Movies;

namespace MyMovies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        /// <summary>
        /// Home constructor uses inversion of control to inject dependencies.
        /// </summary>
        /// <param name="movieService"></param>
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public ActionResult Index(MovieListViewModel model)
        {
            try
            {
                model.Items = _movieService.Find(model.Title, model.Genre, model.Year, model.Director,
                    model.Actor, model.Page, model.PageSize);
                model.Years = model.Items.GroupBy(m => m.Year).Select(m =>
                    new MovieFilterViewModel {Name = m.Key.ToString(), Count = m.Count()}).OrderByDescending(g => g.Name);
                model.Directors = model.Items.GroupBy(m => m.Director)
                    .Select(m => new MovieFilterViewModel {Name = m.Key, Count = m.Count()}).OrderByDescending(g => g.Count);
            }
            catch (SqlException exception)
            {
                // todo: do logging here
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // todo: use object mapper
                    var movie = MapMovie(model);

                    _movieService.Create(movie);

                    return RedirectToAction("Index");
                }
            }
            catch (ArgumentException exception)
            {
                // todo: do logging here
            }
            catch (SqlException exception)
            {
                // todo: do logging here
            }

            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                var movie = _movieService.Get(id);

                if (movie == null)
                {
                    return HttpNotFound();
                }

                // todo: use object mapper
                var model = MapMovieViewModel(movie);

                return View(model);
            }
            catch (ArgumentException exception)
            {
                // todo: do logging here
            }
            catch (SqlException exception)
            {
                // todo: do logging here
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var movie = MapMovie(model);

                    _movieService.Update(movie);

                    return RedirectToAction("Index");
                }
            }
            catch (ArgumentException exception)
            {
                // todo: do logging here
            }
            catch (SqlException exception)
            {
                // todo: do logging here
            }

            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                _movieService.Delete(id);

                return RedirectToAction("Index");
            }
            catch(ArgumentException exception)
            {
                // todo: do logging here
            }
            catch (SqlException exception)
            {
                // todo: do logging here
            }

            return View("Error");
        }

        // todo: use object mapper
        private static Movie MapMovie(MovieViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Genre = model.Genre,
                Year = model.Year,
                Director = model.Director,
                Actors = model.Actors,
                Location = model.Location
            };
        }

        // todo: use object mapper
        private static MovieViewModel MapMovieViewModel(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            return new MovieViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Year = movie.Year,
                Director = movie.Director,
                Actors = movie.Actors,
                Location = movie.Location
            };
        }
    }
}