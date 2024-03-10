using System;

namespace P06ME05_07_2020_02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> listOfInt = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] elements = command.Split();

                if (elements[0] == "swap")
                {
                    int index1 = int.Parse(elements[1]);
                    int index2 = int.Parse(elements[2]);

                   
                    // ReSharper disable once SwapViaDeconstruction
                    int tempIndex = listOfInt[index1];
                    listOfInt[index1] = listOfInt[index2];
                    listOfInt[index2] = tempIndex;
                }
                else if (elements[0] == "multiply")
                {
                    int index1 = int.Parse(elements[1]);
                    int index2 = int.Parse(elements[2]);
                    listOfInt[index1] *= listOfInt[index2];
                }
                else if (elements[0] == "decrease")
                {
                    listOfInt = listOfInt.Select(x => x - 1).ToList();
                }

            }

            Console.WriteLine(string.Join(", ", listOfInt));

        }
    }
}