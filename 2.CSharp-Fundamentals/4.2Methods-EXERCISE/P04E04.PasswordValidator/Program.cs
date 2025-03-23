using System;

namespace P04E04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool sixToTen = SixToTenCharactersInclusive(password);
           bool onlyLetters = OnlyLettersAndDigits(password);
            bool twoDigits = AtLeastTwoDigits(password);
            if (sixToTen && onlyLetters && twoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool SixToTenCharactersInclusive(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                counter++;
            }

            if (counter < 6 || counter > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
            return true;
        }

        private static bool OnlyLettersAndDigits(string? password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                password = password.ToLower();
                if (!char.IsDigit(password[i]) && !char.IsLetter(password[i]))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }
            return true;
        }

        private static bool AtLeastTwoDigits(string? password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] > 47 && password[i] < 58)
                {
                    counter++;
                }
            }

            if (counter < 2)
            {
                Console.WriteLine($"Password must have at least 2 digits");
                return false;
            }

            return true;
        }
    }
}