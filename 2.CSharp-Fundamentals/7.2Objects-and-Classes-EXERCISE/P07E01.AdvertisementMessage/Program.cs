using System;
using System.Collections.Generic;

namespace P07E01.messagevertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            MessageAdvertisement message = new MessageAdvertisement();

            for (int i = 0; i < numberOfMessages; i++)
            {
                Console.WriteLine(message.Generate());
            }
        }
    }

    public class MessageAdvertisement
    {
        public string[] phrases =
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };

        public string[] events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        public string[] authors =
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

        public string[] cities =
        {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };

        private Random random = new Random();
        public string Generate()
        {
            string phrase = phrases[random.Next(phrases.Length)];
            string evnt = events[random.Next(events.Length)];
            string author = authors[random.Next(authors.Length)];
            string city = cities[random.Next(cities.Length)];

            return $"{phrase} {evnt} {author} – {city}.";
        }
    }
}