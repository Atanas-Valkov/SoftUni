﻿
string[] firstArr = Console.ReadLine()
    .Split()
    .ToArray();

string[] secondArr = Console.ReadLine()
    .Split()
    .ToArray();

for (int i = 0; i < firstArr.Length; i++)
{
    for (int j = 0; j < secondArr.Length; j++)
    {
        if (firstArr[i] == secondArr[j])
        {
            Console.Write(firstArr[i] + " ");
        }
    }
}