using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Dog : Animal
    {
        public double TailLength { get; set; }

        public Dog(string name, int age, double weight, string sound, double tailLength) : base(name, age, weight, sound)
        {
            this.TailLength = tailLength;
        }

        public override void DoSound()
        {
            Console.WriteLine(this.Sound);
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, TailLength: {this.TailLength}";
        }

        public string UniqueDogMethod()
        {
            return "UniqueDogMethod invoked";
        }
    }
}
