namespace P3E01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> userNames = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                userNames.Add(name);
            }

            foreach (var name in userNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}