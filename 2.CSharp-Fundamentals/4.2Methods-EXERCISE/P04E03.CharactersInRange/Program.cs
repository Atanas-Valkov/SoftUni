using System.Reflection;

namespace P04E03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharactersBetweenThemAccordingToASCII(firstChar, secondChar);

        }

        static void CharactersBetweenThemAccordingToASCII(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    int currentChar = i;

                    Console.Write((char)currentChar + " ");
                }
            }
            else
            {
                for (int i = secondChar + 1 ; i < firstChar; i++)
                {
                    int currentChar = i;
                    Console.Write((char)currentChar + " ");
                }
            }
        }
    }
}