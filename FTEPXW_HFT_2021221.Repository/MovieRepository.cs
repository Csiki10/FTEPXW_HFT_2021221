using FTEPXW_HFT_2021221.Data;
using FTEPXW_HFT_2021221.Models;
using System;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieDatabaseContext db;
        public MovieRepository(MovieDatabaseContext db)
        {
            this.db = db;
        }
        // CRUD
        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();

        }
        public Movie Read(int id)
        {
            return db.Movies.FirstOrDefault(a => a.MovieID == id);
        }
        public IQueryable<Movie> ReadAll()
        {
            return db.Movies;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Movie movie)
        {
            var old = Read(movie.ProtagonistID);
            old.Name = movie.Name;
            old.Music = movie.Music;
            old.RunningTime = movie.RunningTime;
            old.Budget = movie.Budget;
            old.Genre = movie.Genre;
            old.AgeLimit = movie.AgeLimit;
            old.Income = movie.Income;
            db.SaveChanges();
        }
    }
}