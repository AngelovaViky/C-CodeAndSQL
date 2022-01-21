using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueNames = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split(" ");
                for (int j = 0; j < name.Length; j++)
                {
                    uniqueNames.Add(name[j]);
                }
            }

            foreach (var name in uniqueNames)
            {
                Console.Write(name + " ");
            }
        }
    }
}
