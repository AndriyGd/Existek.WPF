namespace WPF.Lesson18.Views
{
    using Services;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView 
    {
        public MainWindowView()
        {
            InitializeComponent();

            var vm = new MainWindowViewModel(new ImageLoaderFromFolder());
            vm.CloseCommand.RequestCommand += Close;
            DataContext = vm;
        }
    }
}
