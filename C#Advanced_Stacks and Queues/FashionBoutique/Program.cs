using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesInBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(clothesInBox);
            int counter = 1;
            int sum = 0;
            while (clothes.Count > 0)
            {
                sum += clothes.Peek();
                if (sum <= capacity)
                {
                    clothes.Pop();
                }
                else
                {
                    counter++;
                    sum = 0;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
