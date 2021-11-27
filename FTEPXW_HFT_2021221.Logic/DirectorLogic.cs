using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FTEPXW_HFT_2021221.Logic
{
    public class DirectorLogic : IDirectorLogic
    {
        IDirectorRepository dirRepo;
        public DirectorLogic(IDirectorRepository dirRepo)
        {
            this.dirRepo = dirRepo;
        }

        public void Create(Director dir)
        {
            dirRepo.Create(dir);
        }
        public Director Read(int id)
        {
            return dirRepo.Read(id);
        }
        public IEnumerable<Director> ReadAll()
        {
            return dirRepo.ReadAll();
        }
        public void Delete(int id)
        {
            dirRepo.Delete(id);
        }
        public void Update(Director dir)
        {
            dirRepo.Update(dir);
        }

        public IEnumerable<object> DirectorsMoviesCountandIncome()
        {
            var q = from x in dirRepo.ReadAll().SelectMany(t => t.Movies)
                    group x by x.Director.Name into g
                    orderby g.Count() descending
                    select new
                    {
                        _NAME = g.Key,
                        _COUNT = g.Count(),
                        _INCOME = g.Sum(t => t.Income)

                    };


            return q;
        }
        public IEnumerable<object> DirectorsGender()
        {
            var q = from x in dirRepo.ReadAll().SelectMany(t => t.Movies)
                    group x by x.Director.Gender into g
                    select new
                    {
                        _GENDER = g.Key,
                        _COUNT = g.Count(),



                    };

            return q;
        }
        public IEnumerable<object> DirectorsAge()
        {
            var q = from x in dirRepo.ReadAll().SelectMany(t => t.Movies)
                    group x by x.Director.Age into g
                    orderby g.Key descending
                    select new
                    {
                        _AGE = g.Key,
                        _COUNT = g.Count(),
                    };

            return q;
        }
    }
}
