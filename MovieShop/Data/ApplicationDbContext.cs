using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models;

namespace MovieShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieShop.Models.Movie> Movie { get; set; }
        public DbSet<MovieShop.Models.Genre> Genre { get; set; }
        public DbSet<MovieShop.Models.Director> Director { get; set; }
        public DbSet<MovieShop.Models.Copy> Copy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(c => c.Copies)
                .WithOne(e => e.Movie);

            modelBuilder.Entity<Movie>()
                .HasOne(c => c.Genre)
                .WithMany(e => e.Movies);

            modelBuilder.Entity<Movie>()
                .HasOne(c => c.Director)
                .WithMany(e => e.Movies);

            base.OnModelCreating(modelBuilder);
        }
    }
}
