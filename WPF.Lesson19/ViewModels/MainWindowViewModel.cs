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

        #region Class Properties

        public ObservableCollection<IBook> Books { get; set; }
        public IBook SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (!SetValue(ref _selectedBook, value)) return;

                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand NewBookCommand { get; set; }
        public DelegateCommand EditBookCommand { get; set; }
        public DelegateCommand RemoveBookCommand { get; set; }
        public DelegateCommand ReloadBooksCommand { get; set; }
        #endregion

        #region Class Constructors

        public MainWindowViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            Books = new ObservableCollection<IBook>();

            NewBookCommand = new DelegateCommand(OnNewBook, p => _isDataLoaded);
            EditBookCommand = new DelegateCommand(OnEditBook,p => SelectedBook != null);
            RemoveBookCommand = new DelegateCommand(OnRemoveBook, p => SelectedBook != null);
            ReloadBooksCommand = new DelegateCommand(OnReloadBooks, p => _isDataLoaded);

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

        private void OnRemoveBook(object param)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to remove the Book?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) !=
                    MessageBoxResult.Yes) return;

                if (!_bookRepository.RemoveBook(SelectedBook))
                {
                    MessageBox.Show("Book was not deleted successfully!\nPlease try again.");
                    return;
                }

                Books.Remove(SelectedBook);
                SelectedBook = Books.FirstOrDefault();

                MessageBox.Show("Book was deleted successfully.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void OnReloadBooks(object obj)
        {
            try
            {
                _isDataLoaded = false;
                Books.Clear();

                var reloadedBooks = new List<IBook>();
                await Task.Run(() =>
                {
                    var books = _bookRepository.GetBooks();
                    reloadedBooks = _bookRepository.ReloadBooks(books);
                });

                reloadedBooks.ForEach(Books.Add);

                _isDataLoaded = true;
                SelectedBook = Books.FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
