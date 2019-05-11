using MVVMHierarchiesDemo.Misc;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        public MainViewModel MainViewModel { get; }
        public ICommand ClickerClicked { get; }

        public EditViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            ClickerClicked = new MyICommand(OnClickerClicked, CanClickClicker);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void OnClickerClicked()
        {
        }

        private bool CanClickClicker()
        {
            return true;
        }
    }
}
