namespace RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var baseMatrix = ReadRubiksMatrix();
            var operativeMatrix = (int[,])baseMatrix.Clone();

            ExecuteInputCommands(operativeMatrix);
            Console.WriteLine();
            DisplayMatrix(operativeMatrix);

            var result = SwapMatrixPositions(baseMatrix, operativeMatrix);
            Console.WriteLine(result);
        }

        public static int[,] ReadRubiksMatrix()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            return CreateRubikMatrix(rows, columns);
        }
        public static int[,] CreateRubikMatrix(int rows, int columns)
        {
            var matrix = new int[rows, columns];
            var number = 1;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = number++;
                }
            }

            return matrix;
        }

        public static void ExecuteInputCommands(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var commandsNumer = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNumer; i++)
            {
                var command = Console.ReadLine().Split().ToArray();
                var position = int.Parse(command[0]);
                var direction = command[1];
                var movesNumber = int.Parse(command[2]) % rows;

                if (direction == "up")
                {
                    var tempNumbs = GetTempVerticalLine(matrix, rows, position);

                    for (int row = 0; row < rows; row++)
                    {
                        matrix[((rows + row - movesNumber) % rows), position] = tempNumbs[row];
                    }
                }
                else if (direction == "down")
                {
                    var tempNumbs = GetTempVerticalLine(matrix, rows, position);

                    for (int row = 0; row < rows; row++)
                    {
                        matrix[((row + movesNumber) % rows), position] = tempNumbs[row];
                    }
                }
                else if (direction == "left")
                {
                    var tempNumbs = GetTempHorizontalLine(matrix, columns, position);

                    for (int col = 0; col < columns; col++)
                    {
                        matrix[position, ((columns + col - movesNumber) % columns)] = tempNumbs[col];
                    }
                }
                else if (direction == "right")
                {
                    var tempNumbs = GetTempHorizontalLine(matrix, columns, position);

                    for (int col = 0; col < columns; col++)
                    {
                        matrix[position, ((col + movesNumber) % columns)] = tempNumbs[col];
                    }
                }
                else
                {
                    // throw exception ?
                }
            }
        }
        public static T[] GetTempVerticalLine<T> (T[,] matrix, int rows, int position)
        {
            var tempLine = new T[rows];
            for (int row = 0; row < rows; row++)
            {
                tempLine[row] = matrix[row, position];
            }

            return tempLine;
        }
        public static T[] GetTempHorizontalLine<T>(T[,] matrix, int columns, int position)
        {
            var tempLine = new T[columns];
            for (int col = 0; col < columns; col++)
            {
                tempLine[col] = matrix[position, col];
            }

            return tempLine;
        }

        public static string SwapMatrixPositions<T> (T[,] baseMatrix, T[,] operativeMatrix)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < operativeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < operativeMatrix.GetLength(1); col++)
                {
                    var baseElement = baseMatrix[row, col];
                    var operativeElement = operativeMatrix[row, col];

                    if (baseElement.Equals(operativeElement))
                    {
                        sb.AppendLine("No swap required");
                        continue;
                    }

                    var position = Some(baseElement, operativeMatrix, row, col);
                    var searchedRow = position.Item1;
                    var searchedCol = position.Item2;

                    var temp = operativeElement;

                    operativeMatrix[row, col] = operativeMatrix[searchedRow, searchedCol];
                    operativeMatrix[searchedRow, searchedCol] = temp;

                    sb.AppendLine($"Swap ({row}, {col}) with ({searchedRow}, {searchedCol})");
                }
            }

            return sb.ToString();
        }

        public static Tuple<int, int> Some<T>(T baseElement, T[,] operativeMatrix, int currentRow, int currentCol)
        {
            for (int row = currentRow; row < operativeMatrix.GetLength(0); row++)
            {
                var colModificator = row == currentRow ? currentCol + 1 : 0;
                for (int col = colModificator; col < operativeMatrix.GetLength(1); col++)
                {
                    var element = operativeMatrix[row, col];

                    if (element.Equals(baseElement))
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }

            return null;
        }

        public static void DisplayMatrix<T>(T[,] matrix)
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

            Console.WriteLine(sb);
        }

    }
}
