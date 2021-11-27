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
            System.Threading.Thread.Sleep(12000);

            RestService rest = new RestService("http://localhost:44216");

            bool end = false;
            while (end == false)
            {
                Menu();
                Console.Write("\n Choose opcion: ");
                int val = int.Parse(Console.ReadLine());

                if (val == 3)
                {
                    end = true;
                    Console.WriteLine("Succesfull exit! ");
                }
                else if (val == 1)
                {
                    Console.Clear();
                    Tables();
                    Console.Write("\n Choose opcion: ");
                    int val1 = int.Parse(Console.ReadLine());

                    if (val1 == 1) // Movie
                    {
                        Console.Clear();
                        CRUDmethods();

                        Console.Write("\n Choose opcion: ");
                        int val2 = int.Parse(Console.ReadLine());

                        Console.Clear();
                        CRUDOptions(rest, val2);

                    }
                    else if (val1 == 2) // Protagonist
                    {
                        CRUDmethods();

                        Console.WriteLine("\n Choose opcion: ");
                        int val2 = int.Parse(Console.ReadLine());
                    }
                    else if (val1 == 3) // Director
                    {
                        CRUDmethods();

                        Console.WriteLine("\n Choose opcion: ");
                        int val2 = int.Parse(Console.ReadLine());
                    }
                    else // error
                    {
                        end = true;
                        Console.WriteLine("Error, not existing opcion");
                    } 
                }
                else if (val == 2)
                {
                    Console.Clear();
                }
                else
                {
                    end = true;
                    Console.WriteLine("Error, not existing opcion");
                }
            }

            

            ;
        }

        private static void CRUDOptions(RestService rest, int val2)
        {
            switch (val2)
            {
                case 1: // create
                    Movie m = MovieCreator();
                    rest.Put(m, "movie");
                    break;

                case 2: // read
                    Console.WriteLine("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    var res = rest.Get<Movie>(id, "movie");
                    break;

                case 3: // readall
                    var res1 = rest.Get<Movie>("movie");
                    ;
                    break;

                case 4: // update
                    Movie m1 = MovieCreator();
                    rest.Post(m1, "movie");
                    break;

                case 5: // delete
                    Console.WriteLine("Id: ");
                    int id1 = int.Parse(Console.ReadLine());
                    rest.Delete(id1, "movie");
                    break;

                default:
                    Console.WriteLine("Error, not existing opcion");
                    break;
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
                                "Income"
                                };
            Movie m = new Movie();
            Console.WriteLine("Set the movie datas: ");
            foreach (var prop in props)
            {
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
                }
            }
            return m;
        }

        private static void CRUDmethods()
        {
            Console.Clear();
            Console.WriteLine("--- CRUD options -----");
            Console.WriteLine("[1. option] - Create");
            Console.WriteLine("[2. option] - Read");
            Console.WriteLine("[3. option] - Read All");
            Console.WriteLine("[4. option] - Update");
            Console.WriteLine("[5. option] - Delete");
            Console.WriteLine("----------------------");
        }

        private static void Tables()
        {
            Console.WriteLine("----------- Tables -----------");
            Console.WriteLine("[1. option] - Movie");
            Console.WriteLine("[2. option] - Protagonist");
            Console.WriteLine("[3. option] - Director");
            Console.WriteLine("------------------------------");
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------- MENU ---------------");
            Console.WriteLine("[1. option] - CRUD methods");
            Console.WriteLine("[2. option] - NONCRUD methods");
            Console.WriteLine("[3. option] - Exit");
            Console.WriteLine("------------------------------------");
        }
    }
}
