using System;

namespace Name
{
    abstract class Employee
    {
        private string name;
        private decimal salary;
        private int emp_id;

        private bool emp_att;

        public abstract void CalculeteSalary();
        interface MarkAttecdence
        {
            void markAttend();
        }

        public abstract void Employee_Info();
        protected String Emp_Name { get; set; }
        protected decimal Emp_Salary { get; set; }
        protected int Emp_id { get; set; }
        protected bool Emp_att { get; set; }

    }

    public class Full_Emp : Employee
    {
        Full_Emp(string name, decimal salary, int emp_id)
        {
            Emp_Name = name;
            Emp_Salary = salary;
            Emp_id = emp_id;
        }

        public void markAttend()
        {
            Emp_att = true;
        }

        public void Employee_Info()
        {
            Console.WriteLine($"Employee Id id {Emp_id} Employee Name is {Emp_Name} Base salary is {Emp_Salary}");
        }
    }

    class Half_Emp : Employee
    {
        protected float hour;

        Half_Emp(string name, decimal salary, float hour, int emp_id)
        {
            Emp_Name = name;
            this.hour = hour;
            Emp_Salary = salary;
            Emp_id = emp_id;
        }

        public void markAttend()
        {
            Emp_att = true;
        }

        public void Employee_Info()
        {
            Console.WriteLine($"Employee Id id {Emp_id} Employee Name is {Emp_Name} Base salary is {Emp_Salary}");

        }

    }
}