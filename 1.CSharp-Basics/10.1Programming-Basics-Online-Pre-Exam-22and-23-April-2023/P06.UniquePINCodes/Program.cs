using System;

namespace P06.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber1 = int.Parse(Console.ReadLine());
            int endNumber2 = int.Parse(Console.ReadLine());
            int endNumber3 = int.Parse(Console.ReadLine());
            int pin = 0;
            for (int i = 1; i <=endNumber1; i++)
            {
                
                for (int j = 1; j <=endNumber2; j++)
                {
                    

                    for (int k = 1; k <=endNumber3; k++)
                    {

                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            if (j==2 || j == 3 || j == 5 || j==7)
                            {
                                
                                Console.WriteLine($"{i} {j} {k}");

                            }
                        }

                    }

                }
            }
           
        }
    }
}
