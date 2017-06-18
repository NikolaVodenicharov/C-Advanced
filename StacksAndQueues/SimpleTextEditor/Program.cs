using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var executedCommands = new Stack<string>();
            executedCommands.Push(string.Empty);
            var forPrinting = new StringBuilder();

            int numberOfInputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputLines; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = int.Parse(input[0]);

                switch (command)
                {
                    case 1: // string to the end of the text
                        executedCommands.Push(executedCommands.Peek() + input[1]);
                        break;

                    case 2: // erases the last count elements from the text
                        var numberOfElementsForErase = int.Parse(input[1]);
                        var textForEdition = executedCommands.Peek();
                        var editedText = textForEdition.Remove(textForEdition.Length - numberOfElementsForErase);
                        executedCommands.Push(editedText);
                        break;

                    case 3: // returns the element at position index from the text
                        var indexAt = int.Parse(input[1]);
                        var text = executedCommands.Peek();
                        var symbol = text.Substring(indexAt - 1, 1);
                        forPrinting.AppendLine(symbol);
                        break;

                    case 4: // undo the last command
                        executedCommands.Pop();
                        break;

                }

                if (executedCommands.Count > 20)
                {
                    var reducedExecutedCommands = new Stack<string>();
                    for (int j = 0; j < 10; j++)
                    {
                        reducedExecutedCommands.Push(executedCommands.Pop());
                    }

                    executedCommands.Clear();

                    foreach (var com in reducedExecutedCommands)
                    {
                        executedCommands.Push(com);
                    }
                }
            }

            Console.WriteLine(forPrinting);
        }


    }
}
