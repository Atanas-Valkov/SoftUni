using System.Diagnostics.Metrics;
using System.Net;

namespace P06ME_07_04_2020_01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double energy = double.Parse(Console.ReadLine());

            int counter = 0;
            string battle;
            while ((battle = Console.ReadLine()) != "End of battle")
            {
                counter ++;
                
                double distance = int.Parse(battle);
                energy -= distance;
                
                if (energy < distance)
                {
                   
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {energy} energy");
                    energy-= distance;
                  break;
                }

                if (counter % 3 == 0)
                {
                    energy += counter;
                }

            }
          
            if (battle == "End of battle")
            {
               Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
            }
        }
    }
}                                                                               