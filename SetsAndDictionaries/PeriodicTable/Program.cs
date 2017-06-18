using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new SortedSet<string>();
            elements = ReadFromConsoleAddToSet(elements);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static SortedSet<string> ReadFromConsoleAddToSet(SortedSet<string> set)
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputLines; i++)
            {
                var input = Console.ReadLine().Split();
                foreach (var e in input)
                {
                    set.Add(e);
                }
            }

            return set;
        }
    }
}
