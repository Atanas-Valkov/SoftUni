using System.Text;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstLine= Console.ReadLine();
            StringBuilder sb = new StringBuilder(firstLine);
            string input;
            
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputarr = input.Split();
                string firstArgument = inputarr[0];

                if (firstArgument == "Change")
                {
                    string secondArgument = inputarr[1];
                    string thirdArgument = inputarr[2];

                    sb.Replace(secondArgument, thirdArgument);
                    Console.WriteLine(sb);

                }
                else if (firstArgument == "Includes")
                {
                    string secondArgument = inputarr[1];

                    if (sb.ToString().Contains(secondArgument))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (firstArgument == "End")
                {
                   string secondArgument = inputarr[1];
                   bool endsWithGivenString = sb.ToString().EndsWith(secondArgument);

                   if (endsWithGivenString)
                   {
                       Console.WriteLine("True");
                   }
                   else
                   {
                       Console.WriteLine("False");
                   }
                }
                else if (firstArgument == "Uppercase")
                {
                    for (int i = 0; i < sb.Length; i++)
                    {
                        sb[i] = char.ToUpper(sb[i]);
                    }

                    Console.WriteLine(sb);
                }
                else if (firstArgument == "FindIndex")
                {
                    string secondArgument = inputarr[1];
                    int  findIndex = sb.ToString().IndexOf(secondArgument);


                    if (findIndex != -1 )
                    {
                        Console.WriteLine(findIndex);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (firstArgument == "Cut")
                {
                    int secondArgument = int.Parse(inputarr[1]);
                    int thirdArgument = int.Parse(inputarr[2]);

                    sb.Remove(secondArgument + thirdArgument, sb.Length - (secondArgument + thirdArgument));
                    sb.Remove(0, secondArgument);
                    Console.WriteLine(sb);

                }

            }

        }

    }
}