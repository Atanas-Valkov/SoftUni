namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Cat cat = new Cat("Pesho");
           cat.Age = 10;
           Console.WriteLine(cat.Name);
        }
    }
}
