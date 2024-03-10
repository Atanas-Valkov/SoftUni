

int input = int.Parse(Console.ReadLine());

int[] zigZag1 = new int[input];
int[] zigZag2 = new int[input];

bool isFirstSelected = true;
for (int i = 0; i < input; i++)
{
    int[] arr = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    if (isFirstSelected)
    {
        zigZag1[i] = arr[0];
        zigZag2[i] = arr[1];
    }
    else
    {
        zigZag1[i] = arr[1];
        zigZag2[i] = arr[0];
    }
    isFirstSelected = !isFirstSelected;
}

Console.WriteLine(string.Join(" ", zigZag1));
Console.WriteLine(string.Join(" ",zigZag2));
