using System;
using System.Collections.Generic;

namespace P07E01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AdvertisementMessages> messages = new List<AdvertisementMessages>();

            PredefinedParts predefinedParts = new PredefinedParts();

            int numberOfMessages = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < numberOfMessages; i++)
            {
                AdvertisementMessages message = new AdvertisementMessages()
                {
                    Phrase = predefinedParts.Phrases[random.Next(0, predefinedParts.Phrases.Count)],
                    Event = predefinedParts.Events[random.Next(0, predefinedParts.Events.Count)],
                    Author = predefinedParts.Authors[random.Next(0, predefinedParts.Authors.Count)],
                    Citie = predefinedParts.Cities[random.Next(0, predefinedParts.Cities.Count)]
                };

                messages.Add(message);
            }

            foreach (AdvertisementMessages message in messages)
            {
                Console.WriteLine($"{message.Phrase} {message.Event} {message.Author} – {message.Citie}.");
            }
        }
    }

    public class AdvertisementMessages
    {
        public string Phrase { get; set; }
        public string Event { get; set; }
        public string Author { get; set; }
        public string Citie { get; set; }
    }

    public class PredefinedParts
    {
        public List<string> Phrases = new List<string>()
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };

        public List<string> Events = new List<string>()
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy with the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        public List<string> Authors = new List<string>()
        {
            "Diana",
            "Petya",
            "Stella",
            "Elena",
            "Katya",
            "Iva",
            "Annie",
            "Eva"
        };

        public List<string> Cities = new List<string>()
        {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };
    }
}