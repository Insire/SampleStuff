using System;
using System.ComponentModel;

namespace MVVMHierarchiesDemo.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged(nameof(Age)); }
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; RaisePropertyChanged(nameof(Birthday)); }
        }

        private int clickerCount;
        public int ClickerCount
        {
            get { return clickerCount; }
            set { clickerCount = value; RaisePropertyChanged(nameof(ClickerCount)); }
        }

        public Person(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
