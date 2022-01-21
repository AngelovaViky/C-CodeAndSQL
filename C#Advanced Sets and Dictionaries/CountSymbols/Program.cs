using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            char[] currChar = input.ToCharArray();
            for (int i = 0; i < currChar.Length; i++)
            {
                if (!text.ContainsKey(currChar[i]))
                {
                    text.Add(currChar[i], 0);
                }

                text[currChar[i]]++;
            }

            foreach (var item in text)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
