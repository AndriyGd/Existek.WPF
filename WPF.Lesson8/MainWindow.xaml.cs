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

namespace WPF.Lesson8
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Book> _books;
        private int _currentBookIndex;

        public ObservableCollection<Book> Books { get; set; }
        public Book SelectedBook { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //BtnPrevBook.IsEnabled = false;
            _books = new List<Book>();

            Books = new ObservableCollection<Book>();
            Books.CollectionChanged += BooksOnCollectionChanged;
            LoadDataBind();

            DataContext = this;
        }

        private void BooksOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {

            }
        }

        private void LoadData()
        {
            _books.Add(new Book{Name = "WPF 4.5", Author = "Jason", Pages = 1290});
            _books.Add(new Book{Name = "Java 8", Author = "Tom", Pages = 898});
            _books.Add(new Book{Name = "C# 8", Author = "Victor", Pages = 1456});
            _books.Add(new Book{Name = "ECMA Script 6", Author = "Olga", Pages = 1250});
            _books.Add(new Book{Name = "Robinson", Author = "Defo", Pages = 560});

            DataContext = _books[_currentBookIndex];
        }

        private void LoadDataBind()
        {
            Books.Add(new Book
            {
                Name = "WPF 4.5", Author = "Jason", Pages = 1290,
                Description = "You can use the EnumDisplayMonitors function for this. Here's a little class that automatically"
            });
            Books.Add(new Book
            {
                Name = "Java 8", Author = "Tom", Pages = 898,
                Description = "You can use GetSystemMetrics() with the SM_XVIRTUALSCREEN, SM_YVIRTUALSCREEN,"
            });
            Books.Add(new Book { Name = "C# 8", Author = "Victor", Pages = 1456 });
            Books.Add(new Book { Name = "ECMA Script 6", Author = "Olga", Pages = 1250 });
            Books.Add(new Book { Name = "Robinson", Author = "Defo", Pages = 560 });
        }

        //private void BtnPrevBook_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (!BtnNextBook.IsEnabled)
        //    {
        //        BtnNextBook.IsEnabled = true;
        //    }

        //    if (--_currentBookIndex >= 0)
        //    {
        //        DataContext = _books[_currentBookIndex];
        //    }

        //    if (_currentBookIndex == 0)
        //    {
        //        BtnPrevBook.IsEnabled = false;
        //        _currentBookIndex = 0;
        //    }
        //}

        //private void BtnNextBook_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (!BtnPrevBook.IsEnabled)
        //    {
        //        BtnPrevBook.IsEnabled = true;
        //    }

        //    if (++_currentBookIndex < _books.Count)
        //    {
        //        DataContext = _books[_currentBookIndex];
        //    }
            
        //    if(_currentBookIndex + 1 == _books.Count)
        //    {
        //        BtnNextBook.IsEnabled = false;
        //        _currentBookIndex = _books.Count - 1;
        //    }
        //}

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
            }
        }
    }
}
