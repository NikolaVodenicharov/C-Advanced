using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = new HashSet<string>();
            usernames = ReadFromConsoleAddToCollection(usernames);

            StringBuilder forPrinting = new StringBuilder();
            forPrinting = AddFromCollectionToStringBuilder(usernames, forPrinting);

            Console.WriteLine(forPrinting);
        }

        private static HashSet<string> ReadFromConsoleAddToCollection(HashSet<string> collection)
        {
            int numberOfInputUsernames = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputUsernames; i++)
            {
                collection.Add(Console.ReadLine());
            }

            return collection;
        }

        private static StringBuilder AddFromCollectionToStringBuilder(HashSet<string> collection, StringBuilder sb)
        {
            foreach (var user in collection)
            {
                sb.AppendLine(user);
            }

            return sb;
        }
    }
}
