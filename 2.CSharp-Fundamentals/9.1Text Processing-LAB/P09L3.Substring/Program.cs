namespace P09L3.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToRemove = Console.ReadLine();
            string mainString = Console.ReadLine();
            int asd = mainString.IndexOf(stringToRemove);
            while (asd != -1)
            {
                mainString = mainString.Remove(asd, stringToRemove.Length);
                asd = mainString.IndexOf(stringToRemove);

            }

            Console.WriteLine(mainString);




        }
    }
}