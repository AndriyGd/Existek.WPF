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

namespace Existek.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Width = 900;
            //Title = "Lesson 1 WPF";
            //TxtBoxHello.Text = "Interaction logic for MainWindow.xaml";

            var txtB = new TextBox{Text = "Interaction logic for MainWindow", VerticalAlignment = VerticalAlignment.Center, FontSize = 40};
            Content = txtB;
        }
    }
}
