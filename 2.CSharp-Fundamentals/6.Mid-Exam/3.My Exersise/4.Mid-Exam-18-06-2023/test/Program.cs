namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool anyGreaterThanTen = numbers.Any(x => x > 10);
            bool anyEvenNumber = numbers.Any(x => x % 2 == 0);

            Console.WriteLine("Any number greater than 10? " + anyGreaterThanTen);
            Console.WriteLine("Any even number? " + anyEvenNumber);
           
        }
    }
}