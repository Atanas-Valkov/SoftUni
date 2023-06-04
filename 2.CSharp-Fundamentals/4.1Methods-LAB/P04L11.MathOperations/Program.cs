namespace P04L11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNumber, operators, secondNumber));
        }

        static double Calculate(double firstNumber, string operators, double secondNumber)
        {
            double result = 0;
            if (operators == "/")
            {
                result = firstNumber / secondNumber;
            }
            else if (operators == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operators == "+")
            {
                result = firstNumber + secondNumber;
            }
            else
            {
                result = firstNumber - secondNumber;
            }

            return result;
        }



    }
}