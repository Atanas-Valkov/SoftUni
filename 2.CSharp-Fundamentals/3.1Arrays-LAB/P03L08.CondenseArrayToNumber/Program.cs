

int[] arrayOfInt = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int[] condensedArray = new int[arrayOfInt.Length - 1];

if (arrayOfInt.Length == 1 )
{
    Console.WriteLine(arrayOfInt[0]);
    return;
}

for (int i = 0; i < arrayOfInt.Length; i++)
{
    for (int j = 0; j < condensedArray.Length - i; j++)
    {
        condensedArray[j] = arrayOfInt[j] + arrayOfInt[j + 1];
    }
    arrayOfInt = condensedArray;
}

Console.WriteLine(condensedArray[0]);


