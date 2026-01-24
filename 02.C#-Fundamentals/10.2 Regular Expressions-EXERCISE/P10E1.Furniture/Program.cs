using System.Text.RegularExpressions;

namespace P10E1.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> list = new List<Furniture>();

            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d{1,}|\d{1,}.\d{1,})!(?<quantity>\d+)";

            MatchCollection match = Regex.Matches(pattern, pattern);

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Regex r = new Regex(pattern);
                MatchCollection collection = r.Matches(input);

                foreach (Match m in collection)
                {
                    string name = m.Groups["name"].Value;
                    ;
                    decimal price = decimal.Parse(m.Groups["price"].Value);
                    int quantity = int.Parse(m.Groups["quantity"].Value);
                    Furniture f = new Furniture(name, price, quantity);

                    list.Add(f);
                }
            }
            Console.WriteLine($"Bought furniture:");
            decimal total = 0m;
            foreach (Furniture print in list)
            {
                Console.WriteLine(print.Name);
                total += print.Total();
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }

        class Furniture
        {
            public Furniture(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public int Quantity { get; set; }

            public decimal Total()
            {
                return Price * Quantity;
            }

        }

    }
}