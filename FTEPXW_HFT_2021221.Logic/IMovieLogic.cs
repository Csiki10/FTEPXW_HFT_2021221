using FTEPXW_HFT_2021221.Models;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie movie);
        void Delete(int id);
        IEnumerable<object> DirectorGenderGroup();
        IEnumerable<object> DirectorGroup();
        IEnumerable<object> Genre();
        IEnumerable<object> ProtagonistAgeGroup();
        IEnumerable<object> ProtagonistGroup();
        Movie Read(int id);
        IEnumerable<Movie> ReadAll();
        void Update(Movie dir);
    }
}