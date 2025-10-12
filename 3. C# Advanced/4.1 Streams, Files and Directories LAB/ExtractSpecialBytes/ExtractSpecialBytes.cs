using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] allBytes = File.ReadAllBytes(binaryFilePath);

            byte[] bytesToCheck = File
                .ReadAllLines(bytesFilePath)
                .Select(byte.Parse)
                .ToArray();

            byte[] result = allBytes
                .Where(x => bytesToCheck.Contains(x))
                .ToArray();
            File.WriteAllBytes(outputPath,result.ToArray());
        }   
    }
}
