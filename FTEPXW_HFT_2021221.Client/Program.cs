using FTEPXW_HFT_2021221.Data;
using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Repository;

using System;


namespace FTEPXW_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {           
            MovieDatabaseContext db = new MovieDatabaseContext();

            IMovieRepository repo = new MovieRepository(db);
            MovieLogic mLog = new MovieLogic(repo);
            
            IProtagonistRepository rep = new ProtagonistRepository(db);
            ProtagonistLogic pLog = new ProtagonistLogic(rep);

            IDirectorRepository repp = new DirectorRepository(db);
            DirectorLogic dLog = new DirectorLogic(repp);

            var q0 = pLog.ReadAll();
            ;
            var q1 = pLog.ProtagonistMoviesCount();
            var q2 = pLog.ProtagonistMoviesCount16HanzZimmer();
            var q3 = dLog.DirectorsMoviesCountandIncome();
            var q4 = dLog.DirectorsGender();
            var q5 = dLog.DirectorsAge();
            ;
            var q6 = mLog.ProtagonistGroup();
            var q7 = mLog.DirectorGroup();
            var q8 = mLog.Genre();
            var q9 = mLog.DirectorGenderGroup();
            var q10 = mLog.ProtagonistAgeGroup();



            ;
           
           
        }
    }
}
