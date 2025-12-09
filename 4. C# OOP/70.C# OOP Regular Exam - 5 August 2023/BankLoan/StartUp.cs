using BankLoan.Core;
using BankLoan.Core.Contracts;
using System;
using System.IO;

namespace BankLoan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("input.txt"));

            var sw = new StreamWriter("output.txt")
            {
                AutoFlush = true
            };

            Console.SetOut(sw);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
