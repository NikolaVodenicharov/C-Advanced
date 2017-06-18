using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = new Dictionary<string, string>();
            phones = ReadFromConsoleAddToDictionary(phones);

            var forPrinting = new StringBuilder();
            forPrinting = ReadNamesAddOutputFormat(phones, forPrinting);

            Console.WriteLine(forPrinting);
        }

        private static StringBuilder ReadNamesAddOutputFormat(Dictionary<string, string> phones, StringBuilder sb)
        {
            while (true)
            {
                var name = Console.ReadLine();

                if (name.Equals("Stop", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                if (!phones.ContainsKey(name))
                {
                    sb.AppendLine($"Contact {name} does not exist.");
                }
                else
                {
                    sb.AppendLine($"{name} -> {phones[name]}");
                }
            }

            return sb;
        }

        private static Dictionary<string, string> ReadFromConsoleAddToDictionary(Dictionary<string, string> phones)
        {
            while (true)
            {
                var input = Console.ReadLine().Split('-');

                if (input.Contains("search", StringComparer.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    //var name = input[0];
                    //var telephoneNumber = input[1];
                    phones[input[0]] = input[1];
                }
            }

            return phones;
        }
    }
}
