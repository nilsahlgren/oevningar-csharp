using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3
{
    internal class PersonHandler
    {


        public PersonHandler()
        {

        }

        public void SetAge(Person pers, int age)
        {
            pers.Age = age;
        }

        public void SetFName(Person pers, string fName)
        {
            pers.FName = fName;
        }

        public void SetLName(Person pers, string lName)
        {
            pers.LName = lName;
        }

        public void SetHeight(Person pers, double height)
        {
            pers.Height = height;
        }

        public void SetWeight(Person pers, double weight)
        {
            pers.Weight = weight;
        }

        public int GetAge(Person pers)
        {
            return pers.Age;
        }

        public string GetFName(Person pers)
        {
            return pers.FName;
        }

        public string GetLName(Person pers)
        {
            return pers.LName;
        }

        public double GetHeight(Person pers)
        {
            return pers.Height;
        }

        public double GetWeight(Person pers)
        {
            return pers.Weight;
        }

        public void PrintFullDetails(Person pers)
        {
            Console.WriteLine($"First Name:\t{pers.FName}\nLast Name:\t{pers.LName}\nAge:\t\t{pers.Age}\nHeight:\t\t{pers.Height}\nWeight:\t\t{pers.Weight}");
        }


        public Person CreatePerson(int age, string fName, string lName, double height, double weight)
        {
            Person pers = new Person(fName, lName);
            SetAge(pers, age);
            SetHeight(pers, height);
            SetWeight(pers, weight);
            return pers;
        }
    }
}
