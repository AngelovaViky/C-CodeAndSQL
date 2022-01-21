using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            ReadMatrix(matrix);
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char cur = matrix[row, col];
                    if (cur == matrix[row, col + 1] && cur == matrix[row + 1, col + 1] && cur == matrix[row + 1, col])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}

