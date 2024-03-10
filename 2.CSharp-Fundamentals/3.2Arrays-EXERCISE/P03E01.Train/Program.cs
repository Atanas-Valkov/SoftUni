
int wagonsCount = int.Parse(Console.ReadLine());

int[] wagons = new int[wagonsCount] ;

int sum = 0;
for (int i = 0; i < wagons.Length; i++)
{
    int passengers = int.Parse(Console.ReadLine());
    wagons[i] = passengers;
}

Console.WriteLine(string.Join(" ",wagons));
Console.WriteLine(wagons.Sum());
