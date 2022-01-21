using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string[]> people = PrintPeople;
            people(names);
        }

        static void PrintPeople(string[] people)
        {
            foreach (var name in people)
            {
                Console.WriteLine(name);
            }
        }
    }
}

