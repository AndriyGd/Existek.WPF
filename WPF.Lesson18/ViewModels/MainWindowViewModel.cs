using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommonMVVM.Common;
using CommonMVVM.ViewModel;

namespace WPF.Lesson18.ViewModels
{
    using Interfaces;
    using Models;

    public class MainWindowViewModel : BaseViewModel
    {
        #region Class Fields

        private readonly IImageLoad _imageLoader;
        private readonly List<DisplayImageItem> _imageItems;
        private DisplayImageItem _currentImageItem;

        #endregion

        #region Class Properties

        public DisplayImageItem CurrentImageItem
        {
            get => _currentImageItem;
            set
            {
                if (!SetValue(ref _currentImageItem, value)) return;

                _currentImageItem = value;
                OnPropertyChanged(nameof(CurrentImageItem));
            }
        }

        #endregion

        #region Class Commands

        public DelegateCommand OpenFolderCommand { get; set; }
        public DelegateCommand PrevImageCommand { get; set; }
        public DelegateCommand NextImageCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        #endregion

        #region Class Constructors

        public MainWindowViewModel(IImageLoad imageLoader)
        {
            _imageLoader = imageLoader;
            OpenFolderCommand = new DelegateCommand(OnOpenFolder);
            
            _imageItems = new List<DisplayImageItem>();

            PrevImageCommand = new DelegateCommand(OnPrevImage, CanPrevImageCommand);
            NextImageCommand = new DelegateCommand(OnNextImage, CanNextImageCommand);
            CloseCommand = new DelegateCommand(p => _imageItems.Clear());
        }

        #endregion

        private void OnOpenFolder(object param)
        {
            LoadImages();
        }

        private void LoadImages()
        {
            _imageItems.Clear();

            try
            {
                _imageItems.AddRange(_imageLoader.LoadImageItems());
                CurrentImageItem = _imageItems.FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnPrevImage(object param)
        {
            CurrentImageItem = _imageItems[GetPrevIndex()];
        }

        private void OnNextImage(object param)
        {
            CurrentImageItem = _imageItems[GetNextIndex()];
        }

        private bool CanPrevImageCommand(object param)
        {
            if (CurrentImageItem == null) return false;

            return GetPrevIndex() >= 0;
        }

        private bool CanNextImageCommand(object param)
        {
            if (CurrentImageItem == null) return false;

            return GetNextIndex() < _imageItems.Count;
        }

        private int GetPrevIndex()
        {
            var index = _imageItems.IndexOf(CurrentImageItem);

            //if (index - 1 < 0) return 0;

            return index - 1;
        }

        private int GetNextIndex()
        {
            var index = _imageItems.IndexOf(CurrentImageItem);

            return index + 1;
        }
    }
}
