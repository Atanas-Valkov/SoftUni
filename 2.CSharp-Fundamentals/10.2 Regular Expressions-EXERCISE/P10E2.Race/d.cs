using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace P10E2.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Participant> participants = new List<Participant>();

            string[] arrNames = Console.ReadLine().Split(", ");

            for (int i = 0; i < arrNames.Length; i++)
            {
                Participant participant = new Participant();
                participant.Name = arrNames[i];
                participant.Distance = 0;
                participants.Add(participant);
            }

            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";


            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder sbNames = new StringBuilder();

                foreach (Match name in Regex.Matches(input, lettersPattern))
                {
                    sbNames.Append(name.Value);
                }

                int distance = 0;
                foreach (Match distanceMatch in Regex.Matches(input, digitsPattern))
                {
                    distance += int.Parse(distanceMatch.Value);
                }

                Participant found = participants.FirstOrDefault(x => x.Name == sbNames.ToString());
                if (found != null)
                {
                    found.Distance += distance;
                }
            }

            List<Participant> Order = participants.OrderByDescending(x => x.Distance).Take(3).ToList();

            if (participants.Count >= 3)
            {
                Console.WriteLine($"1st place: {Order[0].Name}\n2nd place: {Order[1].Name}\n3rd place: {Order[2].Name}");

            }

        }

        class Participant
        {

            public string Name { get; set; }

            public int Distance { get; set; }
        }
    }
}