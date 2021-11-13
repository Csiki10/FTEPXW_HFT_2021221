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

            var q1 = pLog.ReadAll();
            ;
            var q2 = pLog.TobbFilmesFerfiKor();
            var q3 = pLog.Oszcar();
            ;
            var q4 = mLog.MufajCsoportositas();
            var q5 = mLog.Mindenes();
            //var q6 = dLog.DirectorsGroupMovieCountGender();
            ;

            
            
        }
    }
}
