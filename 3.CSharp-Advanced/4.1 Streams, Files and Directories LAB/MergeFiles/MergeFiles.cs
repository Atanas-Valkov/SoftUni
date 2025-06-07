using System.Collections.Generic;

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] firstFileLines = File.ReadAllLines(firstInputFilePath);
            string[] secondFileLines = File.ReadAllLines(secondInputFilePath);
            int maxLength = firstFileLines.Length > firstFileLines.Length ? firstFileLines.Length : secondFileLines.Length;
            
            List<string> result = new List<string>();

            for (int i = 0; i < maxLength; i++)
            {
                if (i < firstFileLines.Length)
                {
                    result.Add(firstFileLines[i]);
                }

                if (i < secondFileLines.Length)
                {
                    result.Add(secondFileLines[i]);
                }
            }
            File.WriteAllLines(outputFilePath,result);
        }
    }
}
