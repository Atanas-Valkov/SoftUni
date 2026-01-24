using System.Text.RegularExpressions;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countInputs = int.Parse(Console.ReadLine());
            
            string pattern = @"(\$|%)(?<name>[A-Za-z]{3,})(\1):\s\[(?<first>\d+)]\|\[(?<second>\d+)]\|(\[(?<third>\d+)])\|";
            List<string> validMsgs = new List<string>();




            for (int i = 0; i < countInputs; i++)
            {
               string input = Console.ReadLine(); 
                
               bool isTrue = true;
                foreach (Match match in Regex.Matches(input,pattern))
                {
                    string firstValue = match.Groups["name"].Value;
                    int secondValue = int.Parse(match.Groups["first"].Value);
                    int thirdValue =int.Parse(match.Groups["second"].Value);
                    int forValue = int.Parse(match.Groups["third"].Value);


                    Console.WriteLine($"{firstValue}: {(char)secondValue}{(char)thirdValue}{(char)forValue}");
                    
                    isTrue = false;
                }


                if (isTrue)
                {
                   Console.WriteLine($"Valid message not found!");
                    
                }


            }

        }

      
    }
}