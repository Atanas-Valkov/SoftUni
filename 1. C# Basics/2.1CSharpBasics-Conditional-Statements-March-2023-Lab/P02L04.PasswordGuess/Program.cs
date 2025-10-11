using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace P04.PasswordGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            string Welcome = Console.ReadLine();

            if (Welcome == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }    


        }
    }
}
