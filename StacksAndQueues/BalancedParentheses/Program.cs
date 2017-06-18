using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var parentheses = Console.ReadLine();

            var leftPart = new Stack<char>();
            AddLeftPart(parentheses, leftPart);

            var isBalanced = true;

            for (int i = parentheses.Length / 2; i < parentheses.Length; i++)
            {
                char reversedSymbol = ReverseSymbol(parentheses, i);

                if (reversedSymbol != leftPart.Pop())
                {
                    isBalanced = false;
                    break;
                }
            }

            PrintIsBalanced(isBalanced);
        }

        private static void PrintIsBalanced(bool isBalanced)
        {
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static void AddLeftPart(string parentheses, Stack<char> leftPart)
        {
            for (int i = 0; i < parentheses.Length / 2; i++)
            {
                leftPart.Push(parentheses[i]);
            }
        }

        private static char ReverseSymbol(string parentheses, int indexInParentheses)
        {
            var symbol = parentheses[indexInParentheses];

            switch (symbol)
            {
                case '}':
                    symbol = '{';
                    break;
                case ')':
                    symbol = '(';
                    break;
                case ']':
                    symbol = '[';
                    break;
            }

            return symbol;
        }
    }
}
