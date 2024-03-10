using System.Net;

namespace P05E07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

           List<string> input = Console.ReadLine()
               .Split("|")
               .Reverse()
               .ToList();
         
           List<int> newList = new List<int>();
           foreach (var number in input)
           {
               newList.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
           }

           Console.WriteLine(string.Join(" ", newList));

        }  
    }
}