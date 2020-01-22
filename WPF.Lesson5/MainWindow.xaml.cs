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

namespace WPF.Lesson5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //LoadData();
        }

        private void LoadData()
        {
            var customers = new List<Customer>
            {
                new Customer{CompanyName = "LabCom", MaxItems = 234, Name = "Victor", Percent = 25},
                new Customer{CompanyName = "LingOut", MaxItems = 134, Name = "Oleg", Percent = 64},
                new Customer{CompanyName = "FloRT", MaxItems = 734, Name = "Jason", Percent = 14},
                new Customer{CompanyName = "SouthPS", MaxItems = 434, Name = "Olga", Percent = 27},
                new Customer{CompanyName = "BigData", MaxItems = 1234, Name = "John Tom", Percent = 78},
            };

            //LstBox.ItemsSource = customers;
            //LstBox.DisplayMemberPath = "CompanyName";
            //LstBox.SelectedIndex = 0;

            LstView.ItemsSource = customers;
        }

        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
