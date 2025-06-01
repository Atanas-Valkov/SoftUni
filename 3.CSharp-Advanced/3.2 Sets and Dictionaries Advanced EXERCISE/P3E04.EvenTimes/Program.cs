using System.Linq;

namespace P3E04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<double> evenTimes = new HashSet<double>();
            Dictionary<double, double> asd = new Dictionary<double, double>();
            double tempNum = 0;
            for (int i = 0; i < n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (!evenTimes.Contains(currentNumber))
                {
                    evenTimes.Add(currentNumber);
                }

                if (!asd.ContainsKey(currentNumber))
                {
                    asd.Add(currentNumber, 1);
                }
                else
                {
                    asd[currentNumber]++;
                }
            }

            foreach (var kvp in asd)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}