namespace P04L09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int firstInt = int.Parse(Console.ReadLine());
                int secondInt = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstInt, secondInt));
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstChar, secondChar));
            }
            else if (type == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();
                Console.WriteLine(GetMax(firstValue, secondValue));
            }
        }

        static int GetMax(int firstInt, int secondInt)
        {
            int maxValue = Math.Max(firstInt, secondInt);
            return maxValue;
        }

        static char GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }

            return secondChar;
        }

        static string GetMax(string firstString, string secondString)
        {
             int larger = firstString.CompareTo(secondString);

             if (larger>0)
             {
                 return firstString;
             }

             return secondString;
        }
    }
}







