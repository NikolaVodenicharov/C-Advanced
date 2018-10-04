namespace MultidimensionalArrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = ReadMatrix();

            Console.WriteLine($"Number of rows: {matrix.GetLength(0)}");
            Console.WriteLine($"Number of columns: {matrix.GetLength(1)}");
            Console.WriteLine($"Sum of numbers: {SumMatrixNumbers(matrix)}");
        }

        private static int SumMatrixNumbers(int[,] matrix)
        {
            var sum = 0;

            foreach (var num in matrix)
            {
                sum += num;
            }

            return sum;
        }

        public static int[,] ReadMatrix()
        {
            var size = ReadNumbers();
            var rows = size[0];
            var columns = size[1];

            var matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = ReadNumbers();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            return matrix;
        }

        public static int[] ReadNumbers()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
