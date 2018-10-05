namespace _2x2SquareInMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            var squareMatrixCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col]     == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        squareMatrixCount++;
                    }
                }
            }

            Console.WriteLine($"Number of square matrix is: {squareMatrixCount}");
        }

        public static char[,] ReadMatrix()
        {
            var size = ReadStrings();
            var rows = int.Parse(size[0]);
            var columns = int.Parse(size[1]);

            var matrix = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = ReadStrings();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputRow[col][0];
                }
            }

            return matrix;
        }

        public static string[] ReadStrings()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
