using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class Motorcycle : Vehicle
    {
        public uint CylinderVolume { get; set; }

        public Motorcycle(string regNbr, string manufacturer, string model, uint year, uint cylinderVolume) : base(regNbr, manufacturer, model, year)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string VehicleInfo()
        {
            return $"{base.VehicleInfo()}, Cylinder Volume: {CylinderVolume}";
        }
    }
}
