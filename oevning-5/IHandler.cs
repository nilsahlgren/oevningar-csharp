using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal interface IHandler
    {
        void CreateGarage();
        Vehicle CreateVehicle();

        void AddVehicle(Vehicle vehicle);

        void RemoveVehicle();

        void AddFiveGenericVehicles();

        void ListAllVehicles();

        void ListNbrOfVehiclesByType();

        void FindVehicleByRegistrationNumber();

        void FindVehicleByProperties();
    }
}
