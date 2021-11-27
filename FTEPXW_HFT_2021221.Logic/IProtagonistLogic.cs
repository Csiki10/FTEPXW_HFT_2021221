using FTEPXW_HFT_2021221.Models;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Logic
{
    public interface IProtagonistLogic
    {
        void Create(Protagonist prot);
        void Delete(int id);
        IEnumerable<object> ProtagonistMoviesCount();
        IEnumerable<object> ProtagonistMoviesCount16HanzZimmer();
        Protagonist Read(int id);
        IEnumerable<Protagonist> ReadAll();
        void Update(Protagonist prot);
    }
}