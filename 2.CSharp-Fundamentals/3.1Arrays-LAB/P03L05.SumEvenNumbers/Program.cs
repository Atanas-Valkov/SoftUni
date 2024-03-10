
using System.Runtime.Serialization.Formatters;

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int sum = 0;
for (int i = 0; i < input.Length; i++)
{
    if (input[i] % 2 == 0)
    {
        sum += input[i];
    }

}

Console.WriteLine(sum);
