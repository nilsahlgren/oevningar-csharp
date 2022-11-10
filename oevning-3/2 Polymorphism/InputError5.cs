using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3
{
    internal class InputError5 : UserError
    {
        public InputError5()
        {

        }
        public override string UEMessage()
        {
            return "You made an input error of type 5. This fired an error!";
        }
    }
}
