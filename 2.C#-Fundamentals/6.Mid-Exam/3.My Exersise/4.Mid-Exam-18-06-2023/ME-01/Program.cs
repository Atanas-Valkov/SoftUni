using System.Net;
/*
500
5
50
100
200
100
30

500
5
50
100
200
100
20

400
5
50
100
200
100
20


 */
namespace ME_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double amountOfExperience = double.Parse(Console.ReadLine());
            double countOfBattles = double.Parse(Console.ReadLine());
            double collectedExperience = 0;
            int battleCount = 0;
            for (int i = 1; i <=countOfBattles; i++)
            {
                bool miss = true;
                battleCount = i ;
                double experiencePLayer = double.Parse(Console.ReadLine());

              
                if (collectedExperience >= amountOfExperience)
                {
                    break;
                }

                if (i!= 1  && i % 3 == 0)
                {
                    experiencePLayer *= 1.15;
                    experiencePLayer = Math.Ceiling(experiencePLayer);
                    collectedExperience += experiencePLayer;
                    if (collectedExperience >= amountOfExperience)
                    {
                        break;
                    }
                    miss = false;
                }
                if (i != 1 && i % 5 == 0)
                { 
                    experiencePLayer *= 0.90;
                    collectedExperience += experiencePLayer;
                    if (collectedExperience >= amountOfExperience)
                    {
                        break;
                    }
                    miss = false;
                }
                if (i != 1 && i % 15 == 0)
                {
                    experiencePLayer *= 1.05;
                    collectedExperience += experiencePLayer;
                    if (collectedExperience >= amountOfExperience)
                    {
                        break;
                    }
                    miss = false;
                }

                if (miss == true) 
                {
                    collectedExperience += experiencePLayer; }
                if (collectedExperience >= amountOfExperience) 
                {
                      break;
                }
            }

            if (collectedExperience >= amountOfExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(amountOfExperience - collectedExperience):f2} more needed.");
            }

        }
    }
}
