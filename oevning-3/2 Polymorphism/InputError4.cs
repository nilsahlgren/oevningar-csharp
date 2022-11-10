using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_3
{
    internal class InputError4 : UserError
    {

        public InputError4()
        {

        }
        public override string UEMessage()
        {
            return "You made the input error of type 4. This fired an error!";
        }
    }
}
