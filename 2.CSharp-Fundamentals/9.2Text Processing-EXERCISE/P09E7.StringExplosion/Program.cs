using System.Text;

namespace P09E7.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '>')
                {
                    sb.Append(input[i]);
                    strength += int.Parse(input[i + 1].ToString());

                }
                else if (strength == 0)
                {
                    sb.Append(input[i]);
                }
                else
                {
                    strength--;
                }


            }

            Console.WriteLine(sb);

        }
    }
}