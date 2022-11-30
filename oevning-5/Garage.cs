using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    public class Garage<T> : IGarage<T>, IEnumerable<T> where T : Vehicle 
    {
        private T[] vehicles;
        public string Name { get; set; }


        public Garage(string name, uint capacity)
        {
            this.vehicles = new T[capacity];
            this.Name = name;
        }

        public int Capacity()
        {
            return vehicles.Length;
        }
        public string Park(T vehicle)
        {
            if (RegNbrUnique(vehicle))
            {
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i] is null)
                    {
                        vehicles[i] = vehicle;
                        return $"Vehicle {vehicle.RegNbr} was successfully parked at slot {i+1} in garage {Name}.";
                    }
                }
                return $"The garage is full, vehicle {vehicle.RegNbr} was not parked in the garage {Name}.";
            }
            else
            {
                return $"A car with a registration number equal to {vehicle.RegNbr} is already parked in the garage {Name}.";
            }
        }

        public string Unpark(string regNbr)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is not null && vehicles[i].RegNbr.ToLower() == regNbr.ToLower())
                {
                    vehicles[i] = default!;
                    return $"Vehicle {regNbr} successfully unparked from garage {Name}";
                }
            }
            return $"Vehicle {regNbr} could not be found in garage {Name}, no vehicle was unparked.";
        }

        private bool RegNbrUnique(T vehicle)
        {
            bool unique = true;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    if (vehicles[i].RegNbr!.ToLower() == vehicle.RegNbr!.ToLower())
                    {
                        unique = false;
                        break;
                    }
                }
            }
            return unique;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

     



    }
}
