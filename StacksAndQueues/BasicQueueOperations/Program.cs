using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCommands = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var numbersAmountForAdd = inputCommands[0];
            var numbersAmountForRemove = inputCommands[1];
            var numberForContainCheck = inputCommands[2];

            var inputNumbers = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var numbersInQueue = new Queue<int>();

            AddNumbersToQueue(numbersAmountForAdd, inputNumbers, numbersInQueue);
            RemoveNumbersFromQueue(numbersAmountForRemove, numbersInQueue);

            if (numbersInQueue.Contains(numberForContainCheck))
            {
                Console.WriteLine("true");
            }
            else if (numbersInQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbersInQueue.Min());
            }

        }

        private static void RemoveNumbersFromQueue(int numbersAmountForRemove, Queue<int> numbersInQueue)
        {
            for (int i = 0; i < numbersAmountForRemove; i++)
            {
                numbersInQueue.Dequeue();
            }
        }

        private static void AddNumbersToQueue(int amountOfAddNumbers, int[] inputNumbers, Queue<int> numbersInQueue)
        {
            for (int i = 0; i < amountOfAddNumbers; i++)
            {
                numbersInQueue.Enqueue(inputNumbers[i]);
            }
        }
    }
}
