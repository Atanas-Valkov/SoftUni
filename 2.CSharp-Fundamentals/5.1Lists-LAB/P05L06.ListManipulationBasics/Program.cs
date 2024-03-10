using System.Reflection.Metadata.Ecma335;

namespace P05L06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            string input = "";
            
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split(" ");
                
                if (arguments[0] == "Add")
                {
                    int numberToAdd = int.Parse(arguments[1]) ;
                    numbers.Add(numberToAdd);
                }
                else if(arguments[0] == "Remove")
                {
                    int numberToRemove = int.Parse(arguments[1]) ;
                    numbers.Remove(numberToRemove);
                }
                else if (arguments[0] == "RemoveAt")
                {
                    int numberToRemoveIndex = int.Parse(arguments[1]) ;
                    numbers.RemoveAt(numberToRemoveIndex) ;
                }
                else if (arguments[0] == "Insert")
                {
                    int numberToInsert = int.Parse(arguments[1]) ;
                    int index = int.Parse(arguments[2]) ;

                    numbers.Insert(index, numberToInsert);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}