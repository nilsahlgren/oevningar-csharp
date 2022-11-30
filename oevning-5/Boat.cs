using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class Boat : Vehicle
    {
        public uint MotorHorsepower { get; set; }

        public Boat(string regNbr, string manufacturer, string model, uint year, uint motorHorsepower) : base(regNbr, manufacturer, model, year)
        {
            MotorHorsepower = motorHorsepower;
        }

        public override string VehicleInfo()
        {
            return $"{base.VehicleInfo()}, Motor Horsepower: {MotorHorsepower}";
        }
    }
}
