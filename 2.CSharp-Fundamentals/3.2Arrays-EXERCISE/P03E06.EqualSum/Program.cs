
int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int leftSum = 0; 
int rightSum = 0;

bool isEqual = false;

for (int i = 0; i < input.Length; i++)
{
    leftSum = 0;
    for (int leftToRight = 0; leftToRight < i; leftToRight++)
    {
        leftSum += input[leftToRight];
    }

    rightSum = 0;
    for (int rightToLeft = input.Length - 1; rightToLeft > i; rightToLeft--)
    {
        rightSum += input[rightToLeft];
    }

    if (leftSum == rightSum && !isEqual)
    {
        Console.WriteLine(i);
        isEqual = true;
    }
}

if (!isEqual)
{
    Console.WriteLine("no");
}




