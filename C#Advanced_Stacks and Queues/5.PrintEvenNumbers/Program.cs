using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> evenNumbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(i => i % 2 == 0));
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
