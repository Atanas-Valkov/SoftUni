
namespace P08E3.Orders
{
    internal class Program
    {

        public class Product    
        {
            public Product(string name, double price, double quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name  { get; set; }

            public double Price { get; set; }

            public double Quantity { get; set; }


            public void Update(double price , double quantity)
            {
                Price = price;
                Quantity += quantity;
            }

            public double TotalPrice
            {
                get { return Price * Quantity; }
            }

            public override string ToString()
            {
                return $"{Name} -> {(Price * Quantity):f2}";
            }
        }



        static void Main(string[] args)
        {
            Dictionary<string, Product> kvp = new Dictionary<string, Product>();
            double totalPrice = 0;
            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] products = input.Split();

                string name = products[0];
                double price = double.Parse(products[1]);
                double quantity = double.Parse(products[2]);

                 Product newProduct = new Product(name, price, quantity);

                if (!kvp.ContainsKey(newProduct.Name))
                {
                    kvp.Add(newProduct.Name, newProduct);
                }
                else
                {
                    Product asd = kvp[newProduct.Name];
                    asd.Update(newProduct.Price,newProduct.Quantity);
                }
                

            }

            foreach (KeyValuePair<string, Product> print in kvp)
            {
                Console.WriteLine($"{print.Value}");
            }



        }
    }
}