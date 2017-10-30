namespace MyMovies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EntityFramework.MyMovieDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityFramework.MyMovieDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.DbSet<Movie>().AddOrUpdate(
              m => m.Id,
              new Movie { Id = new Guid("536cc09b-6146-42ca-b5ad-711d3eddc288"), Title = "The Internship", Year = 2013, Director = "Shawn Levy", Actors = "Vince Vaughn, Owen Wilson, Rose Byrne, Aasif Mandvi", Location = "Lounge", CreatedAt = DateTimeOffset.Now },
              new Movie { Id = new Guid("bc2c6db3-163a-4df5-992b-e0643be1cfbc"), Title = "The Social Network", Year = 2014,  Location = @"D:/Movies/the_social_network.mp4", CreatedAt = DateTimeOffset.Now },
              new Movie { Id = new Guid("b3d7320a-ef3b-4cd2-88f2-4a8d2bce416b"), Title = "Jobs", Genre  = "Documentary", Year = 2013, Director = "Joshua Michael Stern", Actors = "Ashton Kutcher, Dermot Mulroney, Josh Gad, Lukas Haas", CreatedAt = DateTimeOffset.Now },
              new Movie { Id = new Guid("65985a91-34ca-4ae4-a3eb-62079d2c3020"), Title = "Star Trek", Genre = "Sci-Fi", Year = 2009, Director = "J.J. Abrams", Actors = "Chris Pine, Zachary Quinto, Simon Pegg, Leonard Nimoy", Location = "-31.564, 147.154", CreatedAt = DateTimeOffset.Now },
              new Movie { Id = new Guid("433409a8-a890-40af-8dfb-2995f6f7d59b"), Title = "The Matrix", Genre = "Sci-Fi", Year = 1999, Director = "The Wachowski Brothers", Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving", CreatedAt = DateTimeOffset.Now }
            );
        }
    }
}
