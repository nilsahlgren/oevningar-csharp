using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace oevning_5
{
    internal class UI
    {

        public static void ShowMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Create a new garage");
            Console.WriteLine("2. Manage an existing garage");
            Console.WriteLine("0. Exit System");
        }

        public static void ShowSelectGarageMenu(Handler handler)
        {
            Console.WriteLine("\nThese are the garages in the system:");
            for (int i = 0; i < handler.garages.Length; i++)
            {
                Console.WriteLine($"{i+1}. {handler.garages[i].Name}");
            }
            Console.WriteLine("0. Exit to Main Menu");
        }

        public static void ShowManageGarageMenu(string garageName)
        {
            Console.WriteLine($"\nYou are managing the garage: {garageName}");
            Console.WriteLine($"What would you like to do:");
            Console.WriteLine("1. Add a vehicle");
            Console.WriteLine("2. Add 5 generic vehicles");
            Console.WriteLine("3. Remove a vehicle");
            Console.WriteLine("4. Show all parked vehicles");
            Console.WriteLine("5. Show number of parked vehicles by type");
            Console.WriteLine("6. Find vehicle by registration number");
            Console.WriteLine("7. Find vehicle by properties");
            Console.WriteLine("0. Exit to Main Menu");
        }

        public static void ShowSelectVehicleTypeMenu()
        {
            Console.WriteLine("\nSelect Vehicle Type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Motorcycle");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane");
            Console.WriteLine("0. Exit System");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static double GetDoubleWithMessage(string message)
        {
            PrintMessage(message);
            return GetDoubleFromUser();
        }

        public static string GetStringWithMessage(string message)
        {
            PrintMessage(message);
            return GetStringFromUser();
        }

        public static uint GetUintWithMessage(string message)
        {
            PrintMessage(message);
            return GetUintFromUser();
        }
        public static int GetIntWithMessage(string message)
        {
            PrintMessage(message);
            return GetIntFromUser();
        }

        public static string GetRegNbrWithMessage(string message)
        {
            PrintMessage(message);
            return GetRegistrationNumber();
        }

        public static string GetStringOrBlankWithMessage(string message)
        {
            PrintMessage(message);
            return GetStringOrBlankFromUser();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string GetStringFromUser()
        {
            string userInput;
            bool stringIsValid = false;
            do
            {
                userInput = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input, can't be null or blank.");
                }
                else
                {
                    stringIsValid = true;
                }
            } while (!stringIsValid);

            return userInput;
        }
        
        public static string GetStringOrBlankFromUser()
        {
            string userInput;
            bool stringIsValid = false;
            do
            {
                userInput = Console.ReadLine()!;
                if (userInput == null)
                {
                    Console.WriteLine("Invalid input, can't be null.");
                }
                else
                {
                    stringIsValid = true;
                }
            } while (!stringIsValid);

            return userInput!;
        }

        public static int GetIntFromUser()
        {
            do
            {
                string userInput = GetStringFromUser();

                if (int.TryParse(userInput, out int userInputAsInt))
                {
                    return userInputAsInt;
                }
                else
                {
                    Console.WriteLine("Invalid input, must be an integer.");
                }
            } while (true);
        }

        public static uint GetUintFromUser()
        {
            do
            {
                string userInput = GetStringFromUser();

                if (uint.TryParse(userInput, out uint userInputAsUint))
                {
                    return userInputAsUint;
                }
                else
                {
                    Console.WriteLine("Invalid input, must be a non-negative integer.");
                }
            } while (true);
        }

        public static double GetDoubleFromUser()
        {
            do
            {
                string userInput = GetStringFromUser();

                if (double.TryParse(userInput, out double userInputAsDouble))
                {
                    return userInputAsDouble;
                }
                else
                {
                    Console.WriteLine("Invalid input, must be a double.");
                }
            } while (true);
        }

        public static string GetRegistrationNumber()
        {
            do
            {
                string userInput = GetStringFromUser();


                if (RegistrationNumberValidator(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid input, must be six characters long in format aaa111 or aaa11a. Input is not case sensitive.");
                }
            } while (true);
        }

        private static bool RegistrationNumberValidator(string regNbr)
        {
            string firstThree = regNbr.Substring(0, 3);
            string fourthAndFifth = regNbr.Substring(3, 2);
            string last = regNbr.Substring(5, 1);

            if (regNbr.Length == 6)
            {
                if (Regex.IsMatch(firstThree, "^[a-zA-Z]+$") && Regex.IsMatch(fourthAndFifth, "^[0-9]+$") && Regex.IsMatch(last, @"^[a-zA-Z0-9]+$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
