using System.Collections.Generic;
using System.Xml.Linq;
/*
1 10 100 1000
exchange 3
first 2 odd
last 4 odd
end
 */
namespace P04E11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = " ";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                string action = arguments[0];
                if (action == "exchange")
                {
                    input = Exchange(input, arguments);
                }
                else if (action == "max")
                {
                    MaxOddEven(input, arguments);
                }
                else if (action == "min")
                {
                    MinOddEven(input, arguments);
                }
                else if (action == "first")
                {
                    ReturnsTheFirstEvenOddElements(input, arguments);

                }
                else if (action == "last")
                {
                    ReturnsLastEvenOddElements(input, arguments);
                }
            }
            Console.WriteLine($"[{string.Join(", ", input)}]");
        }


        private static void Print(int[] nums)
        {
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static int[] Exchange(int[] input, string[] arguments)
        {
            int index = int.Parse(arguments[1]);
            if (index < 0 || index > input.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return input;
            }
            int[] subArray1 = new int[index + 1];
            int[] subArray2 = new int[input.Length - index - 1];
            int startingIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i >= 0 && i <= index)
                {
                    subArray1[i] = input[i];
                }
                else
                {
                    subArray2[startingIndex] = input[i];
                    startingIndex++;
                }
            }
            int[] exchange = subArray2.Concat(subArray1).ToArray();
            return exchange;
        }
        private static void MaxOddEven(int[] input, string[] arguments)
        {
            int maxOddNumber = 0;
            int maxOddIndex = -1;
            int maxEvenNumber = 0;
            int maxEvenIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0)
                {
                    if (input[i] >= maxOddNumber)
                    {
                        maxOddNumber = input[i];
                        maxOddIndex = i;
                    }
                }
                else
                {
                    if (input[i] >= maxEvenNumber)
                    {
                        maxEvenNumber = input[i];
                        maxEvenIndex = i;
                    }
                }
            }

            if (arguments[1] == "odd")
            {
                if (maxOddIndex < 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxOddIndex);
                }
            }

            if (arguments[1] == "even")
            {
                if (maxEvenIndex < 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxEvenIndex);
                }
            }
        }
        private static void MinOddEven(int[] input, string[] arguments)
        {
            int minOddNumber = int.MaxValue;
            int minOddIndex = -1;
            int minEvenNumber = int.MaxValue;
            int minEvenIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0)
                {
                    if (input[i] <= minOddNumber)
                    {
                        minOddNumber = input[i];
                        minOddIndex = i;
                    }
                }
                else
                {
                    if (input[i] <= minEvenNumber)
                    {
                        minEvenNumber = input[i];
                        minEvenIndex = i;
                    }
                }
            }

            if (arguments[1] == "even")
            {
                if (minEvenIndex < 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minEvenIndex);
                }
            }

            if (arguments[1] == "odd")
            {
                if (minOddIndex < 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minOddIndex);
                }
            }
        }
        private static void ReturnsTheFirstEvenOddElements(int[] input, string[] arguments)
        {
            int countElements = int.Parse(arguments[1]);
            int evenCount = 0;
            int oddCount = 0;
            int[] evenNumbers = new int[input.Length];
            int[] oddNumbers = new int[input.Length];

            if (countElements < 1 || countElements > input.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0 && evenCount < countElements)
                {
                    evenNumbers[evenCount] = input[i];
                    evenCount++;
                }
                else if (input[i] % 2 == 1 && oddCount < countElements)
                {
                    oddNumbers[oddCount] = input[i];
                    oddCount++;
                }
            }
            oddNumbers = oddNumbers.Where(T => T != 0).ToArray();
            int[] evensFinal = new int[evenCount];
            for (int i = 0; i < evensFinal.Length; i++)
            {
                evensFinal[i] = evenNumbers[i];
            }

            if (arguments[2] == "odd")
                Print(oddNumbers);
            else
            {
                Print(evensFinal);
            }
        }
        private static void ReturnsLastEvenOddElements(int[] input, string[] arguments)
        {
            int countElements = int.Parse(arguments[1]);
            int evenCount = 0;
            int oddCount = 0;
            int[] evens = new int[input.Length];
            int[] odds = new int[input.Length];
            if (countElements > input.Length || countElements < 1)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] % 2 == 0 && evenCount < countElements)
                {
                    evens[evenCount] = input[i];
                    evenCount++;
                }
                else if (input[i] % 2 == 1 && oddCount < countElements)
                {
                    odds[oddCount] = input[i];
                    oddCount++;
                }
            }

            odds = odds.Where(T => T != 0).ToArray();

            int[] evensFinal = new int[evenCount];
            for (int i = 0; i < evensFinal.Length; i++)
            {
                evensFinal[i] = evens[i];
            }

            Array.Reverse(evensFinal);
            Array.Reverse(odds);

            if (arguments[2] == "odd")
            {
                Print(odds);
            }
            else
            {
                Print(evensFinal);
            }
        }
    }
}