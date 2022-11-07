namespace oevning_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, choose a function by typing the corresponding number.");

            bool keepMenuOpen = true;
            do
            {
                ShowMenu();
                int userInput = GetIntFromUser();

                switch (userInput)
                {
                    case 1:
                        PriceGroupClassifier();
                        break;
                    case 2:
                        GroupPriceCalculator();
                        break;
                    case 3:
                        InputDectupler();
                        break;
                    case 4:
                        ThirdWordFinder();
                        break;
                    case 0:
                        Console.WriteLine("Exiting system.");
                        keepMenuOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, choose 1, 2, 3, 4 or 0");
                        break;
                }
            } while (keepMenuOpen);

        } //[Övn 2: Huvudmeny] The main method which runs the menu from where the four functions are called.

        static void ShowMenu()
        {
            Console.WriteLine("\n Menu:");
            Console.WriteLine("1. Price Group Classifier");
            Console.WriteLine("2. Group Price Calculator");
            Console.WriteLine("3. Input Dectupler");
            Console.WriteLine("4. Third Word Finder");
            Console.WriteLine("0. Exit System");
        } //[Helper Function] Prints the menu choices via Console.WriteLine().

        static string GetStringFromUser() //[Helper Function] Gets user input as string via Console.ReadLine(), validates inputs with string.IsNullOrWhiteSpace().
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

        static int GetIntFromUser()
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
        } //[Helper Function] Gets user input as int via GetStringFromUser(), validates inputs with int.TryParse().

        static Tuple<int, string> DetermineTicket(int age)
        {
            int price;
            string group;
            if (age < 5 || age > 100)
            {
                price = 0;
                group = "Gratisentré";
            }
            else if (age < 20)
            {
                price = 80;
                group = "Ungdomspris";
            }
            else if (age > 64)
            {
                price = 90;
                group = "Pensionärspris";
            }
            else
            {
                price = 120;
                group = "Standardpris";
            }
            return new Tuple<int, string>(price, group);
        } //[Helper Function] Determines the ticket group name (ungdomspris, pensionärspris etc) and the corresponding price.

        static void PriceGroupClassifier() 
        {
            Console.WriteLine("Enter Age to Determine Ticket Price:");
            int age = GetIntFromUser();
            var TicketDetails = DetermineTicket(age);
            Console.WriteLine($"{TicketDetails.Item2}: {TicketDetails.Item1}kr");
        } //[Övn 2: Menyval 1.a] Gets age from user via GetIntFromUser(), determines price and ticket group name via DetermineTicket(), returns info to user with Console.WriteLine()

        static void GroupPriceCalculator()
        {
            Console.WriteLine("Enter Total Number of Tickets You Want to Purchase:");
            int groupSize = GetIntFromUser();
            int totalPrice = 0;
            for (int i = 0; i < groupSize; i++)
            {
                Console.WriteLine($"Enter Age of Person {(i + 1)} in Your Group:");
                int tempAge = GetIntFromUser();
                var tempTicketDetails = DetermineTicket(tempAge);
                totalPrice += tempTicketDetails.Item1;
            }
            Console.WriteLine($"The Total Price for Your Group is: {totalPrice}kr");
        }//[Övn 2: Menyval 1.b] Gets group size and ages via GetIntFromUser(), determines price via DetermineTicket(), returns group's total price to user with Console.WriteLine()

        static void InputDectupler()
        {
            Console.WriteLine("Enter an input to dectuple:");
            string input = GetStringFromUser();
            string output = "";
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    output += $"{(i + 1)}. {input}";
                }
                else
                {
                    output += $", {(i + 1)}. {input}";
                }
            }
            Console.WriteLine(output);
        } //[Övn 2: Menyval 2] Gets input from user via GetStringFromUser(), appends input to an output-string 10 times via a for-loop, returns output to user via Console.WriteLine()

        static void ThirdWordFinder()
        {
            bool phraseLongEnough = false;
            string phrase;
            string[] wordsInPhrase;
            do
            {
                Console.WriteLine("Enter a phrase with at least three words:");
                phrase = GetStringFromUser();
                wordsInPhrase = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (wordsInPhrase.Length > 2)
                {
                    phraseLongEnough = true;
                }

            } while (!phraseLongEnough);

            Console.WriteLine($"The third word in the phrase is: {wordsInPhrase[2]}");
        } //[Övn 2: Menyval 3] Gets user input via GetStringFromUser(), splits input phrase at blanks, StringSplitOptions.RemoveEmptyEntries handles multiple whitespaces, if phrase > 2 words long returns third word via Console.WriteLine();
    }
}