namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            int rotation = GetRotation();
            List<string> words = ReadWords();
            var longestWord = FindLongestWord(words);
            var matrix = FillMatrix(rotation, words, longestWord);
            var result = MatrixToString(matrix);
            Console.WriteLine(result);
        }

        private static int GetRotation()
        {
            var inputLine = Console.ReadLine();
            var regex = @"\d+";
            var match = Regex.Match(inputLine, regex);
            var parsedRotation = int.Parse(match.ToString());
            var rotation = parsedRotation % 360;

            return rotation;
        }

        private static List<string> ReadWords()
        {
            var words = new List<string>();

            while (true)
            {
                var word = Console.ReadLine();

                if (word.Equals("END"))
                {
                    break;
                }

                words.Add(word);
            }

            return words;
        }

        private static int FindLongestWord(ICollection<string> words)
        {
            var longestWord = 0;

            foreach (var word in words)
            {
                var len = word.Length;

                if (len > longestWord)
                {
                    longestWord = len;
                }
            }

            return longestWord;
        }

        private static char[,] FillMatrix(int rotation, List<string> words, int longestWord)
        {
            switch (rotation)
            {
                case 0:
                    return CreateMatrixDegree0(words, longestWord);
                case 90:
                    return CreateMatrixDegree90(words, longestWord);
                case 180:
                    return CreateMatrixDegree180(words, longestWord);
                case 270:
                    return CreateMatrixDegree270(words, longestWord);
                default:
                    throw new InvalidOperationException("The matrix is not filled.");
            }
        }
        private static char[,] CreateMatrixDegree0(List<string> words, int longestWord)
        {
            var matrix = new char[words.Count, longestWord];

            for (int row = 0; row < words.Count; row++)
            {
                for (int col = 0; col < longestWord; col++)
                {
                    if (col < words[row].Length)
                    {
                        matrix[row, col] = words[row][col];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            return matrix;
        }
        private static char[,] CreateMatrixDegree90(List<string> words, int longestWord)
        {
            var matrixRows = longestWord;
            var matrixColumns = words.Count;
            var matrix = new char[matrixRows, matrixColumns];

            for (int col = matrixColumns - 1; col >= 0; col--)
            {
                var wordIndex = words.Count - 1 - col;
                var word = words[wordIndex];

                for (int row = 0; row < matrixRows; row++)
                {
                    if (row < word.Length)
                    {
                        matrix[row, col] = word[row];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            return matrix;
        }
        private static char[,] CreateMatrixDegree180(List<string> words, int longestWord)
        {
            var matrixRows = words.Count;
            var matrixColumns = longestWord;
            var matrix = new char[matrixRows, matrixColumns];

            for (int row = matrixRows - 1; row >= 0; row--)
            {
                var wordIndex = words.Count - 1 - row;
                var word = words[wordIndex];

                for (int col = matrixColumns - 1; col >= 0; col--)
                {
                    var charIndex = longestWord - 1 - col;

                    if (charIndex < word.Length)
                    {
                        matrix[row, col] = word[charIndex];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            return matrix;
        }
        private static char[,] CreateMatrixDegree270(List<string> words, int longestWord)
        {
            var matrixRows = longestWord;
            var matrixColumns = words.Count;
            var matrix = new char[matrixRows, matrixColumns];

            for (int col = 0; col < matrixColumns; col++)
            {
                var wordIndex = col;
                var word = words[wordIndex];

                for (int row = matrixRows - 1; row >= 0; row--)
                {
                    var charIndex = longestWord - 1 - row;

                    if (charIndex < word.Length)
                    {
                        matrix[row, col] = word[charIndex];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static string MatrixToString(char[,] matrix)
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
