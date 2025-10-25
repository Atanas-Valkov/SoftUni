namespace P02E04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] doughInfo = Console.ReadLine().ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Pizza pizza = new Pizza(pizzaInfo[1], null);

                string flourType = doughInfo[1];
                string bakingType = doughInfo[2];
                double weight = double.Parse(doughInfo[3]);
                Dough dough = new Dough(bakingType, flourType, weight);
                pizza.Dough = dough;
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command.ToLower().
                        Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
