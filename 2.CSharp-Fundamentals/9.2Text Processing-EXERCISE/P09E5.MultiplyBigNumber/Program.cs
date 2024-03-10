using System.Text;

namespace P09E5.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string bigNumber = Console.ReadLine();

          int singleDigit = int.Parse(Console.ReadLine());

          int remainder = 0;

          StringBuilder sb = new StringBuilder();

          for (int i = bigNumber.Length - 1; i >= 0; i--)
          {
                int currentDigit = int.Parse(bigNumber[i].ToString());
                currentDigit = (currentDigit * singleDigit) + remainder;

                sb.Append(currentDigit % 10);
                remainder = currentDigit / 10;
          }

          if (remainder>0 )
          {
              sb.Append(remainder);
          }

          if ( bigNumber == "0" || singleDigit == 0)
          {
              Console.WriteLine("0");
          }
          else
          {
              Console.WriteLine(string.Join("",sb.ToString().Reverse()));
          }
        }
    }
}