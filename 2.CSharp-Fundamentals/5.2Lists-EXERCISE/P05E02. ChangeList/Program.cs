/*
1 2 3 4 5 5 5 6
Delete 5
Insert 10 1
Delete 5
end

 */

namespace P05E02._ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = " ";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string operation = arguments[0];
                if (operation == "Delete")
                {
                    Delete(arguments, numbers);
                }
                else if(operation == "Insert")
                {
                    Insert(arguments, numbers);
                }
            }
            Print(numbers);
        }

        private static void Insert(string[] arguments, List<int> numbers)
        {
            int element = int.Parse(arguments[1]);
            int index = int.Parse(arguments[2]);
            numbers.Insert(index, element);
        }

        private static void Delete(string[] arguments, List<int> numbers)
        {
            int element = int.Parse(arguments[1]);
            numbers.RemoveAll(x => x == element);
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}