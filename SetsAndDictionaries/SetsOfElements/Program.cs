using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            // read the lenght of the sets from console
            var lenghtOfSets = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();
            int nSetLenght = lenghtOfSets[0];
            int mSetLenght = lenghtOfSets[1];

            nSet = AddFromConsoleToSet(nSet, nSetLenght);
            mSet = AddFromConsoleToSet(mSet, mSetLenght);

            var repeatingElementsInBothSets = nSet.Intersect(mSet);
            Console.WriteLine(string.Join(" ", repeatingElementsInBothSets));
        }

        private static HashSet<int> AddFromConsoleToSet(HashSet<int> set, int numberOfInputLines)
        {
            for (int i = 0; i < numberOfInputLines; i++)
            {
                set.Add
                    (int.Parse
                    (Console.ReadLine()));
            }

            return set;
        }
    }
}
