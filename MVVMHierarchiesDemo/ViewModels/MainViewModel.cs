using MVVMHierarchiesDemo.Misc;
using MVVMHierarchiesDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                RaisePropertyChanged(nameof(SelectedPerson));
            }
        }

        private object leftViewModel;
        public object LeftViewModel
        {
            get { return leftViewModel; }
            set
            {
                leftViewModel = value;
                RaisePropertyChanged(nameof(LeftViewModel));
            }
        }

        private object rightViewModel;
        public object RightViewModel
        {
            get { return rightViewModel; }
            set
            {
                rightViewModel = value;
                RaisePropertyChanged(nameof(RightViewModel));
            }
        }

        public ICommand SwapView { get; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person("Josh")
                {
                    Age = 23
                },
                new Person("Someone")
                {
                    Age = 13
                },
                new Person("Gabriella")
                {
                    Age = 24,
                    Birthday = new DateTime(1995, 04, 03)
                }
            };

            SelectedPerson = People[new Random().Next(People.Count - 1)];
            LeftViewModel = new EditViewModel(this);
            RightViewModel = new DisplayViewModel(this);

            SwapView = new MyICommand(OnSwapView, CanSwapView);
        }

        private void OnSwapView()
        {
            var tl = LeftViewModel;
            var tr = RightViewModel;
            LeftViewModel = tr;
            RightViewModel = tl;
        }

        private bool CanSwapView()
        {
            return SelectedPerson != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
