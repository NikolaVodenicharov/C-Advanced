using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumbersWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse);

            var numbers = new Stack<int>();

            foreach (var num in inputNumbers)
            {
                numbers.Push(num);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
