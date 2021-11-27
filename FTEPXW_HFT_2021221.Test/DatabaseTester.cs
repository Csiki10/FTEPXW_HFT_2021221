using FTEPXW_HFT_2021221.Logic;
using FTEPXW_HFT_2021221.Models;
using FTEPXW_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Test
{
    [TestFixture]
    class DatabaseTester
    {      
        MovieLogic mLog;

        public DatabaseTester()
        {
            Protagonist matthewmcconaughey = new Protagonist()
            {
                ProtagonistID = 1,
                Name = "Matthew McConaughey",
                Age = 51,
                Gender = "man",
                Oscar = true
            };//2
            Protagonist leonardodicaprio = new Protagonist()
            {
                ProtagonistID = 2,
                Name = "Leonardo DiCaprio",

                Age = 46,
                Gender = "man",
                Oscar = true
            };//2
            Protagonist fionnwhitehead = new Protagonist()
            {
                ProtagonistID = 3,
                Name = "Fionn Whitehead",
                Age = 24,
                Gender = "man",
                Oscar = false
            };
            Protagonist bradleycharlescooper = new Protagonist()
            {
                ProtagonistID = 4,
                Name = "Bradley Charles Cooper",
                Age = 46,
                Gender = "man",
                Oscar = false
            };
            Protagonist timotheechalamet = new Protagonist()
            {
                ProtagonistID = 5,
                Name = "Timothée Chalamet",

                Age = 25,
                Gender = "man",
                Oscar = false
            };//2
            Protagonist tomhanks = new Protagonist()
            {
                ProtagonistID = 6,
                Name = " Tom Hanks",

                Age = 65,
                Gender = "man",
                Oscar = true
            };
            ;
            // ---------------------------------------

            Director robertzemeckis = new Director()
            {
                DirectorID = 1,
                Name = "Robert Zemeckis",
                Age = 69,
                Gender = "man"
            };
            Director christophernolan = new Director()
            {
                DirectorID = 2,
                Name = "Christopher Nolan",
                Age = 51,
                Gender = "man"
            };//3
            Director toddphillips = new Director()
            {
                DirectorID = 3,
                Name = "Todd Phillips",
                Age = 50,
                Gender = "man"
            };
            Director lucaguadagnino = new Director()
            {
                DirectorID = 4,
                Name = "Luca Guadagnino",
                Age = 50,
                Gender = "man"
            };
            Director guyritchie = new Director()
            {
                DirectorID = 5,
                Name = "Guy Ritchie",
                Age = 53,
                Gender = "man"
            };
            Director bazluhrmann = new Director()
            {
                DirectorID = 6,
                Name = "Baz Luhrmann",
                Age = 59,
                Gender = "man"
            };
            Director denisvilleneuve = new Director()
            {
                DirectorID = 7,
                Name = "Denis Villeneuve",
                Age = 54,
                Gender = "man"
            };
            ;
            // ---------------------------------------

            Movie interstellar = new Movie()
            {
                MovieID = 1,
                Name = "Interstellar",
                Music = "Hans Zimmer",
                RunningTime = 169,
                Budget = 165000000,
                Genre = "sci-fi",
                AgeLimit = 12,
                Income = 677463813,
                DirectorID = christophernolan.DirectorID,
                ProtagonistID = matthewmcconaughey.ProtagonistID,
                Director = christophernolan,
                Protagonist = matthewmcconaughey
            };
            Movie inception = new Movie()
            {
                MovieID = 2,
                Name = "Inception",
                Music = "Hans Zimmer",
                RunningTime = 148,
                Budget = 160000000,
                Genre = "drama",
                AgeLimit = 16,
                Income = 160500000,
                DirectorID = christophernolan.DirectorID,
                ProtagonistID = leonardodicaprio.ProtagonistID

            };
            Movie dunkirk = new Movie()
            {
                MovieID = 3,
                Name = "Dunkirk",
                Music = "Hans Zimmer",
                RunningTime = 106,
                Budget = 100000000,
                Genre = "war",
                AgeLimit = 16,
                Income = 526940665,
                DirectorID = christophernolan.DirectorID,
                ProtagonistID = fionnwhitehead.ProtagonistID
            };
            Movie hangover = new Movie()
            {
                MovieID = 4,
                Name = "Hangover",
                Music = "Christophe Beck",
                RunningTime = 100,
                Budget = 35000000,
                Genre = "comedy",
                AgeLimit = 12,
                Income = 467000000,
                DirectorID = toddphillips.DirectorID,
                ProtagonistID = bradleycharlescooper.ProtagonistID
            };
            Movie callmebyyourname = new Movie()
            {
                MovieID = 5,
                Name = "Call me by your name",
                Music = "Sufjan Stevens",
                RunningTime = 132,
                Budget = 3500000,
                Genre = "drama",
                AgeLimit = 16,
                Income = 4190000,
                DirectorID = lucaguadagnino.DirectorID,
                ProtagonistID = timotheechalamet.ProtagonistID
            };
            Movie gentlemen = new Movie()
            {
                MovieID = 6,
                Name = "Gentlemen",
                Music = "Guy Ritchie",
                RunningTime = 113,
                Budget = 22000000,
                Genre = "action",
                AgeLimit = 18,
                Income = 115200000,
                DirectorID = guyritchie.DirectorID,
                ProtagonistID = matthewmcconaughey.ProtagonistID
            };
            Movie thegreatgatsby = new Movie()
            {
                MovieID = 7,
                Name = "The Great Gatsby",
                Music = "Baz Luhrmann",
                RunningTime = 142,
                Budget = 190000000,
                Genre = "drama",
                AgeLimit = 18,
                Income = 353600000,
                DirectorID = bazluhrmann.DirectorID,
                ProtagonistID = leonardodicaprio.ProtagonistID
            };
            Movie forrestgump = new Movie()
            {
                MovieID = 8,
                Name = "Forrest Gump",
                Music = "Alan Silvestri",
                RunningTime = 142,
                Budget = 55000000,
                Genre = "drama",
                AgeLimit = 12,
                Income = 683100000,
                DirectorID = robertzemeckis.DirectorID,
                ProtagonistID = tomhanks.ProtagonistID
            };
            Movie dune = new Movie()
            {
                MovieID = 9,
                Name = "Dune",
                Music = "Hans Zimmer.",
                RunningTime = 155,
                Budget = 165000000,
                Genre = "sci-fi",
                AgeLimit = 16,
                Income = 117600000,
                DirectorID = denisvilleneuve.DirectorID,
                ProtagonistID = timotheechalamet.ProtagonistID
            };

            // ---------------------------------------
            
            var MockMovRepo = new Mock<IMovieRepository>();   
            
            var moviess = new List<Movie>()
            {
                new Movie()
                {
                    MovieID = 1,
                    Name = "Interstellar",
                    Music = "Hans Zimmer",
                    RunningTime = 169,
                    Budget = 165000000,
                    Genre = "sci-fi",
                    AgeLimit = 12,
                    Income = 677463813,
                    DirectorID = christophernolan.DirectorID,
                    ProtagonistID = matthewmcconaughey.ProtagonistID,
                    Director = christophernolan,
                    Protagonist = matthewmcconaughey
                },
                new Movie()
                {
                    MovieID = 2,
                    Name = "Inception",
                    Music = "Hans Zimmer",
                    RunningTime = 148,
                    Budget = 160000000,
                    Genre = "drama",
                    AgeLimit = 16,
                    Income = 160500000,
                    DirectorID = christophernolan.DirectorID,
                    ProtagonistID = leonardodicaprio.ProtagonistID,
                    Director = christophernolan,
                    Protagonist = leonardodicaprio

                },
                new Movie()
                {
                    MovieID = 3,
                    Name = "Dunkirk",
                    Music = "Hans Zimmer",
                    RunningTime = 106,
                    Budget = 100000000,
                    Genre = "war",
                    AgeLimit = 16,
                    Income = 526940665,
                    DirectorID = christophernolan.DirectorID,
                    ProtagonistID = fionnwhitehead.ProtagonistID,
                    Director = christophernolan,
                    Protagonist = fionnwhitehead
                },
                new Movie()
                {
                    MovieID = 4,
                    Name = "Hangover",
                    Music = "Christophe Beck",
                    RunningTime = 100,
                    Budget = 35000000,
                    Genre = "comedy",
                    AgeLimit = 12,
                    Income = 467000000,
                    DirectorID = toddphillips.DirectorID,
                    ProtagonistID = bradleycharlescooper.ProtagonistID,
                    Director = toddphillips,
                    Protagonist = bradleycharlescooper
                },
                new Movie()
                {
                    MovieID = 5,
                    Name = "Call me by your name",
                    Music = "Sufjan Stevens",
                    RunningTime = 132,
                    Budget = 3500000,
                    Genre = "drama",
                    AgeLimit = 16,
                    Income = 4190000,
                    DirectorID = lucaguadagnino.DirectorID,
                    ProtagonistID = timotheechalamet.ProtagonistID,
                    Director = lucaguadagnino,
                    Protagonist = timotheechalamet
                },
                new Movie()
                {
                    MovieID = 6,
                    Name = "Gentlemen",
                    Music = "Guy Ritchie",
                    RunningTime = 113,
                    Budget = 22000000,
                    Genre = "action",
                    AgeLimit = 18,
                    Income = 115200000,
                    DirectorID = guyritchie.DirectorID,
                    ProtagonistID = matthewmcconaughey.ProtagonistID,
                    Director = guyritchie,
                    Protagonist = matthewmcconaughey
                },
                new Movie()
                {
                    MovieID = 7,
                    Name = "The Great Gatsby",
                    Music = "Baz Luhrmann",
                    RunningTime = 142,
                    Budget = 190000000,
                    Genre = "drama",
                    AgeLimit = 18,
                    Income = 353600000,
                    DirectorID = bazluhrmann.DirectorID,
                    ProtagonistID = leonardodicaprio.ProtagonistID,
                    Director = bazluhrmann,
                    Protagonist = leonardodicaprio
                },
                new Movie()
                {
                    MovieID = 8,
                    Name = "Forrest Gump",
                    Music = "Alan Silvestri",
                    RunningTime = 142,
                    Budget = 55000000,
                    Genre = "drama",
                    AgeLimit = 12,
                    Income = 683100000,
                    DirectorID = robertzemeckis.DirectorID,
                    ProtagonistID = tomhanks.ProtagonistID,
                    Director = robertzemeckis,
                    Protagonist = tomhanks

                },
                new Movie()
                {
                    MovieID = 9,
                    Name = "Dune",
                    Music = "Hans Zimmer.",
                    RunningTime = 155,
                    Budget = 165000000,
                    Genre = "sci-fi",
                    AgeLimit = 16,
                    Income = 117600000,
                    DirectorID = denisvilleneuve.DirectorID,
                    ProtagonistID = timotheechalamet.ProtagonistID,
                    Director = denisvilleneuve,
                    Protagonist = timotheechalamet
                }
            }.AsQueryable();
         
            MockMovRepo.Setup((m) => m.ReadAll()).Returns(moviess);
     
            mLog = new MovieLogic(MockMovRepo.Object);
        }



        // 5 NON-CRUD TEST
        [Test]
        public void ProtagonistGroupTEST()
        {
            var q = mLog.ProtagonistGroup();
            ;
            Assert.That(q.Count() == 6);
        }
        [Test]
        public void DirectorGroupTEST()
        {
            var q = mLog.DirectorGroup();
            ;
            Assert.That(q.Count() == 7);
        }
        [Test]
        public void GenreTEST()
        {
            var q = mLog.DirectorGroup();
            ;
            Assert.That(q.Count() == 7);
        }
        [Test]
        public void DirectorGenderGroupTEST()
        {
            var q = mLog.DirectorGenderGroup();
            ;
            Assert.That(q.Count() == 1);
        }
        [Test]
        public void ProtagonistAgeGroupTEST()
        {
            var q = mLog.ProtagonistAgeGroup();
            ;
            Assert.That(q.Count() == 5);
        }


        // 5 db CRUD TEST ,3 CREATE, 1 DELETE, 1 READ
        [Test]
        public void MovieCreateTEST()
        {
            Assert.That(() =>
            {
                mLog.Create(null);

            }, Throws.Exception);
        }
        [Test]
        public void MovieCreateTEST2()
        {
            Movie m = new Movie();
            m.Name = "";
            Assert.That(() =>
            {
                mLog.Create(m);

            }, Throws.Exception);
        }
        [Test]
        public void MovieCreateTEST3()
        {
            Movie m = new Movie();
            m.Music = "";
            Assert.That(() =>
            {
                mLog.Create(m);

            }, Throws.Exception);
        }

        [Test]
        public void MovieDeleteTEST()
        {
            Assert.That(() =>
            {
                mLog.Delete(-1);

            }, Throws.Exception);
        }
        [Test]
        public void MovieReadTEST()
        {
            Assert.That(() =>
            {
                mLog.Read(-1);

            }, Throws.Exception);
        }

    }
}
