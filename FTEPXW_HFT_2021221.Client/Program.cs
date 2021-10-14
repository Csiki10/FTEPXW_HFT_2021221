using FTEPXW_HFT_2021221.Data;
using System;
using System.Linq;



namespace FTEPXW_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieDatabaseContext db = new MovieDatabaseContext();           
            ;
            var q1 = db.Directors.Select(r => r.Name);
            ;   


            Console.WriteLine("Hello World!");
        }
    }
}
