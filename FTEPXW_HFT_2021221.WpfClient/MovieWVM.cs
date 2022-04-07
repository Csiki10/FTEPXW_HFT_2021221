using FTEPXW_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FTEPXW_HFT_2021221.WpfClient
{
    public class MovieWVM : ObservableRecipient
    {
        public RestCollection<Movie> Movies { get; set; }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (value != null)
                {
                    selectedMovie = new Movie()
                    {
                        Name = value.Name,
                        Music = value.Music,
                        RunningTime = value.RunningTime,
                        Budget = value.Budget,
                        Genre = value.Genre,
                        AgeLimit = value.AgeLimit,
                        Income = value.Income,
                        DirectorID = value.MovieID,
                        MovieID = value.MovieID,
                        ProtagonistID = value.ProtagonistID
                };
                    OnPropertyChanged();
                    (CreateMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateMovieCommand { get; set; }
        public ICommand DeleteMovieCommand { get; set; }
        public ICommand UpdateMovieCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MovieWVM()
        {
            if (!IsInDesignMode)
            {
                
                Movies = new RestCollection<Movie>("http://localhost:44216/", "movie", "hub");


                CreateMovieCommand = new RelayCommand(() =>
                {
                    Movies.Add(new Movie()
                    {
                        Name = SelectedMovie.Name,
                        Music = SelectedMovie.Music,
                        RunningTime = SelectedMovie.RunningTime,
                        Budget = SelectedMovie.Budget,
                        Genre = SelectedMovie.Genre,
                        AgeLimit = SelectedMovie.AgeLimit,
                        Income = SelectedMovie.Income,
                        DirectorID = SelectedMovie.MovieID,
                        ProtagonistID = SelectedMovie.ProtagonistID
                    });
                });

                UpdateMovieCommand = new RelayCommand(() =>
                {
                    Movies.Update(SelectedMovie);
                });

                DeleteMovieCommand = new RelayCommand(() =>
                {
                    Movies.Delete(SelectedMovie.MovieID);
                },
                () =>
                {
                    return SelectedMovie != null;
                });
                SelectedMovie = new Movie();
            
            }
        }
    }
}
