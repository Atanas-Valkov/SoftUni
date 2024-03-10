
using System.Xml.Linq;

int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int counter = 1;
int max = 0;
int index = 0;


for (int i = 0; i < numbers.Length - 1; i++)
{
    if (numbers[i] == numbers[i + 1])
    {
        counter++;
    }
    else
    {
        counter = 1;
    }

    if (max < counter)
    {
        max= counter;
        index = numbers[i];
    }
}
 int[] sameIndexes = new int[max];

foreach (int i in sameIndexes)
{
    sameIndexes[i] = index;
    Console.Write($"{index} ");
}