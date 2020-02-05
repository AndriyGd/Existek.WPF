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

namespace WPF.Lesson10
{
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            Employees = new List<Employee>()
            {
                new Employee{Name = "Olga", Age = 26, Salary = 6100},
                new Employee{Name = "Victor", Age = 25, Salary = 4500},
                new Employee{Name = "Jason", Age = 27, Salary = 7600},
                new Employee{Name = "Petro", Age = 23, Salary = 3400},
                new Employee{Name = "Tom", Age = 28, Salary = 8700},
            };
        }
    }
}
