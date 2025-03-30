namespace P04ME4.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            GetTribonacciSequence(elements);
        }

        private static void GetTribonacciSequence(int elements)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 1;
            Console.Write(1);
            for (int i = 1; i < elements; i++)
            {
                a = b;
                b = c;
                c = d;
                d = a + b + c;
                Console.Write(" " + d);
            }
        }
    }
}