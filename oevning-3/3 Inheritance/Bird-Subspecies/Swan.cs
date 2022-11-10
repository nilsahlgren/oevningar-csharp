using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Swan : Bird
    {
        public string? Colour { get; set; }

        public Swan(string name, int age, double weight, string sound, double wingspan, string colour) : base(name, age, weight, sound, wingspan)
        {
            this.Colour = colour;
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, Wingspan: {this.Wingspan}, Colour: {this.Colour}";
        }
    }
}
