namespace P09L1.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandLine = string.Empty;
            while ((commandLine = Console.ReadLine()) != "end")
            {
                string reversed = new string(commandLine.Where(x => x != ' ').Reverse().ToArray());
                
                Console.WriteLine($"{commandLine} = {reversed}");
            }
        }
    }
}