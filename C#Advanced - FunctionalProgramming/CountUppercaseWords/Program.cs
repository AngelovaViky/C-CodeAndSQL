using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(s => s[0] == s.ToUpper()[0]).ToArray();
            Console.WriteLine(String.Join("\n", text));
        }
    }
}
