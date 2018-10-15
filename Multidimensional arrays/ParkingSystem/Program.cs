namespace ParkingSystem
{
    using System;
    using System.Linq;

    public class Program
    {
        private const string EndCommand = "stop";
        private static char[,] parking;

        public static void Main(string[] args)
        {
            InitializeParking();
            ExecuteCommands();
        }

        private static void InitializeParking()
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            parking = new char[rows, columns];
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

                var splitCommands = command.Split().Select(int.Parse).ToArray();
                var startingRow = splitCommands[0];
                var targetRow = splitCommands[1];
                var targetColumn = splitCommands[2];

                var counter = 1;
                counter += Math.Abs(startingRow - targetRow);
                counter += targetColumn;

                if (parking[targetRow, targetColumn] != 'C')
                {
                    parking[targetRow, targetColumn] = 'C';
                    Console.WriteLine(counter);
                }
                else
                {
                    counter = FindAnoterFreeParkingPlace(targetRow, targetColumn, counter);
                }
            }
        }

        private static int FindAnoterFreeParkingPlace(int targetRow, int targetColumn, int counter)
        {
            var range = 1;

            while (true)
            {
                var leftColumn = targetColumn - range;
                var rightColumn = targetColumn + range;

                var isLeftOutOfRange = leftColumn < 1;
                var isRightOutOfRange = rightColumn >= parking.GetLength(1);

                if (isLeftOutOfRange && isRightOutOfRange)
                {
                    Console.WriteLine($"Row {targetRow} full");
                    break;
                }
                else if (!isLeftOutOfRange && parking[targetRow, leftColumn] != 'C')
                {
                    parking[targetRow, leftColumn] = 'C';
                    Console.WriteLine(counter -= range);
                    break;
                }
                else if (!isRightOutOfRange && parking[targetRow, rightColumn] != 'C')
                {
                    parking[targetRow, rightColumn] = 'C';
                    Console.WriteLine(counter += range);
                    break;
                }

                range++;
            }

            return counter;
        }
    }
}
