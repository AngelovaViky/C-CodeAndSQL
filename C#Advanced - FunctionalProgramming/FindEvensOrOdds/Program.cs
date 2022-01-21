using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listSize =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string option = Console.ReadLine();

            long min = listSize.Min();
            long max = listSize.Max();

            List<long> list = new List<long>();

            for (long i = min; i <= max; i++)
            {
                list.Add(i);
            }

            Predicate<long> even = x => { return x % 2 == 0; };
            Predicate<long> odd = x => { return x % 2 != 0; };

            List<long> result = new List<long>();
            if (option == "odd")
            {
                result = list.FindAll(odd);
            }
            else
            {
                result = list.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
