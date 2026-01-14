namespace P04ME5.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            IsNegativePositiveOrZero(number1, number2, number3);
            Console.WriteLine(IsNegativePositiveOrZero(number1,number2,number3));
        }

        private static string IsNegativePositiveOrZero(int number1, int number2, int number3)
        {
            string result = "";
            if (number1 == 0 || number2 == 0 || number3 == 0)
            {
                result = "zero";
            }
            else if (number1 > 0 && number2 > 0 && number3 > 0)
            {
                result = "positive";
            }
            else if (number1 < 0 || number2 < 0 || number3 < 0)
            {
                if (number1 < 0 && number2 < 0 && number3 < 0)
                {
                    result = "negative";
                }
                else if ((number1 < 0 && number2 < 0) || (number1 < 0 && number3 < 0) || (number2 < 0 && number3<0))
                {
                    result = "positive";
                }
                else
                {
                    result = "negative";
                }
            }
            return result;
        }
    }
}