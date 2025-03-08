namespace P03ME1.EncryptSortAndPrintArray;

internal class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        string[] names = new string[numberOfStrings];
        int[] ascendingOrder = new int[numberOfStrings];
        int sum = 0;

        for (int i = 0; i < numberOfStrings; i++)
        {
            names[i] = Console.ReadLine();

            sum = 0;
            foreach (var c in names[i])
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    sum += (int)c * names[i].Length;
                    ascendingOrder[i] = sum;
                }
                else
                {
                    sum += (int)c / names[i].Length;
                    ascendingOrder[i] = sum;
                }
            }
        }
        Array.Sort(ascendingOrder);
        foreach (var num  in ascendingOrder)
        {
            Console.WriteLine(num);
        }
    }
}