using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace P04E04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (BetweenSixAndTenCharacters(password) == false)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }
            if (OnlyLettersAndDigits(password) == false)
            {
                Console.WriteLine($"Password must consist only of letters and digits");
            }
            if (AtLeastTwoDigits(password)== false)
            {
                Console.WriteLine($"Password must have at least 2 digits");
            }
            if (BetweenSixAndTenCharacters(password) == true && OnlyLettersAndDigits(password) == true && 
                     AtLeastTwoDigits(password) ==true)
            {
                Console.WriteLine($"Password is valid");
            }

        }

        static bool AtLeastTwoDigits(string password)
        {
            int digits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];
                if (currentChar >= 48 && currentChar <= 57)
                {
                    digits++;
                }
            }
            if (digits < 2)
            {
                return false;
            }
            return true;
        }
        static bool OnlyLettersAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char currentDigit = password[i];
                if (!char.IsDigit(currentDigit) && !char.IsLetter(currentDigit))
                {
                    
                    return false;
                }
            }
            return true;
        }
        static bool BetweenSixAndTenCharacters(string password)
        {
            int charCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                charCounter++;
            }
            if (charCounter < 6 || charCounter > 10)
            {
                return false;
            }
            return true;
        }
    }
}