using FTEPXW_HFT_2021221.Models;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public interface IProtagonistRepository
    {
        void Create(Protagonist prot);
        void Delete(int id);
        Protagonist Read(int id);
        IQueryable<Protagonist> ReadAll();
        void Update(Protagonist prot);
    }
}