using System;
using System.Data.Common;

namespace P01L11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int num = int.Parse(Console.ReadLine());
            int startNum = int.Parse(Console.ReadLine());   

            for (int i = startNum; i <=100 ; i++)
            {
                if (i <= 10)
                {
                    int sum = num * i;

                  Console.WriteLine($"{num} X {i} = {sum}");

                }
                else if (startNum>10)
                {
                    int sum = num * i;

                    Console.WriteLine($"{num} X {i} = {sum}");
                    break;
                }

                 
                

                
                
            }
        
        }
    }
}
