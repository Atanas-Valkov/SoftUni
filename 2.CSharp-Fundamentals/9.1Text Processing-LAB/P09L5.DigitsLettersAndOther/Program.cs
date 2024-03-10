using System.Security.Cryptography.X509Certificates;

namespace P09L5.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input= Console.ReadLine();

          //string digits = "";
          //string letters = "";
          //string otherChar = "";
          //
          // for (int i = 0; i < input.Length; i++)
          // {
          //    if (char.IsNumber(input[i]))
          //    {
          //        digits += input[i];
          //    }
          //    if(char.IsLetter(input[i]))
          //    {
          //        letters += input[i];
          //    }
          //    if(!char.IsLetterOrDigit(input[i]))
          //    {
          //        otherChar += input[i];
          //    }
          //
          // }
          //
          // Console.WriteLine(digits);
          // Console.WriteLine(letters);
          // Console.WriteLine(otherChar);
          


            Console.WriteLine(string.Join("",input.Where(char.IsDigit)));
            Console.WriteLine(string.Join("", input.Where(char.IsLetter)));
            Console.WriteLine(string.Join("", input.Where(x =>!char.IsLetterOrDigit(x))));


        }
    }
}