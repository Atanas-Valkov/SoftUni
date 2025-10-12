/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END

Maria=0
Coffee=2
Maria Coffee
END
 */
namespace P07ME5.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < personInfo.Length; j++)
            {
                string[] info = personInfo[0 + j].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                double money = double.Parse(info[1]);

                persons.Add(new Person(money, name));
            }

            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < productInfo.Length; j++)
            {
                string[] info = productInfo[0 + j].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string nameProduct = info[0];
                double costProduct = double.Parse(info[1]);

                Product product = new Product(costProduct, nameProduct);
                products.Add(product);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string product = tokens[1];

                Person person = persons.FirstOrDefault(x => x.Name == name);
                Product productss = products.FirstOrDefault(x => x.NameProduct == product);

                if (person != null && productss != null)
                {
                    if (person.Budget >= productss.CostProduct)
                    {
                        person.Budget -= productss.CostProduct;
                        person.Bag.Add(productss);
                        Console.WriteLine($"{person.Name} bought {productss.NameProduct}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {productss.NameProduct}");
                    }
                }
            }
            foreach (var person in persons)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag.Select(p => p.NameProduct))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    public class Person
    {
        public Person(double budget, string name)
        {
            Bag = new List<Product>();
            Budget = budget;
            Name = name;
        }
        public string Name { get; set; }
        public double Budget { get; set; }
        public List<Product> Bag { get; set; }
    }
    public class Product
    {
        public Product(double costProduct, string nameProduct)
        {
            CostProduct = costProduct;
            NameProduct = nameProduct;
        }
        public string NameProduct { get; set; }
        public double CostProduct { get; set; }
    }
}




