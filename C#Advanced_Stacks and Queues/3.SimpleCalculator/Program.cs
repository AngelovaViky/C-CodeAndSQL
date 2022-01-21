using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(' ').Reverse().ToArray();
            Stack<string> stack = new Stack<string>(expression);

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string sing = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                switch (sing)
                {
                    case "+":
                        stack.Push((num1 + num2).ToString());
                        break;

                    case "-":
                        stack.Push((num1 - num2).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
