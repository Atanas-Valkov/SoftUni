namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList() { "Gosho", "Ivan", "Petar" };
            string value = randomList.RandomString();

            Console.WriteLine(value);
            Console.WriteLine(randomList.Count);
        }
    }
}
