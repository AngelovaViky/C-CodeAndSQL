using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            ReadMatrix(matrix);

            int replased = 0;
            int currRow = 0;
            int currCol = 0;
            while (true)
            {
                int maxAttack = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int currChar = matrix[row, col];
                        int countAttack = 0;
                        if (currChar == 'K')
                        {
                            countAttack = GetAttacks(matrix, row, col, countAttack);

                            if (countAttack > maxAttack)
                            {
                                maxAttack = countAttack;
                                currRow = row;
                                currCol = col;
                            }
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    matrix[currRow, currCol] = '0';
                    replased++;
                }
                else
                {
                    Console.WriteLine(replased);
                    break;
                }
            }

        }

        private static int GetAttacks(char[,] matrix, int row, int col, int countAttack)
        {
            if (IsOutOfRange(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
            {
                countAttack++;
            }

            if (IsOutOfRange(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
            {
                countAttack++;
            }

            return countAttack;
        }

        public static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        public static bool IsOutOfRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}

