using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class Airplane : Vehicle
    {
        public string EngineType { get; set; }

        public Airplane(string regNbr, string manufacturer, string model, uint year, string engineType) : base(regNbr, manufacturer, model, year)
        {
            EngineType = engineType;
        }

        public override string VehicleInfo()
        {
            return $"{base.VehicleInfo()}, Engine Type: {EngineType}";
        }
    }
}
