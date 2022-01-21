using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int divide = int.Parse(Console.ReadLine());
            numbers = numbers.Where(n => n % divide != 0).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
