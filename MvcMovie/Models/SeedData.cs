using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

public static class SeedData
{
   public static void Initialize(IServiceProvider serviceProvider)
   {
      using (var context = new MvcMovieContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<MvcMovieContext>>()))
      {
         // Look for any movies.
         if (context.Movie.Any())
         {
            return;   // DB has been seeded
         }

         context.Movie.AddRange(
             new Movie
             {
                Title = "Meet The Mormons",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Documentary",
                Rating = "PG",
                Price = 7.99M,
                ImagePath = "/images/MeetTheMormons.png"
             },
             new Movie
             {
                Title = "Ephram's Rescue",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Drama",
                Rating = "PG",
                Price = 8.99M,
                ImagePath = "/images/EphramsRescue.png"
             },
             new Movie
             {
                Title = "17 Miracles",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Drama",
                Rating = "PG",
                Price = 9.99M,
                ImagePath = "/images/17Miracles.png"
             },
             new Movie
             {
                Title = "The RM",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Comedy",
                Rating = "PG",
                Price = 3.99M,
                ImagePath = "/images/TheRM.png"
             }
         );

         context.SaveChanges();
      }
   }
}
