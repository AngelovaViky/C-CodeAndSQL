using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            names = names.Where(n => n.Length <= nameLenght).ToList();
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
