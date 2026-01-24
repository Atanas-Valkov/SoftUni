namespace P01L5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n % 2 == 0));

            Console.Write(string.Join(", ", numbers));
        }
    }
}
