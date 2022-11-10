using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal abstract class Animal
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string? Sound { get; set; }

        public Animal(string name, int age, double weight, string sound)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.Sound = sound;
        }
        

        public abstract void DoSound();

        public virtual string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}";
        }

    }
}
