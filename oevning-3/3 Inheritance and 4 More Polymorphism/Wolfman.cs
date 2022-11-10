using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3._3_Inheritance
{
    internal class Wolfman : Wolf, IPerson
    {

        public Wolfman(string name, int age, double weight, string sound, int nbrOfTeeth) : base(name, age, weight, sound, nbrOfTeeth)
        {
         
        }

        public void Talk()
        {
            Console.WriteLine("This is wolfman talking wolfman-talk.");
        }
    }
}
