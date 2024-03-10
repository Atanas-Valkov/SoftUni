using System.Runtime.Serialization;

namespace P01ME03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double copyBalance = balance;
            string game = string.Empty;
            double priceOfTheGame = 0;

            while ((game = Console.ReadLine()) != "Game Time")
            {
                if (game == "OutFall 4")
                {
                    priceOfTheGame = 39.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "CS: OG")
                {
                    priceOfTheGame = 15.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "Zplinter Zell")
                {
                    priceOfTheGame = 19.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "Honored 2")
                {
                    priceOfTheGame = 59.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch")
                {
                    priceOfTheGame = 29.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    priceOfTheGame = 39.99;
                    if (priceOfTheGame > copyBalance)
                    {
                        Console.WriteLine($"Too Expensive");
                        continue;
                    }
                    copyBalance -= priceOfTheGame;
                    Console.WriteLine($"Bought {game}");
                }
                else
                {
                    Console.WriteLine($"Not Found");
                }

                if (copyBalance == 0)
                {
                    Console.WriteLine($"Out of money!");
                    break;
                }
            }

            if (copyBalance>0)
            {
                double spent = balance - copyBalance;
              Console.WriteLine($"Total spent: ${spent:F2}. Remaining: ${copyBalance:F2}");
              
            }
        }
    }
}