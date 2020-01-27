using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.Lesson7.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _age;
        private string _name;
        private string _password;

        public string Name
        {
            get => _name;
            set
            {
                if(Equals(_name, value)) return;

                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (Equals(_age, value)) return;

                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if(Equals(_password, value)) return;

                _password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) //[CallerMemberName] 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
