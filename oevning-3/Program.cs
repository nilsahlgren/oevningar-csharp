using Microsoft.VisualBasic;
using oevning_3._3_Inheritance;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace oevning_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //1.1 a) Skapa publika properties med get och set som hämtar eller sätter tilldelad variabel.
            //      Instansiera en person i Program.cs, kommer du direkt åt variablerna ?
            Person person = new Person("Kalle", "Andersson");
            person.Age = 99;
            //Console.WriteLine(person.age); <- "Person.age is inaccessible due to it's protection level"
            Console.WriteLine(person.Age); //<- fungerar, skriver ut 99 i consolen

            //1.1 b) Implementera validering i de skapade properties
            try
            {
                person.Age = -5;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                person.FName = "Superlångt namn";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                person.LName = "Ännu längre superlångt namn";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{person.FName} {person.LName}, {person.Age} år");
            Console.WriteLine();

            //1.5 Instansiera en PersonHandler, skapa några personer och testa metoderna.
            PersonHandler handler = new PersonHandler();
            Person person1 = handler.CreatePerson(55, "Jonas", "Svensson", 179.5, 75);
            Person person2 = handler.CreatePerson(16, "Micke", "Svensson", 200, 79);
            handler.SetAge(person1, 20);
            handler.SetFName(person1, "Jenny");
            handler.SetLName(person2, "Jonsson");
            handler.SetHeight(person2, 138.5);
            handler.SetWeight(person2, 44);
            handler.PrintFullDetails(person1);
            Console.WriteLine();
            handler.PrintFullDetails(person2);
            Console.WriteLine("\n");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //2.7 Skapa en lista med UserErrors och populera den med instanser av NumericInputError och TextInputError.
            List<UserError> userErrors = new List<UserError> {new TextInputError(), new NumericInputError(), new TextInputError()};

            //2.8 Skriv ut samtliga UserErrors UEMessage() genom en foreach loop.
            foreach (UserError error in userErrors)
            {
                Console.WriteLine(error.UEMessage());
            }
            Console.WriteLine();

            //3.9 Skapa nu tre egna klasser med tre egna definitioner på UEMessage()
            List<UserError> userErrors2 = new List<UserError> {new InputError3(), new InputError4(), new InputError5()};

            //3.10 Testa och se så det fungerar
            foreach (UserError error in userErrors2)
            {
                Console.WriteLine(error.UEMessage());
            }
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //3. 13 F: Om vi under utvecklingen kommer fram till att samtliga fåglar behöver ett nytt attribut, i vilken klass bör vi lägga det ?
            //      S: I klassen Bird

            //3. 14 F: Om alla djur behöver det nya attributet, vart skulle man lägga det då ?
            //      S: I klassen Animal

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //4.3 Skapa en lista Animals i Program.cs som tar emot djur.
            //4.4 Skapa några djur(av olika typ) i din lista.
            
            List<Animal> zoo = new List<Animal>();
            zoo.Add(new Dog("Boris", 12, 15, "Woof", 0.5));
            zoo.Add(new Hedgehog("Sigge", 3, 0.5, "Squeak", 10000));
            zoo.Add(new Horse("Click Bait", 6, 600, "Wui-Hihi", "Trotter"));
            zoo.Add(new Flamingo("Flamman", 2, 4, "Kra-Kra", 1.5, "Right"));
            zoo.Add(new Wolfman("Wolverine", 32, 100, "Aooouuuh", 30));

            //4.5 Skriv ut vilka djur som finns i listan med hjälp av en foreach-loop
            //4.6 Anropa även Animals Sound() metod i foreach-loopen.
            //4.7 Gör en check i for-loopen ifall ett djur även är av typen IPerson, om den är det type - casta till IPerson och anropa dess Talk() metod
            foreach (Animal animal in zoo)
            {
                Console.WriteLine($"A {animal.GetType()} named {animal.Name} who says:");
                animal.DoSound();
                if (animal is IPerson iperson)
                {
                   iperson.Talk();
                }
            }
            Console.WriteLine();
            //3.8 Skapa en lista för hundar.
            List<Dog> dogs = new List<Dog>();
            //3.9 F: Försök att lägga till en häst i listan av hundar. Varför fungerar inte det?
            //dogs.Add(new Horse("Click Bait", 6, 600, "Wui-Hihi", "Trotter")) // <- "Cannot convert from Horse to Dog"
            //    S: Dog och Horse är två olika subklasser till animal, de har en syskonrelation. Horse hade behövt vara ett barn till Dog för att det ska funka.
            //3.10 F: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans ?
            //     S: Animal

            //11.Skriv ut samtliga Animals Stats() genom en foreach loop.
            //12.Testa och se så det fungerar.
            foreach (Animal animal in zoo)
            {
                Console.WriteLine(animal.Stats());
            }
            Console.WriteLine();
            //3.13 F: Förklara vad det är som händer.
            //     S: för varje animal i listan zoo så anropas metoden Stats(), vilken finns skriven i varje klass och därför skriver ut samtliga properties inklusive de unika för respektive djur. 

            //3.14 Skriv ut Stats() metoden enbart för alla hundar genom en foreach på Animals.
            foreach (Animal animal in zoo)
            {
                if (animal is Dog)
                {
                    Console.WriteLine(animal.Stats());
                }
            }
            Console.WriteLine();

            //3.15 Skapa en ny metod med valfritt namn i klassen Dog som endast returnerar en valfri sträng.
            //3.16 Kommer du åt den metoden från Animals listan ?
            //zoo.UniqueDogMethod() // <- List<Animal> does not contain a definition for UniqueDogMethod()
            //3.17 F: Varför inte ?
            //     S: Metoden är definierad på klassen dog, zoo är ett objekt av klassen (?) List<Animal>.

            //18.Hitta ett sätt att skriva ut din nya metod för dog genom en foreach på Animals.

            foreach (Animal animal in zoo)
            {
                if (animal is Dog dog)
                {
                    Console.WriteLine(dog.UniqueDogMethod());
                }
            }
        }
    }
}