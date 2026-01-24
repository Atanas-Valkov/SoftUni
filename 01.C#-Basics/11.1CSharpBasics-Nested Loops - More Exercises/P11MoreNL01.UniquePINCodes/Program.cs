using System;

namespace P11MoreNL01.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int upperFirstNum = int.Parse(Console.ReadLine());
            int upperSecondNum = int.Parse(Console.ReadLine());
            int upperThirdNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= upperFirstNum; i++)
            {
                for (int j = 1; j <= upperSecondNum; j++)
                {
                    for (int k = 1; k <= upperThirdNum; k++)
                    {
                        if (i%2 == 0 && k%2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7 )
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
