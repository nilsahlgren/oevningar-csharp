using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class Bus : Vehicle
    {
        public uint NbrOfSeats { get; set; }

        public Bus(string regNbr, string manufacturer, string model, uint year, uint nbrOfSeats) : base(regNbr, manufacturer, model, year)
        {
            NbrOfSeats = nbrOfSeats;
        }
        public override string VehicleInfo()
        {
            return $"{base.VehicleInfo()}, Nbr of seats: {NbrOfSeats}";
        }
    }
}
