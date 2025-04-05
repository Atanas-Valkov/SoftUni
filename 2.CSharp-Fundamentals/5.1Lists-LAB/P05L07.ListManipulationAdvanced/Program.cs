using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Reflection;


/*
5 34 678 67 5 563 98
Contains 23
PrintOdd
GetSum
Filter >= 21
end

2 13 43 876 342 23 543
Contains 100
Contains 543
PrintEven
PrintOdd
GetSum
Filter >= 43
Filter < 100
end

 */
namespace P05L07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            bool ifMadeChanges = false;
            string command = " ";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandSplit = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandSplit[0];

                if (action == "Contains")
                {
                    int number = int.Parse(commandSplit[1]);
                    if (input.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine($"No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            Console.Write(input[i] + " ");
                        }
                    }
                }
                else if (action == "PrintOdd")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 != 0)
                        {
                            Console.Write(input[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (action == "GetSum")
                {
                    Console.WriteLine(input.Sum());
                }
                else if (action == "Filter")
                {
                    string sign = commandSplit[1];
                    int number = int.Parse(commandSplit[2]);

                    if (sign == "<")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] < number)
                            {
                                Console.Write(input[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (sign == ">")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] > number)
                            {
                                Console.Write(input[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (sign == ">=")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] >= number)
                            {
                                Console.Write(input[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (sign == "<=")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] <= number)
                            {
                                Console.Write(input[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }

                }
                else if (action == "Add")
                {
                    int number = int.Parse(commandSplit[1]);
                    input.Add(number);
                    ifMadeChanges = true;
                }
                else if (action == "Remove")
                {
                    int number = int.Parse(commandSplit[1]);
                    input.Remove(number);
                    ifMadeChanges = true;
                }
                else if (action == "RemoveAt")
                {
                    int number = int.Parse(commandSplit[1]);
                    input.RemoveAt(number);
                    ifMadeChanges = true;
                }
                else if (action == "Insert")
                {
                    int number = int.Parse(commandSplit[1]);
                    int index = int.Parse(commandSplit[2]);
                    input.Insert(index, number);
                    ifMadeChanges = true;
                }
            }
            if (ifMadeChanges)
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}

