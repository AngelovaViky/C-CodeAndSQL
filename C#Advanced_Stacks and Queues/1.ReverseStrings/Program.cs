using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            if (input != null)
                for (int i = 0; i < input.Length; i++)
                {
                    stack.Push(input[i]);
                }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
