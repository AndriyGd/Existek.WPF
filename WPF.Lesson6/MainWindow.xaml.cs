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
using System.IO;
using System.Collections.ObjectModel;

namespace WPF.Lesson6
{
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Company> _companies;
        private readonly ObservableCollection<Employee> _employees;
        public MainWindow()
        {
            InitializeComponent();

            _companies = new ObservableCollection<Company>();
            _employees = new ObservableCollection<Employee>();
            ////TreeViewFolders.ItemsSource = _companies;

            DataGridCompanies.ItemsSource = _employees;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //LoadCompanies();
            LoadEmployes();
        }

        private void LoadCompanies()
        {
            _companies.Clear();

            var com = new Company {CompanyName = "Global Inc."};
            com.Employees.Add(new Employee
            {
                Name = "Jason",
                Age = 25,
                Salary = 4560
            });
            com.Employees.Add(new Employee
            {
                Name = "Tom",
                Age = 24,
                Salary = 4860
            });
            com.Employees.Add(new Employee
            {
                Name = "Elisabet",
                Age = 23,
                Salary = 6560
            });
            _companies.Add(com);

            com = new Company { CompanyName = "World LLC Inc" };
            com.Employees.Add(new Employee
            {
                Name = "John",
                Age = 28,
                Salary = 7560
            });
            com.Employees.Add(new Employee
            {
                Name = "Olha",
                Age = 25,
                Salary = 5660
            });
            com.Employees.Add(new Employee
            {
                Name = "Victor",
                Age = 28,
                Salary = 6360
            });
            _companies.Add(com);

            com = new Company { CompanyName = "Ramada INN Inc." };
            com.Employees.Add(new Employee
            {
                Name = "Victoria",
                Age = 26,
                Salary = 7960
            });
            com.Employees.Add(new Employee
            {
                Name = "Paul",
                Age = 27,
                Salary = 5620
            });
            com.Employees.Add(new Employee
            {
                Name = "Lauren",
                Age = 28,
                Salary = 6860
            });
            _companies.Add(com);
        }

        private void LoadEmployes()
        {
            _employees.Clear();

            _employees.Add(new Employee
            {
                Name = "Jason",
                Age = 25,
                Salary = 4560
            });
            _employees.Add(new Employee
            {
                Name = "Olha",
                Age = 25,
                Salary = 5660,
                IsOnVacation = true
            });
            _employees.Add(new Employee
            {
                Name = "Victor",
                Age = 28,
                Salary = 6360
            });
            _employees.Add(new Employee
            {
                Name = "John",
                Age = 28,
                Salary = 7560,
                IsOnVacation = true
            });
            _employees.Add(new Employee
            {
                Name = "Olha",
                Age = 25,
                Salary = 5660
            });
            _employees.Add(new Employee
            {
                Name = "Victor",
                Age = 28,
                Salary = 6360,
                IsOnVacation = true
            });
            _employees.Add(new Employee
            {
                Name = "Victoria",
                Age = 26,
                Salary = 7960
            });
            _employees.Add(new Employee
            {
                Name = "Paul",
                Age = 27,
                Salary = 5620,
                IsOnVacation = true
            });
            _employees.Add(new Employee
            {
                Name = "Lauren",
                Age = 28,
                Salary = 6860
            });
        }

        private void Show_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(DataGridCompanies.SelectedItem is Employee employee)) return;

            MessageBox.Show($"Name: {employee.Name}; Salary: {employee.Salary:N}");
        }
    }
}
