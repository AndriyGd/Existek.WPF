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

namespace WPF.Lesson11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isYellow = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSkin_OnClick(object sender, RoutedEventArgs e)
        {
            var rd = new ResourceDictionary();
            var uri = string.Empty;
            if (_isYellow)
            {
                uri = "Skins/Green/GreenSkin.xaml";
            }
            else
            {
                uri = "Skins/Yellow/YellowSkin.xaml";
            }

            rd.MergedDictionaries.Add(App.LoadComponent(new Uri(uri, UriKind.Relative)) as ResourceDictionary);

            _isYellow = !_isYellow;

            Application.Current.Resources = rd;
        }

        private void BtnChild_OnClick(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        }
    }
}
