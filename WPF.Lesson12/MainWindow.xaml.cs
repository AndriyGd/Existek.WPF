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
using System.Collections.ObjectModel;

namespace WPF.Lesson12
{
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DisplayBook> Books { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Books = new ObservableCollection<DisplayBook>();
            LoadData();

            DataContext = this;
        }

        private void LoadData()
        {
            Books.Add(new DisplayBook(new Book
            {
                Name = "Java 8",
                Pages = 2345,
                Author = "Glop, M"
            }));
            Books.Add(new DisplayBook(new Book
            {
                Name = "Java 9",
                Pages = 1145,
                Author = "Bolk, M"
            }));
            Books.Add(new DisplayBook(new Book
            {
                Name = "C# 8",
                Pages = 1679,
                Author = "Mc. Donald, V"
            }));
            Books.Add(new DisplayBook(new Book
            {
                Name = "JavaScript",
                Pages = 980,
                Author = "Fort, B"
            }));
            Books.Add(new DisplayBook(new Book
            {
                Name = "UWP",
                Pages = 1654,
                Author = "Mertu, N"
            }));
            Books.Add(new DisplayBook(new Book
            {
                Name = "WCF",
                Pages = 0,
                Author = "Motr, N"
            }));

        }
    }
}
