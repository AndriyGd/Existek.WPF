using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Lesson9.Common
{
    using System.Windows;

    public class ShowMessageCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter is string message && !string.IsNullOrWhiteSpace(message);
        }

        public void Execute(object parameter)
        {
            MessageBox.Show($"{parameter}");
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
