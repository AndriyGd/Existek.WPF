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

namespace WPF.Lesson4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var cs = new List<string>
            //{
            //    "Jonathan Top",
            //    "Lauren",
            //    "Oleg",
            //    "Victor",
            //    "Jason"
            //};

            //CmbCustomers.ItemsSource = cs;
            //CmbCustomers.SelectedIndex = 0;

            LoadData();
        }

        private void LoadData()
        {
            var customers = new List<Customer>
            {
                new Customer{CompanyName = "LabCom", MaxItems = 234, Name = "Victor"},
                new Customer{CompanyName = "LingOut", MaxItems = 134, Name = "Oleg"},
                new Customer{CompanyName = "FloRT", MaxItems = 734, Name = "Jason"},
                new Customer{CompanyName = "SouthPS", MaxItems = 434, Name = "Olga"},
                new Customer{CompanyName = "BigData", MaxItems = 1234, Name = "John Tom"},
            };

            CmbCustomers.ItemsSource = customers;
            //CmbCustomers.DisplayMemberPath = "CompanyName";
            CmbCustomers.SelectedIndex = 0;
        }

        ////private void OnNewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        ////{
        ////    e.CanExecute = TxtBoxText.Text.Length > 0;
        ////}

        ////private void OnNewExecuted(object sender, ExecutedRoutedEventArgs e)
        ////{
        ////    TxtBoxText.Clear();
        ////}

        ////private void OnSaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        ////{
        ////    e.CanExecute = TxtBoxText.Text.Length > 0;
        ////}

        ////private void OnSaveExecuted(object sender, ExecutedRoutedEventArgs e)
        ////{
        ////    MessageBox.Show(TxtBoxText.Text);
        ////}

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (CmbCustomers.SelectedIndex >= 0)
            {
                if (CmbCustomers.SelectedItem is Customer customer)
                {
                    MessageBox.Show($"Contact Name: {customer.Name}; Max Items: {customer.MaxItems}");
                }
            }
        }
    }
}
