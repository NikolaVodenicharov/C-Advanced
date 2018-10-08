namespace RadioactiveBunnies
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static char[,] matrix;
        private static int matrixRows;
        private static int matrixColumns;

        private static bool isPlayerWon = false;

        private static int playerRow;
        private static int playerCol;

        public static void Main(string[] args)
        {
            ReadAndInitializeMatrix();
            ReadInputMatrix();

            matrixRows = matrix.GetLength(0);
            matrixColumns = matrix.GetLength(1);

            var moveCommands = Console.ReadLine().ToCharArray();
            var message = ExecuteMoveCommands(moveCommands);
            var matrixToString = MatrixToString();

            Console.WriteLine(matrixToString + message);
        }

        public static void ReadAndInitializeMatrix()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            matrix =  new char[rows, columns];
        }

        public static void ReadInputMatrix()
        {
            bool isPlayerPositionFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var symbol = line[col];

                    FillMatrix(row, col, symbol);

                    if (!isPlayerPositionFound)
                    {
                        isPlayerPositionFound = FindAndSetPlayerPosition(row, col, symbol);
                    }
                }
            }

            matrix[playerRow, playerCol] = '.';
        }
        private static void FillMatrix(int row, int col, char symbol)
        {
            matrix[row, col] = symbol;
        }
        private static bool FindAndSetPlayerPosition(int row, int col, char symbol)
        {
            if (symbol == 'P')
            {
                playerRow = row;
                playerCol = col;

                return true;
            }

            return false;
        }

        public static string ExecuteMoveCommands(char[] moveCommands)
        {
            foreach (var move in moveCommands)
            {
                MovePlayer(move);
                CreateBunnies();

                if (isPlayerWon)
                {
                    return $"won: {playerRow} {playerCol}";
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    return $"dead: {playerRow} {playerCol}";
                }
            }

            throw new ArgumentException("Not enought commands to finish the game.");
        }

        private static void MovePlayer(char moveCommand)
        {
            switch (moveCommand)
            {
                case 'L':
                    MovePlayerLeft();
                    break;
                case 'U':
                    MovePlayerUp();
                    break;
                case 'R':
                    MovePlayerRight();
                    break;
                case 'D':
                    MovePlayerDown();
                    break;
                default:
                    throw new InvalidOperationException("Invalid move command");
            }
        }
        private static void MovePlayerLeft()
        {
            if (playerCol - 1 < 0)
            {
                isPlayerWon = true;
            }
            else
            {
                playerCol--;
            }
        }
        private static void MovePlayerUp()
        {
            if (playerRow - 1 < 0)
            {
                isPlayerWon = true;
            }
            else
            {
                playerRow--;
            }
        }
        private static void MovePlayerRight()
        {
            if (playerCol + 1 >= matrixColumns)
            {
                isPlayerWon = true;
            }
            else
            {
                playerCol++;
            }
        }
        private static void MovePlayerDown()
        {

            if (playerRow + 1 >= matrixRows)
            {
                isPlayerWon = true;
            }
            else
            {
                playerRow++;
            }
        }

        private static void CreateBunnies()
        {
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixColumns; col++)
                {
                    switch (matrix[row, col])
                    {
                        case 'B':
                            CreateLetBunny(row, col);
                            CreateUpperBunny(row, col);
                            CreateRightBunny(row, col);
                            CreateBottomBunny(row, col);
                            break;

                        case 'b':
                            matrix[row, col] = 'B';
                            break;
                    }
                }
            }
        }
        private static void CreateLetBunny(int row, int col)
        {
            var previousCol = col - 1;
            if (previousCol >= 0)
            {
                matrix[row, previousCol] = 'B';
            }
        }
        private static void CreateUpperBunny(int row, int col)
        {
            var previousRow = row - 1;
            if (previousRow >= 0)
            {
                matrix[previousRow, col] = 'B';
            }
        }
        private static void CreateRightBunny(int row, int col)
        {
            var nextCol = col + 1;
            if (nextCol < matrixColumns && matrix[row, nextCol] != 'B')
            {
                matrix[row, nextCol] = 'b';
            }
        }
        private static void CreateBottomBunny(int row, int col)
        {
            var nextRow = row + 1;
            if (nextRow < matrixRows && matrix[nextRow, col] != 'B')
            {
                matrix[nextRow, col] = 'b';
            }
        }

        private static string MatrixToString()
        {
            var sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
