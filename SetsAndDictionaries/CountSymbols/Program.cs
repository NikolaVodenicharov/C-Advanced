using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbolsCount = new SortedDictionary<char, int>();
            symbolsCount = ReadFromConsoleAddToDictionary(symbolsCount);

            var forPrinting = new StringBuilder();
            forPrinting = GetFromDictionaryAddFormatToStringBuilder(symbolsCount, forPrinting);

            Console.WriteLine(forPrinting);
        }

        private static StringBuilder GetFromDictionaryAddFormatToStringBuilder(SortedDictionary<char, int> symbolsCount, StringBuilder sb)
        {
            foreach (var symbol in symbolsCount)
            {
                sb.AppendFormat($"{symbol.Key}: {symbol.Value} time/s" + Environment.NewLine);
            }

            return sb;
        }

        private static SortedDictionary<char, int> ReadFromConsoleAddToDictionary(SortedDictionary<char, int> dict)
        {
            var text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i];

                if (!dict.ContainsKey(ch))
                {
                    dict.Add(ch, 1);
                }
                else
                {
                    dict[ch] += 1;
                }
            }

            return dict;
        }
    }
}
