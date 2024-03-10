using System.ComponentModel.Design;

namespace P08L3.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int countOfTheWords = int.Parse(Console.ReadLine());
            
             var words = new Dictionary <string, List<string>>();
            
             for (int i = 0; i < countOfTheWords; i++)
             {
                 string key = Console.ReadLine();
                 string value = Console.ReadLine();
            
                 if (!words.ContainsKey(key))
                 {
                    words.Add(key, new List<string>());
                 }
               
                 words[key].Add(value);

             }
             foreach (var asd in words)
             {
                 Console.Write($"{asd.Key} - ");
                 Console.WriteLine(string.Join(", ",asd.Value));
             }
        }
    }
}