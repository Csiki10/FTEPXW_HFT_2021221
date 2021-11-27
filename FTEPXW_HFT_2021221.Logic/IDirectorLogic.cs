using FTEPXW_HFT_2021221.Models;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Logic
{
    public interface IDirectorLogic
    {
        void Create(Director dir);
        void Delete(int id);
        IEnumerable<object> DirectorsAge();
        IEnumerable<object> DirectorsGender();
        IEnumerable<object> DirectorsMoviesCountandIncome();
        Director Read(int id);
        IEnumerable<Director> ReadAll();
        void Update(Director dir);
    }
}