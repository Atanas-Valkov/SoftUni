using System.Net;
using System.Xml;

namespace P01ME01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firts = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());


            if (firts > second && firts > third)
            {
                Console.WriteLine(firts);
                if (second > third)
                {
                    Console.WriteLine(second);
                    Console.WriteLine(third);
                }
                else
                {
                    Console.WriteLine(third);
                    Console.WriteLine(second);
                }
            }
            else if (second > firts && second > third)
            {
                Console.WriteLine(second);
                if (firts > third)
                {
                    Console.WriteLine(firts);
                    Console.WriteLine(third);
                }
                else
                {
                    Console.WriteLine(third);
                    Console.WriteLine(firts);
                }
            }
            else if(third > firts && third > second)
            {
                Console.WriteLine(third);
                if (firts > second)
                {
                    Console.WriteLine(firts);
                    Console.WriteLine(second);
                }
                else
                {
                    Console.WriteLine(second);
                    Console.WriteLine(firts);
                }
            }
        }
    }
}