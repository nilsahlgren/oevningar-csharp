using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace oevning_5
{
    public class Handler
    {
        public Garage<Vehicle>[] garages;
        public Garage<Vehicle> CurrentGarage { get; set; }

        public Handler()
        {
            this.garages = new Garage<Vehicle>[0];
            this.CurrentGarage = default!;
        }

        public void CreateGarage()
        {
            string newGarageName = UI.GetStringWithMessage("Enter the name of the garage:");
            uint newGarageCapacity = UI.GetUintWithMessage("Enter the garage capacity:");
            Garage<Vehicle> newGarage = new Garage<Vehicle>(newGarageName, newGarageCapacity);
            AddGarage(newGarage);
        }

        public void AddGarage(Garage<Vehicle> garage)
        {
            Garage<Vehicle>[] newGaragesArray = new Garage<Vehicle>[garages.Length + 1];

            for (int i = 0; i < garages.Length; i++)
            {
                newGaragesArray[i] = garages[i];
            }
            newGaragesArray[garages.Length] = garage;
            this.garages = newGaragesArray;
            UI.PrintMessage($"New garage added with name {garage.Name} and capacity {garage.Capacity()}");

        }

        public Vehicle CreateVehicle()
        {
            string newRegNbr = UI.GetRegNbrWithMessage("Enter the registration number of the vehicle:");
            string newManufacturer = UI.GetStringWithMessage("Enter the Manufacturer of the vehicle:");
            string newModel = UI.GetStringWithMessage("Enter the Model of the vehicle:");
            uint newYear = UI.GetUintWithMessage("Enter the Year of Manufacture of the vehicle:");

            Vehicle newVehicle = new Car(newRegNbr, newManufacturer, newModel, newYear, 100);
            int vehicleType = SelectVehicleType();

            if (vehicleType == 1)
            {
                double newMileage = UI.GetDoubleWithMessage("Enter the mileage of the car:");
                newVehicle = new Car(newRegNbr, newManufacturer, newModel, newYear, newMileage);
            }
            else if (vehicleType == 2)
            {
                uint newNbrOfSeats = UI.GetUintWithMessage("Enter the number of seats of the bus:");
                newVehicle = new Bus(newRegNbr, newManufacturer, newModel, newYear, newNbrOfSeats);
            }
            else if (vehicleType == 3)
            {
                uint newCylinderVolume = UI.GetUintWithMessage("Enter the cylinder volume of the motorcycle:");
                newVehicle = new Motorcycle(newRegNbr, newManufacturer, newModel, newYear, newCylinderVolume);
            }
            else if (vehicleType == 4)
            {
                uint newMotorHorsepower = UI.GetUintWithMessage("Enter the horsepower of the motor of the boat:");
                newVehicle = new Boat(newRegNbr, newManufacturer, newModel, newYear, newMotorHorsepower);
            }
            else if (vehicleType == 5)
            {
                string newEngineType = UI.GetStringWithMessage("Enter the engine type of the airplane:");
                newVehicle = new Airplane(newRegNbr, newManufacturer, newModel, newYear, newEngineType);
            }
            return newVehicle;
        }

        public int SelectVehicleType()
        {
            UI.ShowSelectVehicleTypeMenu();
            bool stayInSelectVehicleTypeMenu = true;
            int nav = 0;
            do
            {
                nav = UI.GetIntFromUser();
                if (nav == 1 || nav == 2 || nav == 3 || nav == 4 || nav == 5)
                {
                    stayInSelectVehicleTypeMenu = false;
                }
                else
                {
                    UI.PrintMessage("Input must be 1, 2, 3, 4, or 5.");
                }
            } while (stayInSelectVehicleTypeMenu);

            return nav;
        }
    
        public void AddVehicle(Vehicle vehicle)
        {
            UI.PrintMessage(CurrentGarage.Park(vehicle));
        }

        public void RemoveVehicle()
        {
            string regNbrToRemove = UI.GetRegNbrWithMessage("Enter the registration number of the vehicle to unpark:");
            UI.PrintMessage(CurrentGarage.Unpark(regNbrToRemove));
        }

        public void ListAllVehicles()
        {
            foreach(var vehicle in CurrentGarage)
            {
                if (vehicle != null)
                {
                    UI.PrintMessage(vehicle.VehicleInfo());
                }
            }
        }

        public void ListNbrOfVehiclesByType()
        {
            UI.PrintMessage("Type:\t\tNbr:");
            var nbrOfCars = CurrentGarage.Where(v => v != null && v.GetType().Name == "Car").Count();
            var nbrOfBuses = CurrentGarage.Where(v => v != null && v.GetType().Name == "Bus").Count();
            var nbrOfMotorcycles = CurrentGarage.Where(v => v != null && v.GetType().Name == "Motorcycle").Count();
            var nbrOfBoats = CurrentGarage.Where(v => v != null && v.GetType().Name == "Boat").Count();
            var nbrOfAirplanes = CurrentGarage.Where(v => v != null && v.GetType().Name == "Airplane").Count();
            UI.PrintMessage($"Car\t\t{nbrOfCars}\nBus\t\t{nbrOfBuses}\nMotorcycle\t{nbrOfMotorcycles}\nBoat\t\t{nbrOfBoats}\nAirplane\t{nbrOfAirplanes}");
        }

        public void FindVehicleByRegistrationNumber()
        {
            string soughtRegNbr = UI.GetRegNbrWithMessage($"Enter registration number of the vehicle you want to find in {CurrentGarage.Name}:");

            string message = $"No vehicle with registration number {soughtRegNbr} found in {CurrentGarage.Name}.";

            foreach (Vehicle v in CurrentGarage)
            {
                if (v != null && v.RegNbr!.ToLower() == soughtRegNbr.ToLower())
                {
                    message = $"Vehicle found: {v.VehicleInfo()}";
                }
            }
            UI.PrintMessage(message);
        }

        public void FindVehicleByProperties()
        {
            UI.PrintMessage("Leave property blank if you do not wish to filter by it.");
            string typeFilter = UI.GetStringOrBlankWithMessage("Enter the type of vehicle:");
            string manufacturerFilter = UI.GetStringOrBlankWithMessage("Enter the Manufacturer of the vehicle:");
            string modelFilter = UI.GetStringOrBlankWithMessage("Enter the Model of the vehicle:");
            string yearFilter = UI.GetStringOrBlankWithMessage("Enter the Year of Manufacture of the vehicle:");

            IEnumerable<Vehicle> subset = CurrentGarage;
            if (typeFilter != "")
            {
                subset = (IEnumerable<Vehicle>)subset.Where(v => v != null && v.GetType().Name == typeFilter);
            }
            if (manufacturerFilter != "")
            {
                subset = (IEnumerable<Vehicle>)subset.Where(v => v != null && v.Manufacturer == manufacturerFilter);
            }
            if (modelFilter != "")
            {
                subset = (IEnumerable<Vehicle>)subset.Where(v => v != null && v.Model == modelFilter);
            }
            if (uint.TryParse(yearFilter, out uint yearFilterAsUint))
            {
               subset = (IEnumerable<Vehicle>)subset.Where(v => v != null && v.Year == yearFilterAsUint);
            }

            UI.PrintMessage($"Vehicles found after filtering:\n");
            if (!subset.Any())
            {
                UI.PrintMessage("No vehicles found.");
            }
            else
            {
                foreach (Vehicle v in subset)
                {
                    UI.PrintMessage(v.VehicleInfo());
                }
            }
        }

        public void AddFiveGenericVehicles()
        {
            AddVehicle(new Car("AAA666", "BMW", "S3", 1999, 1000));
            AddVehicle(new Car("AAA666", "Volvo", "V70", 2005, 1000));
            AddVehicle(new Bus("BBB777", "Volvo", "BigBus", 2017, 30));
            AddVehicle(new Motorcycle("CCC888", "BMW", "Vroom", 2005, 400));
            AddVehicle(new Boat("DDD999", "Flipper", "20GT", 1999, 100));
            AddVehicle(new Airplane("EEE111", "Boeing", "737", 2005, "Jet"));
        }
    }
}
