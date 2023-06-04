


double[] num = Console.ReadLine()
    .Split(" ")
    .Select(double.Parse)
    .ToArray();
int[] roundedNums = new int[num.Length];

for (int i = 0; i < num.Length; i++)
{
    roundedNums[i] = (int)Math.Round(num[i], MidpointRounding.AwayFromZero);
    Console.WriteLine($"{num[i]} => {(int)Math.Round(num[i], MidpointRounding.AwayFromZero)}");
}




