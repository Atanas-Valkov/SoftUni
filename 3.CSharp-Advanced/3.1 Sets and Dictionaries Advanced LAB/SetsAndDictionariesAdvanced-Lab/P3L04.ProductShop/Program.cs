namespace P3L04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shop =
                new SortedDictionary<string, Dictionary<string, double>>();

            string command = " ";
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] shopInfo = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = shopInfo[0];
                string productName = shopInfo[1];
                double price = double.Parse(shopInfo[2]);

                if (!shop.ContainsKey(shopName))
                {
                    shop.Add(shopName, new Dictionary<string, double>());
                }

                shop[shopName].Add(productName, price);
            }

            foreach (var kvp in shop)
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}