﻿using System;
using System.Windows.Input;

namespace WPF.Lesson9.Common
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public DelegateCommand(Action<object> action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;
        }

        public DelegateCommand(Action<object> action)
        {
            _action = action;
            _predicate = p => true;
        }

        public bool CanExecute(object parameter)
        {
             return _predicate?.Invoke(parameter) ?? false;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
