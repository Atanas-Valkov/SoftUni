namespace P03ME3.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 1 || n > 50)
            {
                Console.WriteLine("N should be between 1 and 50.");
                return;
            }

            int a = 1;
            int b = 1; 
            int result = 1;

            for (int i = 3; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            Console.WriteLine(result);
        }
    }
}