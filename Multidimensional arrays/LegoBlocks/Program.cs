namespace LegoBlocks
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rowsNumber = int.Parse(Console.ReadLine());

            var leftJaggedArray = ReadJaggedArray(rowsNumber);
            var rightJaggedArray = ReadJaggedArray(rowsNumber);

            var leftArraysLength = GetArraysength(leftJaggedArray, rowsNumber);
            var rightArraysLength = GetArraysength(rightJaggedArray, rowsNumber);

            if (IsJaggedArraysCompatable(leftArraysLength, rightArraysLength))
            {
                Console.WriteLine(ConcatenateJaggedArrays(leftJaggedArray, rightJaggedArray, rowsNumber));
            }
            else
            {
                var cellNumber = CalculateCellNumbers(leftJaggedArray, rightJaggedArray);
                Console.WriteLine($"The total number of cells is: {cellNumber}");
            }
        }

        public static string[][] ReadJaggedArray(int rowsNumber)
        {
            var jaggedArray = new string[rowsNumber][];
            for (int i = 0; i < rowsNumber; i++)
            {
                var line = Console.ReadLine().Split().ToArray();
                jaggedArray[i] = line;
            }

            return jaggedArray;
        }
        private static int[] GetArraysength(string[][] jaggedArray, int rows)
        {
            var arraysLength = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                arraysLength[i] = jaggedArray[i].Length;
            }

            return arraysLength;
        }
        private static bool IsJaggedArraysCompatable(int[] leftArraysLength, int[] rightArraysLength)
        {
            var firstRowSum = leftArraysLength[0] + rightArraysLength[0];

            for (int i = 1; i < leftArraysLength.Length; i++)
            {
                var nextRowSum = leftArraysLength[i] + rightArraysLength[i];

                if (firstRowSum != nextRowSum)
                {
                    return false;
                }
            }

            return true;
        }
        private static string ConcatenateJaggedArrays(string[][] leftJaggedArray, string[][] rightJaggedArray, int rowsNumber)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < rowsNumber; row++)
            {
                sb.Append('[');

                sb.Append(String.Join(", ", leftJaggedArray[row]));

                for (int i = rightJaggedArray[row].Length - 1; i >= 0; i--)
                {
                    sb.Append($", {rightJaggedArray[row][i]}");
                }

                sb.AppendLine("]");
            }

            return sb.ToString();
        }
        private static int CalculateCellNumbers(string[][] leftJaggedArray, string[][] rightJaggedArray)
        {
            int cellCount = 0;

            foreach (var arr in leftJaggedArray)
            {
                cellCount += arr.Length;
            }

            foreach (var arr in rightJaggedArray)
            {
                cellCount += arr.Length;
            }

            return cellCount;
        }
    }
}
