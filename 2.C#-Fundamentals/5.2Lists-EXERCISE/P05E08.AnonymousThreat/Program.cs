using System.Collections.Concurrent;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace P05E08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> result = new List<string>();
            string command = " ";
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = arguments[0];
                if (operation == "merge")
                {
                    Merge(arguments, input);
                }
                else if (operation == "divide")
                {
                    Divide(arguments, input);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static void Divide(string[] arguments, List<string> input)
        {
            int index = int.Parse(arguments[1]);
            int partitions = int.Parse(arguments[2]);

            if (index >= 0 && index < input.Count && partitions > 0)
            {
                string currentWord = input[index];
                input.RemoveAt(index);


                int partitionSize = currentWord.Length / partitions;
                int remainder = currentWord.Length % partitions;


                List<string> temp = new List<string>();
                int currentIndex = 0;

                for (int i = 0; i < partitions; i++)
                {
                    int currentPartSize = partitionSize + (i < remainder ? 1 : 0);
                    string part = currentWord.Substring(currentIndex, currentPartSize);
                    temp.Add(part);
                    currentIndex += currentPartSize;
                }
                input.InsertRange(index, temp);
            }
        }

        private static void Merge(string[] arguments, List<string> input)
        {
            int startIndex = int.Parse(arguments[1]);
            int endIndex = int.Parse(arguments[2]);

            startIndex = Math.Max(0, startIndex);
            endIndex = Math.Min(input.Count - 1, endIndex);

            if (startIndex <= endIndex && startIndex < input.Count)
            {
                string merged = string.Join("", input.Skip(startIndex).Take(endIndex - startIndex + 1));
                input.RemoveRange(startIndex, endIndex - startIndex + 1);
                input.Insert(startIndex, merged);
            }
        }
    }
}