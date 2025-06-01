namespace P3L07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] arguments = inputLine.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = arguments[0];
                string carPlate = arguments[1];

                if (command == "IN")
                {
                    parking.Add(carPlate);
                }
                else if (command == "OUT")
                {
                    parking.Remove(carPlate);
                }
            }

            if (parking.Any())
            {
                foreach (var numberPlats in parking)
                {
                    Console.WriteLine(numberPlats);
                }

            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
