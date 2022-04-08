using FTEPXW_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FTEPXW_HFT_2021221.WpfClient
{
    public class MWVM : ObservableRecipient
    {
        public RestCollection<Director> Directors { get; set; }

        private Director selectedDirector;

        public Director SelectedDirector
        {
            get { return selectedDirector; }
            set
            {
                if (value != null)
                {
                    selectedDirector = new Director()
                    {
                        Name = value.Name,
                        Gender = value.Gender,
                        Age = value.Age,
                        DirectorID = value.DirectorID
                    };
                    OnPropertyChanged();
                    (CreateDirectorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateDirectorCommand { get; set; }
        public ICommand DeleteDirectorCommand { get; set; }
        public ICommand UpdateDirectorCommand { get; set; }

        public ICommand OpenMovieCommand { get; set; }
        public ICommand OpenProtagonistCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MWVM()
        {
            if (!IsInDesignMode)
            {
                Thread.Sleep(10000);
                Directors = new RestCollection<Director>("http://localhost:44216/", "director","hub");

                
                CreateDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Add(new Director()
                    {
                        Name = SelectedDirector.Name,
                        Gender = SelectedDirector.Gender,
                        Age = SelectedDirector.Age,
                    });
                });

                UpdateDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Update(SelectedDirector);
                });

                DeleteDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Delete(SelectedDirector.DirectorID);
                },
                () =>
                {
                    return SelectedDirector != null;
                });
                

                OpenProtagonistCommand = new RelayCommand(() =>
                   {
                       ProtagonistWindow window = new ProtagonistWindow();
                       window.Show();
                   });

                OpenMovieCommand = new RelayCommand(() =>
                {
                    MovieWindow window2 = new MovieWindow();
                    window2.Show();
                 });
                SelectedDirector = new Director();
            }


            
        }


    }
}
