using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal interface IVehicle
    {
        string? RegNbr { get; set; }
        string? Manufacturer { get; set; }
        string? Model { get; set; }
        uint Year { get; set; }

    }
}
