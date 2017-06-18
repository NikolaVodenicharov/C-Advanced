using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibonacciPosition = int.Parse(Console.ReadLine());
            var fibonacciSequence = new Stack<long>();
            fibonacciSequence.Push(1);
            fibonacciSequence.Push(1);

            while (fibonacciPosition > fibonacciSequence.Count - 1)
            {
                var lastNumber = fibonacciSequence.Pop();
                var nextNumber = lastNumber + fibonacciSequence.Peek();
                fibonacciSequence.Push(lastNumber);
                fibonacciSequence.Push(nextNumber);
            }

            Console.WriteLine(fibonacciSequence.Peek());
        }
    }
}
