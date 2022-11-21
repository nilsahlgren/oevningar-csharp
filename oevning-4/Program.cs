
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;

namespace oevning_4
{
    class Program
    {
        /// 0.1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
        /// S:   Stacken är det lättåtkomliga minnet där programmet körs och value types lagras i en struktur som liknar en stapel.
        ///      De mer komplexa och minneskrävande typerna (reference types) lagras däremot på heapen, vilket inte är en välordnad 
        ///      stapel utan mer en oreda där allt istället har en adress för att det ska gå att hitta vad man lagt där.
        /// 
        /// 0.2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
        /// S:   Value types lagras direkt på stacken. Reference types lagras på heapen, men själva referensen ligger på stacken så att man ska kunna komma åt innehållet på heapen.
        /// 
        /// 0.3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
        /// S:   I det första exemplet sätts y = x och eftersom x är en value type så får y samma värde som x.
        ///      När y sätts till 4 så påverkas inte x, eftersom y är en value type.
        ///      I det andra exemplet sätts också y = x, men eftersom x är en referens till en MyInt på heapen så blir nu y också en referens till samma MyInt.
        ///      Eftersom de nu är en referens till samma MyInt så ändras också x.MyInt till 4 när y.MyInt sätts till 4.
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> theList = new List<string>();
            bool keepExamining = true;
            Console.WriteLine("\nEnter +Adam to add Adam, -Adam to remove Adam or 0 to exit");
            do
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case '0':
                        keepExamining = false;
                        break;
                    default:
                        Console.WriteLine("Input must start with 0, + or -.");
                        break;
                }
            } while (keepExamining);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///1.2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
        ///S:   När listan är full och ännu ett element läggs till.
        ///
        ///1.3. Med hur mycket ökar kapaciteten?
        ///S:   Den fördubblas (4, 8, 16, 32...)
        ///
        ///1.4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        ///S:   Jag antar att det är effektivare kod att utöka kapaciteten från full till halvfull på en gång, jämfört med att smådutta och öka kapaciteten med 1 varje gång det behövs.
        ///
        ///1.5. Minskar kapaciteten när element tas bort ur listan?
        ///S:   Nej.
        ///
        ///1.6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
        ///S:   När man på förhand vet hur stor kapacitet som krävs. När kapaciteten inte heller ska kunna ökas på automatiskt.
        ///
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///2.1. Simulera följande kö på papper:
        ///     a) [Köplats 1: Tom, Köplats 2: Tom, Köplats 3: Tom]
        ///     b) [Kalle, Tom, Tom]
        ///     c) [Kalle, Greta, Tom]
        ///     d) [Greta, Tom, Tom]
        ///     e) [Greta, Stina, Tom]
        ///     f) [Stina, Tom, Tom]
        ///     g) [Stina, Olle, Tom]
        ///     h) ...
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> theQueue = new Queue<string>();
            bool keepExamining = true;
            Console.WriteLine("\nEnter +Adam to add Adam to the back of the queue, - remove the first person in the queue or 0 to exit");
            do
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Number of people in queue: {theQueue.Count}, first in line: {theQueue.Peek()}");
                        break;
                    case '-':
                        if (theQueue.TryDequeue(out string personWhoLeft))
                        {
                            Console.WriteLine($"{personWhoLeft} left the queue.");
                            if (theQueue.Count > 0)
                            {
                                Console.WriteLine($"Number of people still in queue: {theQueue.Count}, first in line: {theQueue.Peek()}");
                            }
                            else
                            {
                                Console.WriteLine($"Number of people still in queue: {theQueue.Count}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The queue is already empty.");
                        }
                        break;
                    case '0':
                        keepExamining = false;
                        break;
                    default:
                        Console.WriteLine("Input must be 0, - or start with +");
                        break;
                }
            } while (keepExamining);
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///3.1. Simulera ännu en gång ICA-kön på papper.Denna gång med en stack.Varför är det inte så smart att använda en stack i det här fallet?
        ///     a) [Stackplats 1: Tom, stackplats 2: Tom, stackplats 3: Tom]
        ///     b) [Kalle, Tom, Tom]
        ///     c) [Kalle, Greta, Tom]
        ///     d) [Kalle, Tom, Tom]
        ///     e) [Kalle, Stina, Tom]
        ///     f) [Kalle, Tom, Tom]
        ///     g) [Kalle, Olle, Tom]
        ///     h) ...
        ///     
        ///     Sålänge nya människor dyker upp till stacken kommer Kalle aldrig att få hjälp. 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            ReverseText();
        }

        static void ReverseText()
        {
            Console.WriteLine("\nEnter a string to reverse with the help of a stack.");
            Stack<Char> theStack = new Stack<Char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
                theStack.Push(input[i]);
            }

            string reversedInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                reversedInput += theStack.Pop().ToString();
            }
            Console.WriteLine(reversedInput);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///4.1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper.
        ///     Du ska använda dig av någon eller några av de datastrukturer vi precis gått igenom.Vilken datastruktur använder du? 
        ///S:   För att kontrollera strängen behöver vi hålla koll på vilka vänster-brackets som använts och i vilken ordning de använts.
        ///     Om en högerbracket dyker upp vill vi kontrollera om den stänger den senast använda vänsterbracketen.
        ///     Om den gör det behöver vi inte längre hålla koll på den senaste vänster-bracketen. 
        ///     Därför passar en stack väldigt bra för ändamålet, då vi genom Push() lägger senaste vänsterbracket överst och genom Pop() 
        ///     kommer åt den senast använda vänsterbracketen igen. Dessutom håller vi enkelt reda på att varje vänster-bracket stängts iom
        ///     att endast öppna vänsterbrackets finns kvar i stacken. Är stacken inte tom efter körning så stängdes inte alla brackets.
        /// 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Checks whether a string is well formed or not in regards to the use of brackets.
        /// </summary>


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.WriteLine("\nEnter a string to check whether it is well formed with regards to brackets.");
            Stack<Char> bracketStack = new Stack<Char>();
            string input = Console.ReadLine();
            string verdict = "Strängen är välformad.";

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    bracketStack.Push(c);
                }
                else if (c == ')')
                {
                    if (bracketStack.Pop() != '(')
                    {
                        verdict = "Strängen är inte välformad.";
                        break;
                    }
                }
                else if (c == ']')
                {
                    if (bracketStack.Pop() != '[')
                    {
                        verdict = "Strängen är inte välformad.";
                        break;
                    }
                }
                else if (c == '}')
                {
                    if (bracketStack.Pop() != '{')
                    {
                        verdict = "Strängen är inte välformad.";
                        break;
                    }
                }
            }
            if (bracketStack.Count > 0)
            {
                verdict = "Strängen är inte välformad.";
            }
            Console.WriteLine(verdict);
        }

    }
}

