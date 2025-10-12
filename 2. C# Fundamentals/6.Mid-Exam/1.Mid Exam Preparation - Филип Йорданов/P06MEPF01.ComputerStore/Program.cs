namespace P06MEPF01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumWithoutTax = 0;
            double sumWithTax = 0;
            double sumWithTaxAfterDiscount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "special" || input == "regular")
                {
                    if (input == "special")
                    {
                        sumWithTax = sumWithoutTax * 1.2;

                        sumWithTaxAfterDiscount = sumWithTax * 0.9;
                    }
                    if (input == "regular")
                    {
                        sumWithTax = sumWithoutTax * 1.2;
                        sumWithTaxAfterDiscount = sumWithTax;
                    }
                    break;
                }

                double currentPrice = double.Parse(input);

                if (currentPrice <= 0)
                {
                    Console.WriteLine($"Invalid price!");
                    continue;
                }
                sumWithoutTax += currentPrice;
            }

            if (sumWithoutTax == 0)
            {
                Console.WriteLine($"Invalid order!");
                return;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sumWithoutTax:f2}$");
            Console.WriteLine($"Taxes: {(sumWithTax - sumWithoutTax):f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {sumWithTaxAfterDiscount:f2}$");
        }
    }
}