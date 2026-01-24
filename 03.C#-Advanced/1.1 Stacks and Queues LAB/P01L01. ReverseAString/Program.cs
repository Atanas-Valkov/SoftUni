namespace P01L01._ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> input = new Stack<char>(
                Console.ReadLine());     

            int lenght = input.Count;
            for (int i = 0; i < lenght; i++)
            {
                Console.Write($"{input.Pop()}");
            }
        }
    }
}
