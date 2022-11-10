using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3
{
    internal class Person
    {
        private int age;
        private string? fName;
        private string? lName;
        private double height;
        private double weight;

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age should not be negative.");
                }
                age = value;
            }
        }
        public string FName
        {
            get { return fName; }
            set
            {
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException("First name should be 2-10 characters long.");
                }
                fName = value;
            }

        }
        public string LName
        {
            get { return lName; }
            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Last name should be 3-15 characters long.");
                }
                lName = value;
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (height < 0)
                {
                    throw new ArgumentException("Height should not be negative.");
                }
                height = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight should not be negative.");
                }
                weight = value;
            }
        }

        public Person(string fName, string lName)
        {
            this.FName = fName;
            this.LName = lName;
        }
    }
}
