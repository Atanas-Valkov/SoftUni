using System;
using System.ComponentModel;
using System.Net;

namespace P05E04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string commands;

            while ((commands = Console.ReadLine()) != "End")
            {
                string[] operations = commands.Split();
                if (operations[0] == "End")
                {
                    break;
                }
                if (operations[0] == "Add")
                {
                    int numberToAdd = int.Parse(operations[1]);
                    listOfIntegers.Add(numberToAdd);
                }
                else if (operations[0] == "Insert")
                {
                    int index = int.Parse(operations[2]);
                    int item = int.Parse(operations[1]);
                    if (index >= listOfIntegers.Count  || index <0)
                    {
                        Console.WriteLine($"Invalid index");
                    }
                    else
                    {
                        listOfIntegers.Insert(index, item);
                    }
                }
                else if (operations[0] == "Remove")
                {
                    int indexToRemove = int.Parse(operations[1]);

                    if (indexToRemove >= listOfIntegers.Count || indexToRemove < 0)
                    {
                        Console.WriteLine($"Invalid index");
                    }
                    else
                    {
                        listOfIntegers.RemoveAt(indexToRemove);
                    }
                }
                else if (operations[0] == "Shift" && operations[1] == "left")
                {
                    int counterShiftLeft = int.Parse(operations[2]);
                    for (int i = 0; i < counterShiftLeft; i++)
                    {
                        int numberMoveToLeft = listOfIntegers[0];
                        listOfIntegers.RemoveAt(0);
                        listOfIntegers.Add(numberMoveToLeft);
                    }
                }
                else if (operations[0] == "Shift" && operations[1] == "right")
                {
                    int counterShiftRight = int.Parse(operations[2]);
                    for (int i = 0; i < counterShiftRight; i++)
                    {
                        int numberMoverToRight = listOfIntegers[listOfIntegers.Count - 1];
                        listOfIntegers.RemoveAt(listOfIntegers.Count - 1);
                        listOfIntegers.Insert(0,numberMoverToRight);
                    }
                }

            }
            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}