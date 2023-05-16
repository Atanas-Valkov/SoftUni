using System;

namespace P03.Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int num = int.Parse(Console.ReadLine());
            int count = 0;
          
            
            for (int i = 0; i <= num; i++)
            {
                
                for (int i2 = 0; i2 <= num; i2++)
                {
                    
                    for (int i3 = 0; i3 <= num; i3++)
                    {
                        if (i+i2+i3 == num )
                        {
                            count++;
                            

                        }
                        
                        

                    }
                }
                
            }
            Console.WriteLine(count);


        }
    }
}
