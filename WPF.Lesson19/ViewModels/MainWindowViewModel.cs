using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using CommonMVVM.Common;
using CommonMVVM.ViewModel;

using ModelDomain;
using ModelDomain.BooRepositories;
using System.Windows;
using ModelDomain.Models;

namespace WPF.Lesson19.ViewModels
{
    using MVVMCore.Helpers;
    using Views;

    class MainWindowViewModel : BaseViewModel
    {
        private readonly IBookRepository _bookRepository;
        private bool _isDataLoaded;
        private IBook _selectedBook;

        public ObservableCollection<IBook> Books { get; set; }
        public IBook SelectedBook   
        {
            get => _selectedBook;
            set
            {
                if(!SetValue(ref _selectedBook, value)) return;

                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand NewBookCommand { get; set; }
        public DelegateCommand EditBookCommand { get; set; }

        #region Class Constructors

        public MainWindowViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            Books = new ObservableCollection<IBook>();

            NewBookCommand = new DelegateCommand(OnNewBook, p => _isDataLoaded);
            EditBookCommand = new DelegateCommand(OnEditBook,p => SelectedBook != null);

            LoadDataAsync();
        }


        #endregion

        private async void LoadDataAsync()
        {
            try
            {
                var books = new List<IBook>();

                await Task.Run(() => { books = _bookRepository.GetBooks(); });

                books.ForEach(Books.Add);

                _isDataLoaded = true;
                SelectedBook = Books.FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnNewBook(object param)
        {
            var book = new XBook();
            var view = new NewEditBookView(book);

            try
            {
                var res = (bool) view.ShowDialog();
                if (res)
                {
                    _bookRepository.AddBook(book);
                    Books.Add(book);

                    MessageBox.Show("New Book was added successfully!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnEditBook(object obj)
        {
            var bookCopy = CopyValueHelper.CreateNewAndCopy<IBook, IBook>(SelectedBook, _bookRepository.BookType);
            var view = new NewEditBookView(bookCopy);

            try
            {
                var res = (bool)view.ShowDialog();
                if (res)
                {
                    if (_bookRepository.UpdateBook(bookCopy))
                    {
                        CopyValueHelper.CopyValues(bookCopy, SelectedBook);
                        MessageBox.Show("Book was updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Book was updated unsuccessfully!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
