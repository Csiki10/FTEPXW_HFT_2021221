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
            if (movie != null)
            {
                if (movie.Name != ""&& movie.Protagonist != null)
                {                    
                    movieRepo.Create(movie);
                }
                else
                {
                    throw new Exception();
                }              
            }
            else
            {
                throw new Exception();
            }
            
        }
        public Movie Read(int id)
        {
            if (id >= 0)
            {
                return movieRepo.Read(id);
            }
            else
            {
                throw new Exception();
            }
            
        }
        public IEnumerable<Movie> ReadAll()
        {
            return movieRepo.ReadAll();
        }
        public void Delete(int id)
        {
            if (id >= 0)
            {
                movieRepo.Delete(id);
            }
            else
            {
                throw new Exception();
            }
            
        }
        public void Update(Movie dir)
        {
            movieRepo.Update(dir);
        }

        // TODO
        // NONCRUD
        public IEnumerable<object> ProtagonistGroup()
        {
            var q = from x in movieRepo.ReadAll().Select(t => t.Protagonist)
                    group x by x.Name into g
                    select new
                    {
                        _NAME = g.Key,
                        _COUNT = g.Count(),
                       
                    };

            return q;
        }
        public IEnumerable<object> DirectorGroup()
        {
            var q = from x in movieRepo.ReadAll().Select(d => d.Director)
                    group x by x.Name into g
                    select new
                    {
                        _NAME = g.Key,
                        _COUNT = g.Count(),

                    };



            return q;
        }
        public IEnumerable<object> Genre()
        {
            var q = from x in movieRepo.ReadAll()
                    group x by x.Genre into g
                    select new
                    {
                        _GENRE = g.Key,
                        _COUNT = g.Count(),
                        _C = g.Sum(f => f.Income),
                    };

            return q;
        }
        public IEnumerable<object> DirectorGenderGroup()
        {
            var q = from x in movieRepo.ReadAll().Select(r => r.Director)
                    group x by x.Gender into g
                    select new
                    {
                        _GENDER = g.Key,
                        _COUNT = g.Count()
                    };

            return q;
        }
        public IEnumerable<object> ProtagonistAgeGroup()
        {
            var q = from x in movieRepo.ReadAll().Select(f => f.Protagonist)
                    group x by x.Age into g
                    select new
                    {
                        _GENDER = g.Key,
                        _COUNT = g.Count()
                    };

            return q;
        }


    }
}