using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> range = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            Func<int, int> addNumber = n => n + 1;
            Func<int, int> multiplyNumber = n => n * 2;
            Func<int, int> subtractNumber = n => n - 1;
            Action<List<int>> printRange = n => Console.WriteLine(string.Join(" ", n));
            while (command != "end")
            {
                if (command == "add")
                {
                    range = range.Select(addNumber).ToList();
                }
                else if (command == "multiply")
                {
                    range = range.Select(multiplyNumber).ToList();
                }
                else if (command == "subtract")
                {
                    range = range.Select(subtractNumber).ToList();
                }
                else if (command == "print")
                {
                    printRange(range);
                }
                command = Console.ReadLine();
            }
        }
    }
}
