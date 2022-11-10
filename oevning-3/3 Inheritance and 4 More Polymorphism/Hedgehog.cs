using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Hedgehog : Animal
    {
        public int NbrOfSpikes { get; set; }

        public Hedgehog(string name, int age, double weight, string sound, int nbrOfSpikes) : base(name, age, weight, sound)
        {
            this.NbrOfSpikes = nbrOfSpikes;
        }

        public override void DoSound()
        {
            Console.WriteLine(this.Sound);
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, NbrOfSpikes: {this.NbrOfSpikes}";
        }
    }
}
