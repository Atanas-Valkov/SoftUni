using System;

namespace P09MyE06_18_19Juy20_.BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startNum = Console.ReadLine();
            string endNum = Console.ReadLine();
            
            int firstStartNum = int.Parse(startNum[0].ToString());
            int secondStartNum = int.Parse(startNum[1].ToString());
            int thirdStartNum = int.Parse(startNum[2].ToString());
            int fourthStartNum = int.Parse(startNum[3].ToString());

            int firstEndNum = int.Parse(endNum[0].ToString());
            int secondEndNum = int.Parse(endNum[1].ToString());
            int thirdEndNum = int.Parse(endNum[2].ToString());
            int fourthEndNum = int.Parse(endNum[3].ToString());



            for (int i = firstStartNum; i <= firstEndNum; i++)
            {
                for (int j = secondStartNum; j <= secondEndNum; j++)
                {
                    for (int k = thirdStartNum; k <= thirdEndNum; k++)
                    {
                        for (int l = fourthStartNum; l <= fourthEndNum; l++)
                        {
                            if (i % 2 !=0 && j % 2 !=0 && k % 2 !=0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }

                        }
                    }
                }

            }
           





        }
    }
}
