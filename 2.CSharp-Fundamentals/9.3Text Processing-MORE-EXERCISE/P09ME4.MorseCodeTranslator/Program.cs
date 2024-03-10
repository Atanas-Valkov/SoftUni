using System.Text;

namespace P09ME4.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morseCode =
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.",
                "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
            };

            char[] upperChar =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            };


            string[] hiddenMessage = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder resultMessage = new StringBuilder();
            for (int i = 0; i < hiddenMessage.Length; i++)
            {
                if (morseCode.Contains(hiddenMessage[i]))
                {
                    var index = Array.IndexOf(morseCode, hiddenMessage[i]);
                    resultMessage.Append(upperChar[index]);
                }
                else
                {
                    resultMessage.Append(' ');
                }
            }
            Console.WriteLine(resultMessage);

        }
    }
}