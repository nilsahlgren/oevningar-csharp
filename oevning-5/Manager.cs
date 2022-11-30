using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class Manager
    {
        private Handler handler;

        public Manager()
        {
            this.handler = new Handler();
        }

        public void Run()
        {
            CreateAndFeed();
            MainMenu();
        }

        public void MainMenu()
        {
            bool stayInMainMenu = true;
            do
            {
                UI.ShowMainMenu();
                int nav = UI.GetIntFromUser();
                switch (nav)
                {
                    case 1:
                        handler.CreateGarage();
                        break;
                    case 2:
                        SelectGarageMenu();
                        break;
                    case 0:
                        stayInMainMenu = false;
                        break;
                    default:
                        UI.PrintMessage("Input must be 1, 2 or 0.");
                        break;
                }
            } while (stayInMainMenu);
        }



        public void SelectGarageMenu()
        {
            bool stayInSelectGarageMenu = true;
            UI.ShowSelectGarageMenu(handler);
            do
            {
                int nav = UI.GetIntFromUser();

                if (nav == 0)
                {
                    stayInSelectGarageMenu = false;
                    UI.ShowMainMenu();
                }
                else if (nav <= handler.garages.Length)
                {
                    handler.CurrentGarage = handler.garages[nav - 1];
                    ManageGarageMenu();
                    stayInSelectGarageMenu = false;
                }
                else
                {
                    UI.PrintMessage("Input must be one of the garage numbers displayed or 0.");
                }
            } while (stayInSelectGarageMenu);
        }

        public void ManageGarageMenu()
        {
            bool stayInGarageMenu = true;
            do
            {
                UI.ShowManageGarageMenu(handler.CurrentGarage.Name);
                int nav = UI.GetIntFromUser();
                switch (nav)
                {
                    case 1:
                        Vehicle newVehicle = handler.CreateVehicle();
                        handler.AddVehicle(newVehicle);
                        break;
                    case 2:
                        handler.AddFiveGenericVehicles();
                        break;
                    case 3:
                        handler.RemoveVehicle();
                        break;
                    case 4:
                        handler.ListAllVehicles();
                        break;
                    case 5:
                        handler.ListNbrOfVehiclesByType();
                        break;
                    case 6:
                        handler.FindVehicleByRegistrationNumber();
                        break;
                    case 7:
                        handler.FindVehicleByProperties();
                        break;
                    case 0:
                        //0. Exit to Main Menu
                        UI.ShowMainMenu();
                        stayInGarageMenu = false;
                        break;
                    default:
                        UI.PrintMessage("Input must be 1, 2, 3, 4, 5, 6, 7 or 0.");
                        break;
                }
            } while (stayInGarageMenu);
        }

        public void CreateAndFeed()
        {
            Garage<Vehicle> newGarage = new Garage<Vehicle>("Q-Park Karlaplan", 5);
            handler.AddGarage(newGarage);
            handler.CurrentGarage = newGarage;
            handler.AddFiveGenericVehicles();
        }
    }
}
