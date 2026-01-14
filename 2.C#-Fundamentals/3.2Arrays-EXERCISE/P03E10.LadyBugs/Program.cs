
int fildSize = int.Parse(Console.ReadLine());

int[] ladyBugPositionInput = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] ladyBugPosition = new int[fildSize];
for (int i = 0; i < ladyBugPositionInput.Length; i++)
{
    int bugIndex = ladyBugPositionInput[i];
    if (bugIndex >= 0 && bugIndex < ladyBugPosition.Length)
    {
        ladyBugPosition[bugIndex] = 1;
    }
}
string commands;
while ((commands = Console.ReadLine()) != "end")
{
    string[] commandArr = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    int ladyBugIndex = int.Parse(commandArr[0]);
    string direction = commandArr[1];
    int flyLength = int.Parse(commandArr[2]);
    if (ladyBugIndex < 0 || ladyBugIndex > ladyBugPosition.Length - 1 || ladyBugPosition[ladyBugIndex] == 0)
    {
        continue;   
    }
    ladyBugPosition[ladyBugIndex] = 0;

    if (direction == "right")
    {
        int landIndex = ladyBugIndex + flyLength;

        if (landIndex > ladyBugPosition.Length - 1)
        {
            continue;
        }

        if (ladyBugPosition[landIndex] == 1)
        {
            while (ladyBugPosition[landIndex] == 1)
            {
                landIndex += flyLength;
                if (landIndex > ladyBugPosition.Length - 1)
                {
                    break;
                }
            }
        }

        if (landIndex <= ladyBugPosition.Length - 1)
        {
            ladyBugPosition[landIndex] = 1;
        }
    }
    else if (direction == "left")
    {
        int landIndex = ladyBugIndex - flyLength;

        if (landIndex < 0)
        {
            continue;
        }

        if (ladyBugPosition[landIndex] == 1)
        {
            while (ladyBugPosition[landIndex] == 1)
            {
                landIndex -= flyLength;
                if (landIndex < 0)
                {
                    break;
                }
            }
        }

        if (landIndex >= 0)
        {
            ladyBugPosition[landIndex] = 1;
        }
    }
}


Console.WriteLine(string.Join(" ", ladyBugPosition));
