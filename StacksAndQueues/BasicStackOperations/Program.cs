using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var amountOfElementsForPush = inputInfo[0];
            var amountOfElementsForPop = inputInfo[1];
            var elementForContainChecking = inputInfo[2];

            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = new Stack<int>();
            for (int i = 0; i < amountOfElementsForPush; i++)
            {
                numbers.Push(inputNumbers[i]);
            }

            for (int i = 0; i < amountOfElementsForPop; i++)
            {
                numbers.Pop();
            }

            var isContained = numbers.Contains(elementForContainChecking);
            if (isContained)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
