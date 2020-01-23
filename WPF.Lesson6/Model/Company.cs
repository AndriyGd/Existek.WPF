using System.Collections.ObjectModel;

namespace WPF.Lesson6.Model
{
    public class Company
    {
        public string CompanyName { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new ObservableCollection<Employee>();
        }

        //~Company()
        //{
        //    Employees.Clear();
        //}
    }
}
