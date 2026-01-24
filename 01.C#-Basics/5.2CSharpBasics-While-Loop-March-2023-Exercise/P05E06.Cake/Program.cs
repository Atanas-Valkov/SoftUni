using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace P06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {

           int cakeWidth = int.Parse(Console.ReadLine());
           int cakeLength = int.Parse(Console.ReadLine());

            string pieces ;
            int totalPieces ;    
            int counterPieces = 0 ;

            totalPieces = cakeWidth * cakeLength;

            while (totalPieces >= counterPieces)
            {
                pieces = Console.ReadLine();

                if (pieces != "STOP")
                {
                    counterPieces += int.Parse(pieces);
                }
                else if (pieces == "STOP")
                {
                    Console.WriteLine($"{totalPieces - counterPieces} pieces are left.");
                    break;
                }
                if (totalPieces <= counterPieces)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces - counterPieces)} pieces more.");
                }
                
            }
        }
    }
}
