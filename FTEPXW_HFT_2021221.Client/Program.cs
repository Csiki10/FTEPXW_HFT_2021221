using CarDB.Client;
using FTEPXW_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(10000);

            RestService rest = new RestService("http://localhost:44216");

            bool end = false;
            while (end == false)
            {
                Display.Menu(); // menu
                Console.Write("\n Choose opcion: ");
                int menu = int.Parse(Console.ReadLine());
            
                if (menu == 1) // CRUD
                {
                    Console.Clear();
                    Display.Tables(); // 3 table
                    Console.Write("\n Choose opcion: ");
                    int table = int.Parse(Console.ReadLine());

                    switch (table) // 3 table choos (Movie, Prot, Dir)
                    {
                        case 1: // Movie
                            Console.Clear();
                            Display.CRUDmethods(); // CRUDS

                            Console.Write("\n Choose opcion: ");
                            int crud = int.Parse(Console.ReadLine());

                            Console.Clear();
                            CRUDOptions(1, rest, crud);
                            break;
                        case 2: // Prot
                            Display.CRUDmethods();

                            Console.Write("\n Choose opcion: ");
                            int crud1 = int.Parse(Console.ReadLine());

                            Console.Clear();
                            CRUDOptions(2, rest, crud1);
                            break;
                        case 3: // Dir
                            Display.CRUDmethods();

                            Console.Write("\n Choose opcion: ");
                            int crud2 = int.Parse(Console.ReadLine());

                            Console.Clear();
                            CRUDOptions(3, rest, crud2);
                            break;                       
                    }                  
                }
                else if (menu == 2) // NONCRUD
                {
                    Console.Clear();
                    Display.NoncurMethods();
                    Console.Write("\n Choose opcion: ");
                    int crud = int.Parse(Console.ReadLine());

                    switch (crud)
                    {
                        case 1: // ProtagonistGroup
                            var q = rest.GetSingle<IEnumerable<object>>("stat/protagonistGroup");                      
                            foreach (var item in q)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case 2: // ProtagonistAgeGroup
                            var q1 = rest.GetSingle<IEnumerable<object>>("stat/protagonistAgeGroup");
                            foreach (var item in q1)
                            {                              
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case 3: // DirectorGroup
                            var q2 = rest.GetSingle<IEnumerable<object>>("stat/directorGroup");
                            foreach (var item in q2)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case 4: // Genre
                            var q3 = rest.GetSingle<IEnumerable<object>>("stat/genre");
                            foreach (var item in q3)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case 5: // DirectorGenderGroup
                            var q4 = rest.GetSingle<IEnumerable<object>>("stat/directorGenderGroup");
                            foreach (var item in q4)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                else if (menu == 3)
                {
                    end = true;
                    Console.WriteLine(" Succesfull exit! ");
                }
                else
                {
                    end = true;
                    Console.WriteLine("Error, not existing opcion");
                }
            }                      
        }


        private static void CRUDOptions(int type, RestService rest, int crud)
        {
            if (type == 1) // movie
            {
                switch (crud)
                {
                    case 1: // create
                        var m = MovieCreator();
                        ;
                        rest.Post(m,"movie");
                        Display.DisplayCreate("Movie");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();                       
                        break;

                    case 2: // read
                        Console.WriteLine("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var res = rest.Get<Movie>(id, "movie");
                        Display.DisplayRead(res, 1);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();                      
                        break;

                    case 3: // readall
                        var res1 = rest.Get<Movie>("movie");
                        List<string> props = new List<string>()
                                {
                                "Name",
                                "Music",
                                "RunningTime",
                                "Budget",
                                "Genre",
                                "AgeLimit",
                                "Income",
                                "ProtagonistID",
                                "DirectorID"
                                };
                        Display.MoviePropDisplay(props,res1);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 4: // update                  
                        var m1= MovieCreator();
                        rest.Put(m1, "movie");
                        Display.DisplayUpdate("Movie");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 5: // delete
                        Console.WriteLine("Id: ");
                        int id1 = int.Parse(Console.ReadLine());
                        rest.Delete(id1, "movie");
                        Display.DisplayDelete("Movie");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Error, not existing opcion");
                        break;
                }
            }
            else if (type == 2) // prot
            {
                switch (crud)
                {
                    case 1: // create                 
                        var x = ProtagonistrCreator();                      
                        rest.Post(x, "protagonist");
                        Display.DisplayCreate("Protagonist");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 2: // read
                        Console.WriteLine("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var res = rest.Get<Protagonist>(id, "protagonist");
                        Display.DisplayRead(res, 2);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 3: // readall
                        var res1 = rest.Get<Protagonist>("protagonist");
                        List<string> props = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                "Oscar"
                                };
                        Display.ProtPropDisplay(props, res1);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 4: // update                  
                        rest.Put(ProtagonistrCreator(), "protagonist");
                        Display.DisplayUpdate("Protagonist");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 5: // delete
                        Console.WriteLine("Id: ");
                        int id1 = int.Parse(Console.ReadLine());
                        rest.Delete(id1, "protagonist");
                        Display.DisplayDelete("Protagonist");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Error, not existing opcion");
                        break;
                }
            }
            else if (type == 3) // dir
            {
                switch (crud)
                {
                    case 1: // create                 
                        rest.Post(DirectorCreator(), "director");
                        Display.DisplayCreate("Director");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 2: // read
                        Console.WriteLine("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var res = rest.Get<Director>(id, "director");
                        Display.DisplayRead(res, 3);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 3: // readall
                        var res1 = rest.Get<Director>("director");
                        List<string> props = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                };
                        Display.DirPropDisplay(props, res1);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 4: // update                  
                        rest.Put(DirectorCreator(), "director");
                        Display.DisplayUpdate("Director");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 5: // delete
                        Console.WriteLine("Id: ");
                        int id1 = int.Parse(Console.ReadLine());
                        rest.Delete(id1, "director");
                        Display.DisplayDelete("Director");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Error, not existing opcion");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error, not existing opcion");
            }         
        }

        private static Movie  MovieCreator()
        {
            List<string> props = new List<string>()
                                {
                                "Name",
                                "Music",
                                "RunningTime",
                                "Budget",
                                "Genre",
                                "AgeLimit",
                                "Income",
                                "ProtagonistID",
                                "DirectorID"
                                };
            Movie m = new Movie();
            Console.WriteLine("Set the movie datas: ");
            foreach (var prop in props)
            {
                Console.Write(prop+": ");
                switch (prop)
                {                    
                    case "Name":
                        m.Name = Console.ReadLine();
                        break;
                    case "Music":
                        m.Music = Console.ReadLine();
                        break;
                    case "RunningTime":
                        m.RunningTime = int.Parse(Console.ReadLine());
                        break;
                    case "Budget":
                        m.Budget = int.Parse(Console.ReadLine());
                        break;
                    case "Genre":
                        m.Genre = Console.ReadLine();
                        break;
                    case "AgeLimit":
                        m.AgeLimit = int.Parse(Console.ReadLine());
                        break;
                    case "Income":
                        m.Income = int.Parse(Console.ReadLine());
                        break;
                        
                    case "ProtagonistID":
                        m.ProtagonistID = int.Parse(Console.ReadLine());
                        break;
                    case "DirectorID":
                        m.DirectorID = int.Parse(Console.ReadLine());
                        break;
                }             
            }
            return m;
        }       
        private static Protagonist ProtagonistrCreator()
        {
            List<string> props = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                "Oscar"
                                };
            Protagonist d = new Protagonist();
            Console.WriteLine("Set the Protagonist datas: ");
            foreach (var prop in props)
            {
                Console.Write(prop + ": ");
                switch (prop)
                {
                    case "Name":
                        d.Name = Console.ReadLine();
                        break;
                    case "Gender":
                        d.Gender = Console.ReadLine();
                        break;
                    case "Age":
                        d.Age = int.Parse(Console.ReadLine());
                        break;
                    case "Oscar":
                        d.Oscar = Convert.ToBoolean(Console.ReadLine());
                        break;
                }
            }
            return d;
        }
        private static Director DirectorCreator()
        {
            List<string> props = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                };
            Director d = new Director();
            Console.WriteLine("Set the director datas: ");
            foreach (var prop in props)
            {
                Console.Write(prop + ": ");
                switch (prop)
                {
                    case "Name":
                        d.Name = Console.ReadLine();
                        break;
                    case "Gender":
                        d.Gender = Console.ReadLine();
                        break;
                    case "Age":
                        d.Age = int.Parse(Console.ReadLine());
                        break;
                }
            }
            return d;
        }
    }
}
