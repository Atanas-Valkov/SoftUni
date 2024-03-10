namespace P08ME1.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> contest = new Dictionary<string, string>();
            string input1;
            while ((input1 = Console.ReadLine()) != "end of contests")
            {
                string[] contestPassword = input1.Split(":");

                string nameContest = contestPassword[0];
                string passwordContest = contestPassword[1];

                contest.Add(nameContest, passwordContest);

            }


            string input2;
            while ((input2 = Console.ReadLine()) != "end of contests")
            {




            }



            foreach (var asd in contest)
            {
                Console.WriteLine($"{asd.Key}??{asd.Value}");
            }
        }
    }
}