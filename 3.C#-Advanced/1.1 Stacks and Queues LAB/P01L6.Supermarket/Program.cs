using System.Reflection.Metadata.Ecma335;

namespace P01L6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string commandLine = " ";
            while ((commandLine = Console.ReadLine()) != "End")
            {
                if (commandLine != "Paid")
                {
                    customers.Enqueue(commandLine);
                }
                else
                {
                    while (customers.Count>0)
                    {
                        Console.WriteLine($"{customers.Dequeue()}");
                    }
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
