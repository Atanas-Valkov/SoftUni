/*
2
STCDoghudd4=63333$D$0A53333
EHfsytsnhf?8555&I&2C9555SR 

3
tt(''DGsvywgerx>6444444444%H%1B9444
GQhrr|A977777(H(TTTT
EHfsytsnhf?8555&I&2C9555SR
 */

using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace P10E4.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> attackList = new List<string>();
            List<string> destructioList = new List<string>();


            for (int i = 0; i < numberOfMessages; i++)
            {

                string input = Console.ReadLine();
                string decryptPattern = @"[SsTtAaRr]";

                MatchCollection decryptCollection = Regex.Matches(input, decryptPattern);

                string decrypt = string.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    decrypt += (char)(input[j] - decryptCollection.Count);
                }

                string messagesPattern =
                    @"(?<planetName>[A-Z][a-z]+)[^@\-!:>]*:(?<population>\d{1,})[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>\d{1,})";

                Match messages = Regex.Match(decrypt, messagesPattern);
               
                string planet = messages.Groups["planetName"].Value;
                
                string attack = messages.Groups["attackType"].Value;
               

                if (messages.Success)
                {
                    if (attack == "A" && !attackList.Contains(planet))
                    {
                        attackList.Add(planet);
                    }
                    else if (attack == "D" && !destructioList.Contains(planet))
                    {
                        destructioList.Add(planet);
                    }
                }
            }
            attackList = attackList.OrderBy(x => x).ToList();
            destructioList = destructioList.OrderBy(x=>x).ToList();


            Console.WriteLine($"Attacked planets: {attackList.Count}");

            foreach (var attack in attackList)
            {
                Console.WriteLine($"-> {attack}");
            }

            Console.WriteLine($"Destroyed planets: {destructioList.Count}");
            foreach (var destructio in destructioList)
            {
                Console.WriteLine($"-> {destructio}");
            }
        }
    }
}