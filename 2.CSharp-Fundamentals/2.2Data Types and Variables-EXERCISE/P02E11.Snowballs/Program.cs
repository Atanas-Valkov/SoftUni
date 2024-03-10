using System;
using System.Numerics;

namespace P02E11.Snowballs
{

    /*
2
10
2
3
5
5
5

    */



    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte snowballs = sbyte.Parse(Console.ReadLine());
            BigInteger maxSnowballValue = 0;
            ushort maxSnowballSnow = 0;
            ushort maxSnowballTime = 0;
            ushort maxSnowballQuality = 0;

            for (int i = 1; i <= snowballs; i++)
            {
                ushort snowballSnow = ushort.Parse(Console.ReadLine());
                ushort snowballTime = ushort.Parse(Console.ReadLine());
                ushort snowballQuality = ushort.Parse(Console.ReadLine());

                BigInteger currentSnowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
             
                if (currentSnowballValue > maxSnowballValue)
                {
                    maxSnowballValue = currentSnowballValue;
                     maxSnowballSnow = snowballSnow ;
                     maxSnowballTime = snowballTime ;
                    maxSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");
        }
    }
}
