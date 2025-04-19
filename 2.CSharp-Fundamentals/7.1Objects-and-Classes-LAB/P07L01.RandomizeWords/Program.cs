namespace P07L01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<string> input = Console.ReadLine()
               .Split(' ')
               .ToList();

            Random rdm = new Random();

            for (int i = 0; i < input.Count; i++)
            {
                int j = rdm.Next(0, input.Count);
                string temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}