namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            string[,] matrix = FillMatrix(rows, columns);
            StringBuilder sb = MatrixToPrintFormat(matrix);

            Console.WriteLine(sb);
        }

        private static StringBuilder MatrixToPrintFormat(string[,] matrix)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    sb.Append($"{matrix[row, column]} ");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }

            return sb;
        }

        private static string[,] FillMatrix(int rows, int columns)
        {
            var matrix = new string[rows, columns];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var firstChar = alphabet[row];
                    var secondChar = alphabet[row + column];
                    var thirdChar = alphabet[row];

                    matrix[row, column] = $"{firstChar}{secondChar}{thirdChar}";
                }
            }

            return matrix;
        }
    }
}
