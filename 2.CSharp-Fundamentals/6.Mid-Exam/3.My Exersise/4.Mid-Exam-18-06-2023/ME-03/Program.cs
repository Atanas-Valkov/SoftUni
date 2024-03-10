/*
aaa&bbb&ccc
Add Book | vvv
Done

vvv&bbb&ccc
Take Book | vvv
Done

vvv&bbb&ccc
Swap Book | ccc | vvv
Done




 */




using System;
using System.ComponentModel.Design;

namespace ME_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine()
                .Split("&")
                .ToList();
            string operations = "";

            while ((operations = Console.ReadLine()) != "Done")
            
            {
                string[] commands = operations.Split(" | ");

                if (commands[0] == "Add Book")
                {
                   if (!shelf.Any(x => x.Contains(commands[1])))
                   {
                        shelf.Insert(0, commands[1]);
                   }
                }
                else if(commands[0] == "Take Book")
                {
                   if (shelf.Any(x => x.Contains(commands[1])))
                   {
                       shelf.Remove(commands[1]);
                   }
                }
                else if (commands[0] == "Swap Book")
                {
                    if (shelf.Any(x => x.Contains(commands[1])) && shelf.Any(x => x.Contains(commands[2])))
                    {
                        int index1 = shelf.FindIndex(x => x.Contains(commands[1]));
                        int index2 = shelf.FindIndex(x => x.Contains(commands[2]));

                        string temp = shelf[index1];
                        shelf[index1] = shelf[index2];
                        shelf[index2] = temp;
                    }
                }
                else if (commands[0] == "Insert Book")
                {
                   if (!shelf.Any(x => x.Contains(commands[1])))
                   {
                       shelf.Add(commands[1]);
                   }
                }
                else if (commands[0] == "Check Book")
                {
                   if (shelf.Any(x => x.Contains(commands[1])))
                   {
                       Console.WriteLine(commands[1]);
                   }
                }
            }
            Console.WriteLine(string.Join(", ",shelf));
        }
    }
}
