using System.Collections.Generic;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] fileByte = File.ReadAllBytes(sourceFilePath);
            List<byte> firstPart = new List<byte>();
            List<byte> secondPart = new List<byte>();

            for (int i = 0; i < fileByte.Length; i++)
            {
                int firstPartLength = fileByte.Length % 2 == 0
                    ? fileByte.Length / 2
                    : fileByte.Length / 2 + 1;

                if (i < firstPartLength)
                {
                    firstPart.Add(fileByte[i]);
                }
                else
                {
                    secondPart.Add(fileByte[i]);
                }
            }

            File.WriteAllBytes(partOneFilePath,firstPart.ToArray());
            File.WriteAllBytes(partTwoFilePath,secondPart.ToArray());
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] firstPart = File.ReadAllBytes(partOneFilePath);
            byte[] secondPart = File.ReadAllBytes(partTwoFilePath);

            List<byte> joinedBytes = new List<byte>();

            foreach (byte b in firstPart)
            {
                joinedBytes.Add(b);
            }

            foreach (var b in secondPart)
            {
                joinedBytes.Add(b);
            }

            File.WriteAllBytes(joinedFilePath,joinedBytes.ToArray());
        }
    }
}