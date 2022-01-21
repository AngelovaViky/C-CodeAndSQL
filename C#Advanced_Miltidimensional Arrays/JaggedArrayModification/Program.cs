using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(number, number);
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input.Contains("Add"))
                {
                    string[] command = input.Split("Add ").ToArray();
                    string[] array = command[1].Split(" ").ToArray();
                    int row = int.Parse(array[0]);
                    int col = int.Parse(array[1]);
                    int curNumber = int.Parse(array[2]);
                    if (row >= 0 && row < array.Length && col >= 0 && col < array.Length)
                    {
                        matrix[row, col] += curNumber;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input.Contains("Subtract"))
                {
                    string[] command = input.Split("Subtract ").ToArray();
                    string[] array = command[1].Split(" ").ToArray();
                    int row = int.Parse(array[0]);
                    int col = int.Parse(array[1]);
                    int curNumber = int.Parse(array[2]);

                    if (row >= 0 && row < array.Length && col >= 0 && col < array.Length)
                    {
                        matrix[row, col] -= curNumber;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                input = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

