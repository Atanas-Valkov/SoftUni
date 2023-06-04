namespace P04L07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chars = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            RepresentRepeats(chars , n);
        }

        static void RepresentRepeats(string chars, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(chars);
            }
        }
    }
}