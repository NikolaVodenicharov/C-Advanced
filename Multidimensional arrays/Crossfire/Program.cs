namespace Crossfire
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private const string EndCommand = "Nuke it from orbit";
        private static int[,] matrix;
        private static int matrixRows;
        private static int matrixColumns;
        private static int[] rowsLastIndex;

        public static void Main(string[] args)
        {
            InitializeAndFillMatrix();
            matrixRows = matrix.GetLength(0);
            matrixColumns = matrix.GetLength(1);

            InitializeAndFillRowsLastIndex();

            ExecuteCommands();
            var result = MatrixToString();
            Console.WriteLine(result);
        }



        private static void InitializeAndFillMatrix()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            var counter = 1;

            matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = counter++;
                }
            }

            
        }
        private static void InitializeAndFillRowsLastIndex()
        {
            rowsLastIndex = new int[matrixRows];

            for (int i = 0; i < matrixColumns; i++)
            {
                rowsLastIndex[i] = matrixColumns - 1;
            }
        }
        private static void ExecuteCommands()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command.Equals(EndCommand))
                {
                    break;
                }

                var commandParameters = command.Split().Select(int.Parse).ToArray();

                var targetRow = commandParameters[0];
                var targetColumn = commandParameters[1];
                var targetRange = commandParameters[2];

                DestroyCells(targetRow, targetColumn, targetRange);

                Console.WriteLine(MatrixToString());
            }
        }
        private static void DestroyCells(int targetRow, int targetColumn, int targetRange)
        {
            // vertical 
            DestroyVerticalLineOfCells(targetRow, targetColumn, targetRange);

            // horizontal
            DestroyHorizontalLineOfCells(targetRow, targetColumn, targetRange);
        }

        private static void DestroyHorizontalLineOfCells(int targetRow, int targetColumn, int targetRange)
        {
            var firstFreeColumn = Math.Max(0, (targetColumn - targetRange));
            var lastFreeColumn = Math.Min(rowsLastIndex[targetRow], (targetColumn + targetRange));

            var rowLastIndex = rowsLastIndex[targetRow];

            for (int col = firstFreeColumn; col <= lastFreeColumn; col++)
            {
                var replacementCol = col + targetRange + 1;

                if (col <= lastFreeColumn && replacementCol <= rowLastIndex)
                {
                    matrix[targetRow, col] = matrix[targetRow, replacementCol];
                }

                rowsLastIndex[targetRow] -= 1;
            }
        }

        private static void DestroyVerticalLineOfCells(int targetRow, int targetColumn, int targetRange)
        {
            var upperRow = Math.Max(0, (targetRow - targetRange));
            var lowestRow = Math.Min(matrixRows - 1, (targetRow + targetRange));

            for (int row = upperRow; row <= lowestRow; row++)
            {
                if (row == targetRow)
                {
                    continue;
                }

                for (int col = targetColumn; col < rowsLastIndex[row]; col++)
                {
                    matrix[row, col] = matrix[row, col + 1];
                }

                if (targetColumn <= rowsLastIndex[row])
                {
                    rowsLastIndex[row] -= 1;
                }
            }
        }

        private static string MatrixToString()
        {
            var sb = new StringBuilder();

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col <= rowsLastIndex[row]; col++)
                {
                    sb.Append($"{matrix[row, col]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
