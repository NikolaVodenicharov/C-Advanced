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
        private static bool isPlayerAlive = true;

        private static int playerRow;
        private static int playerCol;

        public static void Main(string[] args)
        {
            ReadAndInitializeMatrix();
            ReadAndFillMatrix();

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

        public static void ReadAndFillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        public static string ExecuteMoveCommands(char[] moveCommands)
        {
            FindPlayerPosition();

            // execute rounds
            for (int i = 0; i < moveCommands.Length && !isPlayerWon; i++)
            {
                MovePlayer(moveCommands[i]);
                SpreadBunnies();

                if (isPlayerWon)
                {
                    return $"won: {playerRow} {playerCol}";
                }
                else if (!isPlayerAlive)
                {
                    return $"dead: {playerRow} {playerCol}";
                }
            }

            throw new ArgumentException("Not enought commands to finish the game.");
        }

        private static void FindPlayerPosition()
        {
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixColumns; col++)
                {
                    var currentSymbol = matrix[row, col];

                    if (currentSymbol == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        return;
                    }
                }
            }

            throw new ArgumentException("There is no player in the matrix.");
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
            var previousCol = playerCol - 1;
            matrix[playerRow, playerCol] = '.';

            if (previousCol < 0)
            {
                isPlayerWon = true;
                return;
            }
            else if (matrix[playerRow, previousCol] == 'B')
            {
                isPlayerAlive = false;
            }
            else
            {
                matrix[playerRow, previousCol] = 'P';
            }

            playerCol = previousCol;

        }
        private static void MovePlayerUp()
        {
            var previousRow = playerRow - 1;
            matrix[playerRow, playerCol] = '.';

            if (previousRow < 0)
            {
                isPlayerWon = true;
                return;
            }
            else if (matrix[previousRow, playerCol] == 'B')
            {
                isPlayerAlive = false;
            }
            else
            {
                matrix[previousRow, playerCol] = 'P';
            }

            playerRow = previousRow;
        }
        private static void MovePlayerRight()
        {
            var nextCol = playerCol + 1;
            matrix[playerRow, playerCol] = '.';

            if (nextCol >= matrixColumns)
            {
                isPlayerWon = true;
                return;
            }
            else if (matrix[playerRow, nextCol] == 'B')
            {
                isPlayerAlive = false;
            }
            else
            {
                matrix[playerRow, nextCol] = 'P';
            }

            playerCol = nextCol;
        }
        private static void MovePlayerDown()
        {
            var nextRow = playerRow + 1;
            matrix[playerRow, playerCol] = '.';

            if (nextRow >= matrixRows)
            {
                isPlayerWon = true;
                return;
            }
            else if (matrix[nextRow, playerCol] == 'B')
            {
                isPlayerAlive = false;
            }
            else
            {
                matrix[nextRow, playerCol] = 'P';
            }

            playerRow = nextRow;
        }

        private static void SpreadBunnies()
        {
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixColumns; col++)
                {
                    var currentSymbol = matrix[row, col];

                    if (currentSymbol == 'B')
                    {
                        // CreateLeftBunny();
                        var previousCol = col - 1;
                        if (previousCol >= 0)
                        {
                            if (matrix[row, previousCol] == 'P')
                            {
                                isPlayerAlive = false;
                            }

                            matrix[row, previousCol] = 'B';
                        }

                        // up
                        var previousRow = row - 1;
                        if (previousRow >= 0)
                        {
                            if (matrix[previousRow, col] == 'P')
                            {
                                isPlayerAlive = false;
                            }

                            matrix[previousRow, col] = 'B';
                        }

                        // right
                        var nextCol = col + 1;
                        if (nextCol < matrixColumns)
                        {
                            if (matrix[row, nextCol] != 'B')
                            {
                                if (matrix[row, nextCol] == 'P')
                                {
                                    isPlayerAlive = false;
                                }

                                matrix[row, nextCol] = 'b';
                            }
                        }

                        // down
                        var nextRow = row + 1;
                        if (nextRow < matrixRows)
                        {
                            if
                                (matrix[nextRow, col] == '.')
                            {
                                if (matrix[nextRow, col] == 'P')
                                {
                                    isPlayerAlive = false;
                                }

                                matrix[nextRow, col] = 'b';
                            }
                        }
                    }
                    else if (currentSymbol == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
                }
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
