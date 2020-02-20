using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMVVM.ViewModel;
using CommonMVVM.Common;
using System.Windows;

namespace WPF.Lesson17.ViewModels
{
    using System.ComponentModel;

    class MainWindowViewModel : BaseViewModel
    {
        private string _currentDateTime;
        private bool _allowCheckDateTime;

        #region Class Properties

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                if (!SetValue(ref _currentDateTime, value)) return;
                OnPropertyChanged();
            }
        }
        public bool AllowCheckDateTime
        {
            get => _allowCheckDateTime;
            set
            {
                if(!SetValue(ref _allowCheckDateTime, value)) return;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Class Commands

        public DelegateCommand ShowCurrentDateTimeCommand { get; set; }
        public DelegateCommand CheckCurrentDateTimeCommand { get; set; }
        #endregion

        #region Class Constructors

        public MainWindowViewModel()
        {
            ShowCurrentDateTimeCommand = new DelegateCommand(OnShowCurrentDateTime);
            CheckCurrentDateTimeCommand = new DelegateCommand(OnCheckCurrentDateTime, p=> AllowCheckDateTime);

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(AllowCheckDateTime)))
            {
                if (!AllowCheckDateTime) CurrentDateTime = string.Empty;
            }
        }

        private void OnCheckCurrentDateTime(object obj)
        {
            CurrentDateTime = DateTime.Now.ToString();
        }

        private void OnShowCurrentDateTime(object obj)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
        #endregion
    }
}
