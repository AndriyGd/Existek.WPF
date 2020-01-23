namespace WPF.Lesson6.Model
{
    using System;

    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public bool IsOnVacation { get; set; }

        public Employee()
        {
            Id  = Guid.NewGuid();
        }
    }
}
