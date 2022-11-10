using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Horse : Animal
    {
        public string? Breed { get; set; }

        public Horse(string name, int age, double weight, string sound, string breed) : base(name, age, weight, sound)
        {
            this.Breed = breed;
        }

        public override void DoSound()
        {
            Console.WriteLine(this.Sound);
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, Breed: {this.Breed}";
        }
    }
}
