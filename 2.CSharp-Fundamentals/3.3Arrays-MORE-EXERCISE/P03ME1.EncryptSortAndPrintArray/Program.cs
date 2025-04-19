namespace P03ME1.EncryptSortAndPrintArray;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        string message = Console.ReadLine();
        for (int i = 0; i < numbers.Count; i++)
        {
            int sum = GetDigitSum(numbers, i, out var currentNumber);

            if (sum < message.Length)
            {
                for (int j = 0; j < message.Length; j++)
                {
                    if (j == sum)
                    {
                        Console.Write(message[j ]);
                      string newMessage =  message.Remove(j, 1);
                        message = newMessage;
                        break;
                    }
                }
            }
            else if (sum >= message.Length)
            {
                int validIndex = sum % message.Length;
                Console.Write(message[validIndex]);
               string newMessage = message.Remove(validIndex, 1);
               message = newMessage;
            }
        }
        Console.WriteLine();
    }

    private static int GetDigitSum(List<int> numbers, int i, out int currentNumber)
    {
        int sum = 0;
        currentNumber = numbers[i];

        while (currentNumber > 0)
        {
            int lastDigit = currentNumber % 10;
            currentNumber /= 10;
            sum += lastDigit;
        }

        return sum;
    }
}