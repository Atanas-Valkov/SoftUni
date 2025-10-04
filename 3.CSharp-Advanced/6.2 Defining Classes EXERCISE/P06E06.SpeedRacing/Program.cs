using System.Reflection;
using System.Threading.Channels;
using System.Xml.Schema;

namespace P06E06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsumptionFor1km = double.Parse(line[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars[car.Model] = car;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] lineInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = lineInfo[1];
                double amountOfKm = double.Parse(lineInfo[2]);

                Car car = cars[model];
                if (!car.Drive(amountOfKm))
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
