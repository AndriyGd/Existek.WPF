using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using ModelDomain;
using ModelDomain.BooRepositories;

namespace WPF.Lesson19.ViewModels
{
    using System.Windows;

    class MainWindowViewModel
    {
        private readonly IBookRepository _bookRepository;

        public ObservableCollection<Book> Books { get; set; }

        public MainWindowViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            Books = new ObservableCollection<Book>();

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var books = new List<Book>();

            await Task.Run(() => { books = _bookRepository.GetBooks(); });

            books.ForEach(Books.Add);
        }
    }
}
