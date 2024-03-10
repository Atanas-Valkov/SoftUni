
using System.Net;
using System.Security.Cryptography;

/*
5 
1!0!1!1!0
0!1!1!0!0
Clone them!

4 
1!1!0!1
1!0!0!1 
1!1!0!0
Clone them!
 */

int lenght = int.Parse(Console.ReadLine());
string dna = "";
int bestSequenceIndex = 1;
int bestSequenceSum = 0;
int bestStartIndex = 0;
int bestCount = 0;
int index = 0;

string[] bestSequence = Array.Empty<string>();
while (true)
{
    dna = Console.ReadLine();
    if (dna == "Clone them!")
    {
        break;
    }
    
    index += 1;
    int sum = 0;
    int counter = 0;

    string[] arr = dna.Split("!", StringSplitOptions.RemoveEmptyEntries).ToArray();
    if (bestSequence.Length == 0)
    {
        bestSequence = arr;
    }

    for (int i = arr.Length - 1; i >=0 ; i--)
    {
        if (arr[i] == "1")
        {
            sum++;
            counter++;
            if (bestCount < counter || bestStartIndex > i || bestSequenceSum < sum)
            {
                bestSequence = arr;
                bestStartIndex = i;
                bestSequenceIndex = index;
                bestCount = counter;
                bestSequenceSum = sum;
            }
           
        }
        else
        {
            counter = 0;
        }
    }
}

Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
Console.WriteLine(String.Join(" ", bestSequence));
