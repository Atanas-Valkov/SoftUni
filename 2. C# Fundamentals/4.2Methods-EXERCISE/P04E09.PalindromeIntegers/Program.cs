
namespace P04E09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PalindromeIntegers();
        }

        private static void PalindromeIntegers()
        {
            string input = " ";
            while ((input = Console.ReadLine()) != "END")
            {
                bool isPalindrome = true;
                for (int i = 0; i < input.Length / 2; i++)
                {
                    if (input[i] != input[input.Length - 1 - i])
                    {
                        isPalindrome = false;
                        Console.WriteLine($"false");
                        break;
                    }
                }

                if (isPalindrome)
                {
                    Console.WriteLine($"true");
                }
            }
        }
    }
}