using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(", ").Select(decimal.Parse).Select(n => n * 1.2m).ToArray();
            foreach (var item in numbers)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
