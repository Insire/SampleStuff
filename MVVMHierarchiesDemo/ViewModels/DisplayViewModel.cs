using System.ComponentModel;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class DisplayViewModel : INotifyPropertyChanged
    {
        public MainViewModel MainViewModel { get; }

        public DisplayViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
