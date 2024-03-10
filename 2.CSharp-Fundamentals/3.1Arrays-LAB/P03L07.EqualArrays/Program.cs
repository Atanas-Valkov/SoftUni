
using System;
using System.Reflection;

int[] firstArr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int[] secondArr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int sum = 0;
for (int i = 0; i < firstArr.Length; i++)
{
    if (firstArr[i] != secondArr[i])
    {
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        break;
    }
    else
    {
        sum += firstArr[i];
        
    }
}
Console.WriteLine($"Arrays are identical. Sum: {sum}");

