using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieShop.Data;

namespace MovieShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            using (context)
            {
                if (context.Director.Any())
                {
                    return;
                }

                context.Director.AddRange(
                    new Director
                    {
                        FirstName = "David",
                        LastName = "Lynch"
                    },
                    new Director
                    {
                        FirstName = "Hideaki",
                        LastName = "Anno"
                    },
                    new Director
                    {
                        FirstName = "Lars",
                        LastName = "Von Trier"
                    }
                    );

                context.Genre.AddRange(
                    new Genre
                    {
                        Name = "Drama"
                    },
                    new Genre
                    {
                        Name = "Horror"
                    },
                    new Genre
                    {
                        Name = "Thriller"
                    },
                    new Genre
                    {
                        Name = "Action"
                    }
                    );

                context.SaveChanges();
          
                context.Movie.AddRange(
                   new Movie
                   {
                       Title = "Shin Gojira",
                       Director = context.Director.Find(2),
                       Genre = context.Genre.Find(2),
                       ReleaseYear = 2016,
                       Price = 125
                   },
                   new Movie
                   {
                       Title = "Blue Velvet",
                       Director = context.Director.Find(1),
                       Genre = context.Genre.Find(3),
                       ReleaseYear = 1986,
                       Price = 50
                   },
                   new Movie
                   {
                       Title = "Twin Peaks: Fire Walk with Me",
                       Director = context.Director.Find(1),
                       Genre = context.Genre.Find(2),
                       ReleaseYear = 1992,
                       Price = 75
                   },
                   new Movie
                   {
                       Title = "Melancholia",
                       Director = context.Director.Find(3),
                       Genre = context.Genre.Find(1),
                       ReleaseYear = 2011,
                       Price = 99
                   },
                   new Movie
                   {
                       Title = "Wild at Heart",
                       Director = context.Director.Find(1),
                       Genre = context.Genre.Find(3),
                       ReleaseYear = 1990,
                       Price = 40
                   },
                   new Movie
                   {
                       Title = "The House That Jack Built",
                       Director = context.Director.Find(3),
                       Genre = context.Genre.Find(1),
                       ReleaseYear = 2018,
                       Price = 150
                   }
                   );

                context.SaveChanges();
            
                context.AddRange(
                    new Copy
                    {
                        Code = "6Blua",
                        Movie = context.Movie.Find(2)
                    },
                    new Copy
                    {
                        Code = "7Blu2",
                        Movie = context.Movie.Find(2)
                    },
                    new Copy
                    {
                        Code = "oTheR",
                        Movie = context.Movie.Find(6)
                    },
                    new Copy
                    {
                        Code = "oShiR",
                        Movie = context.Movie.Find(1)
                    },
                    new Copy
                    {
                        Code = "XTheX",
                        Movie = context.Movie.Find(6)
                    },
                    new Copy
                    {
                        Code = "OTwiN",
                        Movie = context.Movie.Find(3)
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
