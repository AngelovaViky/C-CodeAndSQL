using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPomps = int.Parse(Console.ReadLine());
            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < numPomps; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }

            int totalFuel = 0;
            for (int i = 0; i < numPomps; i++)
            {
                string dequeue = circle.Dequeue();
                var info = dequeue.Split().Select(int.Parse).ToArray();

                int fuel = info[0];
                int distance = info[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                circle.Enqueue(dequeue);
            }

            var index = circle.Dequeue().Split().ToArray();
            Console.WriteLine(index[2]);
        }
    }
}
