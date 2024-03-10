namespace P05E08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console
                .ReadLine()
                .Split()
                .ToList();



            string commands = " ";
            while ((commands = Console.ReadLine()) != "3:1")
            {
                string[] elements = commands.Split();

                if (elements[0] == "merge")
                {
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);


                    //         List<string> margeList = new List<string>();
                    //         margeList = inputList;









                }
                else if (commands == "divide")
                {
                    
                }












            }






            Console.WriteLine(string.Join(" ",inputList ));
        }
    }
}