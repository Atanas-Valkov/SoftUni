
double[] numbers = Console.ReadLine()
    .Split()
    .Select(double.Parse)
    .ToArray();
 int[] roundedNumbers = new int[numbers.Length];

for (int i = 0; i < numbers.Length; i++)
{
    roundedNumbers[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
    Console.WriteLine($"{numbers[i]} => {(int)Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
}


