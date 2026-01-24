using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Xml;

namespace P3E06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] lineInfo = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = lineInfo[0];
                string[] clothes = lineInfo[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentClothe = clothes[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobe[color].ContainsKey(currentClothe))
                    {
                        wardrobe[color].Add(currentClothe, 0);
                    }

                    wardrobe[color][currentClothe]++;
                }
            }

            string[] isExists = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string lookingForColor = isExists[0];
            string lookingForClothe = isExists[1];

            foreach (var colors in wardrobe)
            {
                Console.WriteLine($"{colors.Key} clothes:");

                foreach (var ClotheKVP in colors.Value)
                {
                    if (ClotheKVP.Key == lookingForClothe && colors.Key == lookingForColor)
                    {
                        Console.WriteLine($"* {ClotheKVP.Key} - {ClotheKVP.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {ClotheKVP.Key} - {ClotheKVP.Value}");
                }
            }
        }
    }
}