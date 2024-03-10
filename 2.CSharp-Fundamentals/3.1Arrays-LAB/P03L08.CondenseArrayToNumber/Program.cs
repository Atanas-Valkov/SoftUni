
int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int sum = 0;

int[] couplesSum = new int[arr.Length - 1];
if (arr.Length == 1)
{
    Console.WriteLine($"{arr[0]}");
    return;
}
for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < couplesSum.Length - i; j++)
    {
        couplesSum[j] = arr[j] + arr[j + 1];
    }
    arr = couplesSum;
}

Console.WriteLine(couplesSum[0]);