namespace WPF.Lesson19.Views
{
    using ModelDomain.BooRepositories;
    using ModelDomain.Models;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(new BookRepository(typeof(XBook)));
        }
    }
}
