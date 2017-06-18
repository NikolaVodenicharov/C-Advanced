using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountOfInputs = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>(); // contains the numbers
            var biggestNum = new Stack<int>(); // contains the biggest number from "numbers"
            var answer = new StringBuilder();
            
            for (int i = 0; i < amountOfInputs; i++)
            {
                var inputInfo = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                var command = inputInfo[0];
                switch (command)
                {
                    case 1:     //add number
                        var number = inputInfo[1];
                        numbers.Push(number);
                        AddNumIfItsBiggest(biggestNum, number);
                        break;

                    case 2:     // remove number

                        // if last number in "numbers" the biggest number, remove it from "biggestNum".
                        var lastNumber = numbers.Peek();
                        if (lastNumber == biggestNum.Peek())
                        {
                            biggestNum.Pop();
                        }

                        numbers.Pop();
                        break;

                    case 3:     // print biggest number
                        answer.AppendLine(biggestNum.Peek().ToString());
                        break;

                }
            }

            Console.WriteLine(answer.ToString());
        }

        private static void AddNumIfItsBiggest(Stack<int> biggestNum, int currentNumber)
        {
            if (biggestNum.Count == 0 ||
                currentNumber > biggestNum.Peek())
            {
                biggestNum.Push(currentNumber);
            }
        }
    }
}
