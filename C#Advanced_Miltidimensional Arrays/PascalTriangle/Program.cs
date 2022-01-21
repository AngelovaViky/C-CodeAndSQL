using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long[][] triangle = new long[number + 1][];

            for (int row = 0; row < number; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[0][0] = 1;
            }
            for (int row = 0; row < number - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
