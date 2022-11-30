using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    public abstract class Vehicle : IVehicle
    {
        public string? RegNbr { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public uint Year { get; set; }

        public Vehicle(string regNbr, string manufacturer, string model, uint year)
        {
            this.RegNbr = regNbr;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public virtual string VehicleInfo()
        {
            return $"Type: {this.GetType().Name}, RegNbr: {RegNbr}, Manufacturer: {Manufacturer}, Model: {Model}, Year: {Year}";
        }
    }

    /*
     * Kravspecifikation
Fordonen ska implementeras som klassen Vehicle och subklasser till den.
● Vehicle innehåller samtliga egenskaper som ska finnas i samtliga fordonstyper.
T.ex. registreringsnummer, färg, antal hjul och andra egenskaper ni kan komma på.
    ● Registreringsnumret är unikt
    ● Det måste minst finnas följande subklasser:
        ○ Airplane
        ○ Motorcycle
        ○ Car
        ○ Bus
        ○ Boat
    ● Dessa skall implementera minst en egen egenskap var, t.ex:
        ○ Number of Engines
        ○ Cylinder volume
        ○ Fueltype (Gasoline/Diesel)
        ○ Number of seats
        ○ Length
*/
}
