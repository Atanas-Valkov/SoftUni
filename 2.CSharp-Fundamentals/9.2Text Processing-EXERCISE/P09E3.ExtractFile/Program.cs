namespace P09E3.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");

            string[] lastFileName = input[input.Length - 1].Split(".");

            string fileName = lastFileName[0];
            string extension = lastFileName[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}