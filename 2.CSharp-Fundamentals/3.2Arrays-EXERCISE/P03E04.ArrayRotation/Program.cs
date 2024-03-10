

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rotations = int.Parse(Console.ReadLine());

for (int i = 0; i < rotations; i++)
{
    int firstIndex = input[0];
    for (int j = 0; j < input.Length - 1; j++)
    {
        input[j] = input[j + 1];
    }
    input[input.Length - 1] = firstIndex;
}
Console.WriteLine(string.Join(" ",input));
