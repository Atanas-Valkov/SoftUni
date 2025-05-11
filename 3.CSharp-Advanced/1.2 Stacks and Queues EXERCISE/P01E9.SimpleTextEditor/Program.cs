using System.Text;

namespace P01E9.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<char> textEditor = new Stack<char>();
            Stack<Stack<char>> historyOperations = new Stack<Stack<char>>();

            historyOperations.Push(new Stack<char>());
            for (int i = 0; i < n; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(' ');
                
                int operation = int.Parse(commandInfo[0]);

                if (operation == 1)
                {
                    string textToAppend = commandInfo[1];
                    historyOperations.Push(new Stack<char>(textEditor.Reverse()));

                    for (int j = 0; j < textToAppend.Length; j++)
                    {
                        textEditor.Push(textToAppend[j]);
                    }
                }
                else if (operation == 2)
                {
                    int countToRemove = int.Parse(commandInfo[1]);
                    historyOperations.Push(new Stack<char>(textEditor.Reverse()));
                    for (int j = 0; j < countToRemove && textEditor.Any(); j++)
                    {
                        textEditor.Pop();
                    }
                }
                else if (operation == 3)
                {
                    int index = int.Parse(commandInfo[1]);
                    index--;
                    string reversStackToString = new string(textEditor.Reverse().ToArray());

                    if (index >= 0 && index < reversStackToString.Length)
                    {
                        Console.WriteLine(reversStackToString[index]);
                    }
                }
                else if (operation == 4)
                {
                    if (historyOperations.Count > 0)
                    {
                        textEditor = new Stack<char>(historyOperations.Pop().Reverse());
                    }
                }
            }
        }
    }
}
