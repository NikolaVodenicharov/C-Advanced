using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int fibonacciPosition = int.Parse(Console.ReadLine());
        Console.WriteLine(GetFibonacciNumber(fibonacciPosition));
    }

    public static List<long> fibonacciSequence = new List<long>() { 1, 1 };
    public static long GetFibonacciNumber (int position)
    {
        while (position > fibonacciSequence.Count - 1)
        {
            fibonacciSequence.Add(fibonacciSequence[fibonacciSequence.Count - 1] +
                                    fibonacciSequence[fibonacciSequence.Count - 2]);
        }
        return fibonacciSequence[position];
    }
}
