using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Reflection;

namespace P05L07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string line = " ";
            while ((line = Console.ReadLine()) != "end")
            {
                if (line == "end")
                {
                    break;
                }

                string[] commands = line.Split();

                if (commands[0] == "Contains")
                {
                    int containsTheNumber = int.Parse(commands[1]);

                    if (list.Contains(containsTheNumber) == true)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commands[0] == "PrintEven")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 == 0)
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (commands[0] == "PrintOdd")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 == 1)
                        {
                            Console.Write(list[i] + " ");
                        }
                    }

                    Console.WriteLine();
                }
                else if (commands[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        sum += list[i];
                    }

                    Console.WriteLine(sum);

                }
                else if (commands[0] == "Filter")
                {
                    string symbol = commands[1];
                    int filter = int.Parse(commands[2]);
                    if (symbol == ">")
                    {
                        Console.WriteLine(string.Join(" ", list.FindAll(x => x > filter)));
                    }
                    else if (symbol == ">=")
                    {
                        Console.WriteLine(string.Join(" ", list.FindAll(x => x >= filter)));
                    }
                    else if (symbol == "<")
                    {
                        Console.WriteLine(string.Join(" ", list.FindAll(x => x < filter)));
                    }
                    else if (symbol == "<=")
                    {
                        Console.WriteLine(string.Join(" ", list.FindAll(x => x <= filter)));
                    }
                }
                else if (commands[0] == "Add")
                {
                    int numberToAdd = int.Parse(commands[1]);
                    list.Add(numberToAdd);
                    
                    Console.WriteLine(string.Join(" ", list));
                }
                else if (commands[0] == "Remove")
                {
                    int numberToRemove = int.Parse(commands[1]);
                    list.Remove(numberToRemove);
                    
                   Console.WriteLine(string.Join(" ", list));
                }
                else if (commands[0] == "RemoveAt")
                {
                    int numberToRemoveIndex = int.Parse(commands[1]);
                    list.RemoveAt(numberToRemoveIndex);
                    
                    Console.WriteLine(string.Join(" ", list));
                }
                else if (commands[0] == "Insert")
                {
                    int numberToInsert = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    list.Insert(index, numberToInsert);
                    
                   Console.WriteLine(string.Join(" ", list));
                }
            }
        }
    }
}

