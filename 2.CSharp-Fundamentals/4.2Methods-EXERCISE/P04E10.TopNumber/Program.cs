namespace P04E10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());
            for (int i = 2; i <= endValue; i++)
            {
                int currentDigit = i;
                DigitsIsDivisibleBy8(endValue, currentDigit);
                HoldOneOddDigit(endValue,currentDigit );
                if (DigitsIsDivisibleBy8(endValue, currentDigit) && HoldOneOddDigit(endValue, currentDigit))
                {
                    Console.WriteLine(currentDigit);
                }
            }
        }

        static bool DigitsIsDivisibleBy8(int endValue, int currentDigit)
        {
            int sum = 0;
            while (currentDigit > 0)
            {
                int lastDigit = currentDigit % 10;
                currentDigit /= 10;
                sum += lastDigit;
            }
            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
        static bool HoldOneOddDigit(int endValue, int currentDigit)
        {
            while (currentDigit > 0)
            {
                int lastDigit = currentDigit % 10;
                currentDigit /= 10;
                if (lastDigit % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}