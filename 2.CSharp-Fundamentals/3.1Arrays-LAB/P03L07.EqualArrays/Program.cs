

using System;
using System.Diagnostics.Metrics;

int [] firstArr = Console.ReadLine()
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
    if (firstArr[i] == secondArr[i])
    {
        sum += firstArr[i];
    }
    else
    {
        
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        return;
    }

}
Console.WriteLine($"Arrays are identical. Sum: {sum}");

