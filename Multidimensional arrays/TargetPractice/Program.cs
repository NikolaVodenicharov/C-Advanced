namespace TargetPractice
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = ReadEmptyMatrix();
            FillMatrix(matrix);
            ShootMatrix(matrix);
            FallMatrixChars(matrix);

            Console.WriteLine(MatrixToString(matrix));
        }

        public static char[,] ReadEmptyMatrix()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            return new char[rows, columns];
        }
        public static void FillMatrix(char[,] matrix)
        {
            var symbols = Console.ReadLine().ToCharArray();
            var counter = 0;
            var isFromRightToLeft = true;

            for (int row = matrix.GetLength(0) - 1; row >=0; row--)
            {
                if (isFromRightToLeft)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        // extract method here
                        var index = counter % symbols.Length;
                        counter++;
                        var symbol = symbols[index];

                        matrix[row, col] = symbol;
                    }

                    isFromRightToLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var index = counter % symbols.Length;
                        counter++;
                        var symbol = symbols[index];

                        matrix[row, col] = symbol;
                    }

                    isFromRightToLeft = true;
                }
            }
        }

        public static void ShootMatrix(char[,] matrix)
        {
            var shoot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var shootRow = shoot[0];
            var shootColumn = shoot[1];
            var shootRange = shoot[2];

            //upper part
            for (int row = 0; row <= shootRange; row++)
            {
                for (int col = (shootRange - row); col <= (shootRange + row); col++)
                {
                    var adjustRow = row + (shootRow - shootRange);
                    var adjustCol = col + (shootColumn - shootRange);

                    if (adjustRow < 0 || adjustCol < 0)
                    {
                        continue;
                    }

                    matrix[adjustRow, adjustCol] = ' ';
                }
            }

            //down part
            for (int row = 0; row < shootRange; row++)
            {
                for (int col = row + 1; col < (shootRange * 2  - row); col++)
                {
                    var translateRow = row + shootRange + 1;

                    var adjustRow = translateRow + (shootRow - shootRange);
                    var adjustCol = col + (shootColumn - shootRange);

                    if (adjustRow < 0 || adjustCol < 0)
                    {
                        continue;
                    }

                    matrix[adjustRow, adjustCol] = ' ';
                }
            }

        }

        public static void FallMatrixChars(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        MoveColumnChars(matrix, col, row);

                        break;
                    }
                }
            }
        }
        private static void MoveColumnChars(char[,] matrix, int col, int row)
        {
            var nextFreePosition = row;

            for (int r = row - 1; r >= 0; r--)
            {
                if (matrix[r, col] != ' ')
                {
                    matrix[nextFreePosition, col] = matrix[r, col];
                    nextFreePosition--;
                }
            }

            matrix[0, col] = ' ';
        }

        public static string MatrixToString(char[,] matrix)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append($"{matrix[row, col]} ");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
