using System;
using System.ComponentModel;
using System.Net;

namespace P05E04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            string command = " ";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = arguments[0];
                if (operation == "Add")
                {
                    Add(arguments, input);
                }
                else if (operation == "Insert")
                {
                    Insert(arguments, input);
                }
                else if (operation == "Remove")
                {
                    Remove(arguments, input);
                }
                else if (operation == "Shift")
                {
                    Shift(arguments, input);
                }
            }

            Console.WriteLine(string.Join(" ",input));
        }

        private static void Add(string[] arguments, List<int> input)
        {
            int number = int.Parse(arguments[1]);
            input.Add(number);
        }
        private static void Insert(string[] arguments, List<int> input)
        {
            int number = int.Parse(arguments[1]);
            int index = int.Parse(arguments[2]);
            if (index >= 0 && index <= input.Count - 1)
            {
                input.Insert(index, number);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        private static void Remove(string[] arguments, List<int> input)
        {
            int index = int.Parse(arguments[1]);
            if (index >= 0 && index <= input.Count - 1)
            {
                input.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        private static void Shift(string[] arguments, List<int> input)
        {
            string direction = arguments[1];
            int count = int.Parse(arguments[2]);
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int first = input[0];
                    input.RemoveAt(0);
                    input.Add(first);
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    int last = input[input.Count - 1];
                    input.RemoveAt(input.Count - 1);
                    input.Insert(0, last);
                }
            }
        }
    }
}