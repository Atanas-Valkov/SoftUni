using P02E03.ShoppingSpree.Models;

namespace P02E03.ShoppingSpree
{
    public class Program                  // 80/100 ?!?!?!?!?!
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            int counter = 0;
            for (int i = 0; i < 2; i++)
            {
                string? line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }
                
                string[] input = line
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
               
                counter++;
                foreach (var item in input)
                {
                    try
                    {
                        string[] parts = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                        string name = parts[0];
                        decimal costOrMoney = decimal.Parse(parts[1]);
                        if (counter == 1)
                        {
                            Person person = new Person(costOrMoney, name);
                            persons.Add(person);
                        }
                        else
                        {
                            Product product = new Product(costOrMoney, name);
                            products.Add(product);
                        }
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                        return;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = parts[0];
                string productName = parts[1];

                Person filterPerson = persons.Find(p => p.Name == personName);

                filterPerson.BuyProduct(products.Find(p=>p.Name == productName));
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
