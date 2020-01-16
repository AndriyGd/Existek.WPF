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

namespace WPF.Lesson3
{
    using System.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //UserPassword.Password = "2234:ldf-545";
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(UserPassword.Password);

            for (int i = 0; i < 100; i++)
            {
                await Task.Run(() => { Thread.Sleep(250); });
                PrbProgressBar.Value++;
            }
        }

        private void Rb_OnChecked(object sender, RoutedEventArgs e)
        {
            //if (RbRed.IsChecked.Value)
            //{
            //    Background = Brushes.Red;
            //}
            //else if (RbBlue.IsChecked.Value)
            //{
            //    Background = Brushes.Blue;
            //}
            //else if (RbGreen.IsChecked.Value)
            //{
            //    Background = Brushes.Green;
            //}
            //else if (RbGreen2.IsChecked.Value)
            //{
            //    Background = Brushes.Gold;
            //}
            //else if (RbBlue2.IsChecked.Value)
            //{
            //    Background = Brushes.Black;
            //}
            //else if (RbRed2.IsChecked.Value)
            //{
            //    Background = Brushes.Yellow;
            //}
        }
    }
}
