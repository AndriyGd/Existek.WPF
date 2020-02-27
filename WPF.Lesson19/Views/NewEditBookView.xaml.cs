using ModelDomain.Models;

namespace WPF.Lesson19.Views
{
    using ViewModels;

    /// <summary>
    /// Interaction logic for NewEditBookView.xaml
    /// </summary>
    public partial class NewEditBookView
    {
        public NewEditBookView(IBook book)
        {
            InitializeComponent();

            var viewModel = new NewEditBookViewModel(book);

            viewModel.CancelCommand.RequestCommand += Close;
            viewModel.CloseCommand.RequestCommand += CloseCommandOnRequestCommand;

            DataContext = viewModel;
        }

        private void CloseCommandOnRequestCommand()
        {
            DialogResult = true;
            Close();
        }
    }
}
