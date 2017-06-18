using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal startingNumber = decimal.Parse(Console.ReadLine());

            // here we will add and remove numbers that we calculate
            var calculateNumbers = new Queue<decimal>();
            calculateNumbers.Enqueue(startingNumber);

            // here we will keep all numbers that we calculate
            var sequence = new List<decimal>();
            sequence.Add(startingNumber);

            while (sequence.Count < 50)
            {
                var baseForFormula = calculateNumbers.Dequeue();

                var firstFormula = baseForFormula + 1;
                calculateNumbers.Enqueue(firstFormula);
                sequence.Add(firstFormula);

                var secondFormula = 2 * baseForFormula + 1;
                calculateNumbers.Enqueue(secondFormula);
                sequence.Add(secondFormula);

                var thirdFormula = baseForFormula + 2;
                calculateNumbers.Enqueue(thirdFormula);
                sequence.Add(thirdFormula);
            }

            var first50Numbers = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                first50Numbers.Append(sequence[i]);
                if (i < 49)
                {
                    first50Numbers.Append(" ");
                }
            }
            Console.WriteLine(first50Numbers.ToString());
        }
    }
}
