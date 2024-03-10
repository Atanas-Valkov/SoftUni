namespace P04E02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrintsOutTheNumberOfVowels());
            
        }
        static int PrintsOutTheNumberOfVowels()
        {
            string input = Console.ReadLine().ToLower();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' || currentChar == 'o' || currentChar == 'u')
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}