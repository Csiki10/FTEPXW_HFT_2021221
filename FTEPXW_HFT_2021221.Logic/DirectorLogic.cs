using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Logic
{
    public class DirectorLogic
    {
        IDirectorRepository dirRepo;
        public DirectorLogic(IDirectorRepository dirRepo)
        {
            this.dirRepo = dirRepo;
        }
        // CRUD
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

        // TODO
        // NONCRUD


    }
}
