using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
using System.Collections.Generic;

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


    }
}