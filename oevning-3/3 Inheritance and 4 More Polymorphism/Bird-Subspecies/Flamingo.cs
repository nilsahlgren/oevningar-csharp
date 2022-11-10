using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Flamingo : Bird
    {
        public string PreferredRestingLeg { get; set; }

        public Flamingo(string name, int age, double weight, string sound, double wingspan, string preferredRestingLeg): base(name, age, weight, sound, wingspan)   
        {
            this.PreferredRestingLeg = preferredRestingLeg;
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, Wingspan: {this.Wingspan}, PreferredRestingLeg: {this.PreferredRestingLeg}";
        }
    }
}
