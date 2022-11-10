using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Pelican : Bird
    {
        public double BeakVolume { get; set; }

        public Pelican(string name, int age, double weight, string sound, double wingspan, double beakVolume) : base(name, age, weight, sound, wingspan)
        {
            this.BeakVolume = beakVolume;
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, Wingspan: {this.Wingspan}, BeakVolume: {this.BeakVolume}";
        }
    }
}
