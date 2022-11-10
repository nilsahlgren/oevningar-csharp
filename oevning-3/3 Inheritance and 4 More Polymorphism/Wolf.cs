using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Wolf : Animal
    {
        public int NbrOfTeeth { get; set; }

        public Wolf(string name, int age, double weight, string sound, int nbrOfTeeth) : base(name, age, weight, sound)
        {
            this.NbrOfTeeth = nbrOfTeeth;
        }

        public override void DoSound()
        {
            Console.WriteLine(this.Sound);
        }
        public override string Stats()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Weight: {this.Weight}, Sound: {this.Sound}, NbrOfTeeth: {this.NbrOfTeeth}";
        }
    }
}
