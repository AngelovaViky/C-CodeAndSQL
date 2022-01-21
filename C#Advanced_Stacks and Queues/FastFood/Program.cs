using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] quantityOrders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(quantityOrders);
            int sum = 0;
            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                var food = orders.Peek();

                sum += food;
                if (quantityFood >= sum)
                {
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", orders.ToArray())}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
