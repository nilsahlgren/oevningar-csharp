using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oevning_1
{
    internal class Register
    {
        public List<Employee> Employees;

        public Register()
        {
            this.Employees = new List<Employee>();
        }
        public void AddEmployee(Employee emp)
        {
           Employees.Add(emp);
        }
        public void DisplayEmployeeList()
        {
            Console.WriteLine("These are the employees in the register:");
            for (int i = 0; i < Employees.Count; i++)
            {
                Employee tempEmp = Employees[i];
                tempEmp.DisplayEmployeeDetails();
            }
        }
    }
}
