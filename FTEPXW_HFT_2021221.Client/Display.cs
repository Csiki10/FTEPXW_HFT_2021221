using FTEPXW_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace FTEPXW_HFT_2021221.Client
{
    public static class Display
    {
        public static void CRUDmethods()
        {
            Console.Clear();
            Console.WriteLine("----- CRUD options -----");
            Console.WriteLine(" [1. option] - Create");
            Console.WriteLine(" [2. option] - Read");
            Console.WriteLine(" [3. option] - Read All");
            Console.WriteLine(" [4. option] - Update");
            Console.WriteLine(" [5. option] - Delete");
            Console.WriteLine("------------------------");
        }
        public static void Tables()
        {
            Console.WriteLine("----------- Tables -----------");
            Console.WriteLine(" [1. option] - Movie");
            Console.WriteLine(" [2. option] - Protagonist");
            Console.WriteLine(" [3. option] - Director");
            Console.WriteLine("------------------------------");
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------- MENU ---------------");
            Console.WriteLine(" [1. option] - CRUD methods");
            Console.WriteLine(" [2. option] - NONCRUD methods");
            Console.WriteLine(" [3. option] - Exit");
            Console.WriteLine("------------------------------------");
        }

        public static void NoncurMethods()
        {
            Console.WriteLine("---------------- NONCRUD ----------------");
            Console.WriteLine(" [1. opcion] - ProtagonistGroup");
            Console.WriteLine(" [2. opcion] - ProtagonistAgeGroup");
            Console.WriteLine(" [3. opcion] - DirectorGroup");
            Console.WriteLine(" [4. opcion] - Genre");
            Console.WriteLine(" [5. opcion] - DirectorGenderGroup");
            Console.WriteLine("-----------------------------------------");
        }

        public static void DisplayCreate(string type)
        {
            Console.WriteLine(type+" created succesfully!");
        }
        public static void DisplayUpdate(string type)
        {
            Console.WriteLine(type + " updated succesfully!");
        }
        public static void DisplayDelete(string type)
        {
            Console.WriteLine(type + " deleted succesfully");
        }
        public static void DisplayRead(object o, int type)
        {
            switch (type)
            {
                case 1: // movie
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
                    Movie m = (Movie)o;
                    Console.WriteLine("The movie datas: ");
                    MoviePropDisplay(props, m);                    
                    break;
                case 2: // prot
                    List<string> props1 = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                "Oscar"
                                };
                    Protagonist p = (Protagonist)o;
                    Console.WriteLine("The protagonist datas: ");
                    ProtPropDisplay(props1, p);
                    break;
                case 3: // dir
                    List<string> props2 = new List<string>()
                                {
                                "Name",
                                "Gender",
                                "Age",
                                };
                    Director d = (Director)o;
                    Console.WriteLine("The Directr datas: ");
                    DirPropDisplay(props2, d);
                    break;               
            }          
        }

        private static void MoviePropDisplay(List<string> props,Movie m)
        {
            foreach (var prop in props)
            {
                Console.Write(prop + ": ");

                switch (prop)
                {
                    case "Name":
                        Console.WriteLine(m.Name);
                        break;
                    case "Music":
                        Console.WriteLine(m.Music);
                        break;
                    case "RunningTime":
                        Console.WriteLine(m.RunningTime);
                        break;
                    case "Budget":
                        Console.WriteLine(m.Budget);
                        break;
                    case "Genre":
                        Console.WriteLine(m.Genre);
                        break;
                    case "AgeLimit":
                        Console.WriteLine(m.AgeLimit);
                        break;
                    case "Income":
                        Console.WriteLine(m.Income);
                        break;                     
                    case "ProtagonistID":
                        Console.WriteLine(m.ProtagonistID);
                        break;
                    case "DirectorID":
                        Console.WriteLine(m.DirectorID);
                        break;
                }

            }
        }
        private static void ProtPropDisplay(List<string> props, Protagonist m)
        {
            foreach (var prop in props)
            {
                Console.Write(prop + ": ");

                switch (prop)
                {
                    case "Name":
                        Console.WriteLine(m.Name);
                        break;
                    case "Gender":
                        Console.WriteLine(m.Gender);
                        break;
                    case "Age":
                        Console.WriteLine(m.Age);
                        break;
                    case "Oscar":
                        Console.WriteLine(m.Oscar);
                        break;                 
                }
            }
        }
        private static void DirPropDisplay(List<string> props, Director m)
        {
            foreach (var prop in props)
            {
                Console.Write(prop + ": ");

                switch (prop)
                {
                    case "Name":
                        Console.WriteLine(m.Name);
                        break;
                    case "Gender":
                        Console.WriteLine(m.Gender);
                        break;
                    case "Age":
                        Console.WriteLine(m.Age);
                        break;                   
                }
            }
        }

        public static void MoviePropDisplay(List<string> props, List<Movie> movie)
        {
            foreach (var m in movie)
            {
                foreach(var prop in props)
                {
                    Console.Write(prop + ": ");

                    switch (prop)
                    {
                        case "Name":
                            Console.WriteLine(m.Name);
                            break;
                        case "Music":
                            Console.WriteLine(m.Music);
                            break;
                        case "RunningTime":
                            Console.WriteLine(m.RunningTime);
                            break;
                        case "Budget":
                            Console.WriteLine(m.Budget);
                            break;
                        case "Genre":
                            Console.WriteLine(m.Genre);
                            break;
                        case "AgeLimit":
                            Console.WriteLine(m.AgeLimit);
                            break;
                        case "Income":
                            Console.WriteLine(m.Income);
                            break;
                        case "ProtagonistID":
                            Console.WriteLine(m.ProtagonistID);
                            break;
                        case "DirectorID":
                            Console.WriteLine(m.DirectorID);
                            break;
                    }

                }
                Console.WriteLine();
            }
            
        }
        public static void ProtPropDisplay(List<string> props, List<Protagonist> prot)
        {
            foreach (var m in prot)
            {
                foreach (var prop in props)
                {
                    Console.Write(prop + ": ");

                    switch (prop)
                    {
                        case "Name":
                            Console.WriteLine(m.Name);
                            break;
                        case "Gender":
                            Console.WriteLine(m.Gender);
                            break;
                        case "Age":
                            Console.WriteLine(m.Age);
                            break;
                        case "Oscar":
                            Console.WriteLine(m.Oscar);
                            break;
                    }

                }
                Console.WriteLine();
            }

        }
        public static void DirPropDisplay(List<string> props, List<Director> dir)
        {
            foreach (var m in dir)
            {
                foreach (var prop in props)
                {
                    Console.Write(prop + ": ");

                    switch (prop)
                    {
                        case "Name":
                            Console.WriteLine(m.Name);
                            break;
                        case "Gender":
                            Console.WriteLine(m.Gender);
                            break;
                        case "Age":
                            Console.WriteLine(m.Age);
                            break;
                    }

                }
                Console.WriteLine();
            }

        }
    }
}
