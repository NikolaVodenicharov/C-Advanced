namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = ReadSqareMatrix();
            int difference = AbsDiagonalDifferences(matrix);
            Console.WriteLine(difference);
        }

        public static int[,] ReadSqareMatrix()
        {
            var squareSize = int.Parse(Console.ReadLine());

            var matrix = new int[squareSize, squareSize];

            for (int row = 0; row < squareSize; row++)
            {
                var inputRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < inputRow.Length; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            return matrix;
        }

        public static int AbsDiagonalDifferences(int[,] matrix)
        {
            var size = matrix.GetLength(0);

            var upperLeftToBottomRight = 0;
            for (int i = 0; i < size; i++)
            {
                upperLeftToBottomRight += matrix[i, i];
            }

            var upperRightToBottomLeft = 0;
            for (int i = 0; i < size; i++)
            {
                upperRightToBottomLeft += matrix[i, (size - 1 - i)];
            }

            var absDifference = Math.Abs(upperLeftToBottomRight - upperRightToBottomLeft);

            return absDifference;
        }
    }
}
