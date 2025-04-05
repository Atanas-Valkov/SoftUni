using System.Reflection.Metadata.Ecma335;

namespace P05L06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = " ";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandSplit = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandSplit[0];
                int number = int.Parse(commandSplit[1]);

                if (action == "Add")
                {
                    input.Add(number);
                }
                else if (action == "Remove")
                {
                    input.Remove(number);
                }
                else if (action == "RemoveAt")
                {
                    input.RemoveAt(number);
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commandSplit[2]);
                    input.Insert(index,number);
                }
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}