

int n = int.Parse(Console.ReadLine());

string[] firstArray = new string[n];
string[] secondArray = new string[n];
bool isFirstSelected = true;
for (int i = 0; i < n; i++)
{
    string number = Console.ReadLine();

    string[] numberAsArray = number.Split();

    if (isFirstSelected)
    {
        firstArray[i] = numberAsArray[0];
        secondArray[i] = numberAsArray[1];
    }
    else
    {
        firstArray[i] = numberAsArray[1];
        secondArray[i] = numberAsArray[0];
    }
    isFirstSelected = !isFirstSelected;
}
Console.WriteLine(string.Join(" ", firstArray));
Console.WriteLine(string.Join(" ", secondArray));


