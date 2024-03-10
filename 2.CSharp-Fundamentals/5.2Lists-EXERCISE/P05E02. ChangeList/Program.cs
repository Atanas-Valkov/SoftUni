namespace P05E02._ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> listOfIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            string commands;
            while ((commands = Console.ReadLine()) != "end")
            {
                string[] operation = commands.Split();
                if (operation[0] == "Delete")
                {
                    for (int i = 0; i < listOfIntegers.Count; i++)
                    {
                        int numberToDelete = int.Parse(operation[1]);
                        if (listOfIntegers[i] == numberToDelete)
                        {
                            listOfIntegers.Remove(numberToDelete); 
                            i-=1;
                        }
                    }
                }
                else if(operation[0] == "Insert")
                {
                    int elementToInsert = int.Parse(operation[1]);
                    int position = int.Parse(operation[2]);

                    listOfIntegers.Insert(position, elementToInsert);
                }
            }

            Console.WriteLine(string.Join(" ",listOfIntegers));
        }
    }
}