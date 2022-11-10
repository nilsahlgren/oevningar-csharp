using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Worm : Animal
    {
        public double Circumference { get; set; }

        public Worm(string name, int age, double weight, string sound, double circumference) : base(name, age, weight, sound)
        {
            this.Circumference = circumference;
        }

        public override void DoSound()
        {
            Console.WriteLine(this.Sound);
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, Circumference: {this.Circumference}";
        }
    }
}
