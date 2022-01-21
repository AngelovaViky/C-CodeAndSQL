using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new Dictionary<int, int>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (!number.ContainsKey(currNum))
                {
                    number.Add(currNum, 0);
                }

                number[currNum]++;
            }

            var result = number.FirstOrDefault(x => x.Value % 2 == 0).Key;
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

