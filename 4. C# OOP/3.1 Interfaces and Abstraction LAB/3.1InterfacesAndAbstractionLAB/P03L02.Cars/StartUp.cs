namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Red" ,"Model 3",2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());

        }
    }
}
