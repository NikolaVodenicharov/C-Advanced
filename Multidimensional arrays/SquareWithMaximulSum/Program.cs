namespace SquareWithMaximulSum
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = ReadMatrix();

            var biggestSubmatrix = new int[2, 2];
            var biggestSubmatrixSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSubmatrixSum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];

                    if (currentSubmatrixSum > biggestSubmatrixSum)
                    {
                        biggestSubmatrix[0, 0] = matrix[row, col];
                        biggestSubmatrix[0, 1] = matrix[row, col + 1];
                        biggestSubmatrix[1, 0] = matrix[row + 1, col];
                        biggestSubmatrix[1, 1] = matrix[row + 1, col + 1];

                        biggestSubmatrixSum = currentSubmatrixSum;
                    }
                }
            }

            var sb = new StringBuilder();

            for (int row = 0; row < biggestSubmatrix.GetLength(0); row++)
            {
                for (int col = 0; col < biggestSubmatrix.GetLength(1); col++)
                {
                    sb.Append($"{biggestSubmatrix[row, col]} ");
                }
                sb.Replace(" ", "", (sb.Length - 2), 1);
                sb.AppendLine();
            }

            sb.AppendLine(biggestSubmatrixSum.ToString());

            Console.WriteLine(sb);
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
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
