using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal interface IGarage<T>
    {
        string Park(T vehicle);
        string Unpark(string regNbr);
    }
}
