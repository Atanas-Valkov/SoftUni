

string[] array = Console.ReadLine().Split();

int rotations = int.Parse(Console.ReadLine());

for (int i = 0; i < rotations; i++)
{
    string firstIndex = array[0];

    for (int j = 0; j < array.Length - 1; j++)
    {
        array[j] = array[j + 1];
    }

    array[array.Length - 1] = firstIndex;
}

Console.WriteLine(string.Join(" ",array));


