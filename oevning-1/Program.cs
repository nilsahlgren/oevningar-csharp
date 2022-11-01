namespace oevning_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Small Restaurant Employee Register System 1.0");

            Register reg = new Register();

            string selectedAction;

            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add Employee to Register");
                Console.WriteLine("2. View Register");
                Console.WriteLine("9. Exit System");
                selectedAction = Console.ReadLine();

                switch (selectedAction)
                {
                    case "1":
                        Console.WriteLine("Enter employee name:");
                        string tempName = Console.ReadLine();
                        Console.WriteLine("Enter employee wage:");
                        string tempWage = Console.ReadLine();
                        Employee tempEmployee = new Employee(tempName, tempWage);
                        reg.AddEmployee(tempEmployee);
                        Console.WriteLine("Employee added.\n");
                        break;
                    case "2":
                        reg.DisplayEmployeeList();
                        Console.WriteLine("\n");
                        break;
                    case "9":
                        Console.WriteLine("Exiting application.");
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } while (selectedAction != "9");

        }
    }


}