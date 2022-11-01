using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_1
{
    internal class Employee
    {
        public string name;
        public string wage;

        public Employee(string name, string wage)
        {
            this.name = name;
            this.wage = wage;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name: {name} \t Wage: {wage}");
        }
    }
}
