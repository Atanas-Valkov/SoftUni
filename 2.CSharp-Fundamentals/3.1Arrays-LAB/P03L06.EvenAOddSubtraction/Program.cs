
using System.Runtime.ExceptionServices;

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int sumEven = 0;
int sumodd = 0;
for (int i = 0; i < input.Length; i++)
{

    if (input[i] % 2 == 0)
    {
        sumEven += input[i];
    }
    else
    {
        sumodd += input[i];
    }
}
int difference =  sumEven - sumodd;

Console.WriteLine(difference);