using FTEPXW_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Data
{
    class MovieDatabaseContext : DbContext
    {
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Protagonist> Protagonists { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        public MovieDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieDatabase.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity
                .HasOne(movie => movie.Protagonist)
                .WithMany(protagonist => protagonist.Movies)
                .HasForeignKey(movie => movie.ProtagonistID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity
                .HasOne(movie => movie.Director)
                .WithMany(director => director.Movies)
                .HasForeignKey(movie => movie.DirectorID)
                .OnDelete(DeleteBehavior.Restrict);
            });




        }


    }
}
