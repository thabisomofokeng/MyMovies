using System.Web;
using MyMovies.Data.EntityFramework;
using MyMovies.Data.Storage;
using MyMovies.Domain;
using Ninject;
using Ninject.Modules;

namespace MyMovies.Web.DependencyInjection
{
    /// <summary>
    /// Factory pattern implementation of the Ninject DI interface.
    /// </summary>
    public class NinjectDependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>()
                .To<MyMovieDataContext>()
                .InTransientScope()
                .WithConstructorArgument("MyMoviesConnection");

            Bind<IMovieRepository>().To<MovieRepository>();
            Bind<IMovieService>().To<MovieService>();
        }
    }
}