using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FTEPXW_HFT_2021221.Logic
{
    public class MovieLogic
    {
        IMovieRepository movieRepo;
        public MovieLogic(IMovieRepository movieRepo)
        {
            this.movieRepo = movieRepo;
        }
        // CRUD
        public void Create(Movie movie)
        {
            movieRepo.Create(movie);
        }
        public Movie Read(int id)
        {
            return movieRepo.Read(id);
        }
        public IEnumerable<Movie> ReadAll()
        {
            return movieRepo.ReadAll();
        }
        public void Delete(int id)
        {
            movieRepo.Delete(id);
        }
        public void Update(Movie dir)
        {
            movieRepo.Update(dir);
        }

        // TODO
        // NONCRUD
        public IQueryable MufajCsoportositas()
        {
            var q1 = from x in movieRepo.ReadAll()
                     group x by x.Genre into g
                     orderby g.Key
                     select new
                     {
                         _KEY = g.Key,
                         _MONEY = g.Sum(t => t.Income),
                         _AVARAGEBUDGET = g.Average(t => t.Budget)
                     };
            ;

            //bef
            return q1;
        }

        public IQueryable Mindenes()
        {
            var q5 = from x in movieRepo.ReadAll()
                     where x.RunningTime > 100 &&
                     x.Genre == "Drama" &&
                     x.AgeLimit >= 12
                     select new
                     {
                         _NAME = x.Name,
                         _GENRE = x.Genre,
                         _AGELIMIT = x.AgeLimit,
                         _RUNTIMA = x.RunningTime
                     };



            return q5;
        }


    }
}