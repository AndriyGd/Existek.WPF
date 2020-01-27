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

namespace WPF.Lesson7
{
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User _user;

        public MainWindow()
        {
            InitializeComponent();

            _user = new User{Name = "Jonathan Tom", Age = 25, Password = "hjh;67-gf"};

            DataContext = _user;
        }

        private void UpdatedFromUI_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"User: {_user.Name}\nAge: {_user.Age}");
        }

        private void UpdatedProgramatically_OnClick(object sender, RoutedEventArgs e)
        {
            _user.Age = 123;
            _user.Password = "gfff;op-80";
        }
    }
}
