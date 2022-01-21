using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine()?.ToLower();
            while (command != "end")
            {
                if (command.Contains("add"))
                {
                    string[] elements = command.Split();
                    stack.Push(int.Parse(elements[1]));
                    stack.Push(int.Parse(elements[2]));
                }
                else if (command.Contains("remove"))
                {
                    string[] elements = command.Split();
                    if (int.Parse(elements[1]) <= stack.Count)
                    {
                        for (int i = 0; i < int.Parse(elements[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
