
namespace P08E3.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Order> orders = new Dictionary<string, Order>();

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "buy")
            {
                string[] command = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string product = command[0];
                decimal price = decimal.Parse(command[1]);
                decimal quantity = decimal.Parse(command[2]);
                Order order = new Order(price, product, quantity);
                if (!orders.ContainsKey(product))
                {
                    orders.Add(product, order);
                }
                else
                {
                    orders[product].Quantity += quantity;
                }
                orders[product].Price = price;
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Value.Product} -> {item.Value.TotalPrice:F2}");
            }
        }
    }

    public class Order
    {
        public Order(decimal price, string product, decimal quantity)
        {
            Price = price;
            Product = product;
            Quantity = quantity;
        }

        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}