using FTEPXW_HFT_2021221.Models;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public interface IDirectorRepository
    {
        void Create(Director dir);
        void Delete(int id);
        Director Read(int id);
        IQueryable<Director> ReadAll();
        void Update(Director dir);
    }
}