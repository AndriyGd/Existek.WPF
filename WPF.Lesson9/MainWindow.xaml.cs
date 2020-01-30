using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WPF.Lesson9
{
    using Common;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _messageText;
        public event PropertyChangedEventHandler PropertyChanged;

        public string MessageText
        {
            get => _messageText;
            set
            {
                if (Equals(_messageText, value)) return;

                _messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        public DelegateCommand ShowMessageTextCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MessageText = "Hello!";
            ShowMessageTextCommand = new DelegateCommand(ShowMessageText, CanExecuteShowMessageTextCommand);

            DataContext = this;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowMessageText(object param)
        {
            MessageBox.Show($"{param}");
        }

        private bool CanExecuteShowMessageTextCommand(object param)
        {
            return param is string message && !string.IsNullOrWhiteSpace(message);
        }
    }
}
