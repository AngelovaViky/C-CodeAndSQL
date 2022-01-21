using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int> result = PrintSmollestNumber;
            Console.WriteLine(result(numbers));
        }

        static int PrintSmollestNumber(int[] numbers)
        {
            int minValue = numbers.Min();
            return minValue;
        }
    }
}

