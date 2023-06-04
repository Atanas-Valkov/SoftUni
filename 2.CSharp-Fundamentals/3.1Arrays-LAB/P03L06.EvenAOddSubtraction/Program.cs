

int[] numbers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int oddSum = 0;
int evenSum = 0;

for (int i = 0; i < numbers.Length; i++)
{
     int currentNumber = numbers[i];

     if (currentNumber % 2 == 0 )
     {
         evenSum += numbers[i];
     }
     else
     {
         oddSum += numbers[i];

     }
 }
int difference = evenSum - oddSum;
Console.WriteLine(difference);
