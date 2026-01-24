namespace P04L09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(firstNumber, secondNumber));
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstChar, secondChar));
            }
            else if (type == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();

                Console.WriteLine(GetMax(firstString, secondString));
            }
        }


        private static int GetMax(int firstNumber, int secondNumber)
        {
            return Math.Max(firstNumber, secondNumber);
        }
        private static char GetMax(char firstChar, char secondChar)
        {
            
            return (char)Math.Max(firstChar, secondChar);
        }
        private static string GetMax(string firstString, string secondString)
        {
            int sumFirstString = 0;
            int sumSecondString = 0;

          foreach (var c in firstString)
          {
              sumFirstString += c;
          }

          foreach (var c in secondString)
          {
              sumSecondString += c;
          }
            return sumFirstString > sumSecondString ? firstString : secondString;
        }
    }
}







