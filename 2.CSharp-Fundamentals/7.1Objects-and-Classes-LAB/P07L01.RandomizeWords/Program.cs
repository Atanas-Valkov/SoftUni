namespace P07L01.RandomizeWords
{

    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<string> words= Console.ReadLine()
                .Split(" ")
                .ToList();

            Random random = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                string valueAtIndex= words[i];
                int randomIndex = random.Next(0, words.Count);
                string randomValueIndex = words[randomIndex];

                words[i] = randomValueIndex;
                words[randomIndex] = valueAtIndex;

            }

            foreach (string value in words)
            {
                Console.WriteLine(value);
                
            }



        }
    }
}