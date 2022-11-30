using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    public class Car : Vehicle
    {
        public double Mileage { get; set; }

        public Car(string regNbr, string manufacturer, string model, uint year, double mileage) : base(regNbr, manufacturer, model, year)
        {
            Mileage = mileage;
        }

        public override string VehicleInfo()
        {
            return $"{base.VehicleInfo()}, Mileage: {Mileage}";
        }
    }
}
