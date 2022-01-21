using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToList();

            Stack<char> stack = new Stack<char>();
            bool count = false;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        count = false;
                        break;
                    }
                    switch (input[i], stack.Peek())
                    {
                        case (')', '('):
                        case (']', '['):
                        case ('}', '{'):
                            stack.Pop();
                            count = true;
                            break;
                        default:
                            count = false;
                            break;
                    }
                }
            }
            if (count)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
