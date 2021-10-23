using FTEPXW_HFT_2021221.Models;
using System.Linq;

namespace FTEPXW_HFT_2021221.Repository
{
    public interface IMovieRepository
    {
        void Create(Movie movie);
        void Delete(int id);
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        void Update(Movie movie);
    }
}