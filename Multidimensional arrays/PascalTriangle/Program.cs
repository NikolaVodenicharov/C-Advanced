namespace PascalTriangle
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var triangle = new int[rows][];

            // initialize inner arrays
            for (int row = 0; row < rows; row++)
            {
                triangle[row] = new int[row + 1];
            }

            // start the triangle apex
            triangle[0][0] = 1;

            // fill triangle
            for (int row = 1; row < rows; row++)
            {
                var columns = triangle[row].Length;
                for (int col = 0; col < columns; col++)
                {
                    var upperLeft = col - 1 >= 0 ? triangle[row-1][col-1] : 0;
                    var upperRight = col < columns - 1 ? triangle[row-1][col] : 0;

                    var sum = upperLeft + upperRight;

                    triangle[row][col] = sum;
                }
            }

            // join numers
            var sb = new StringBuilder();
            foreach (var row in triangle)
            {
                sb.AppendLine(String.Join(" ", row));
            }

            Console.WriteLine(sb);
        }
    }
}
