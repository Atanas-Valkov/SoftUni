using System.Runtime.CompilerServices;
using P04E01.Vehicles.Models.Interfaces;

namespace P04E01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            IVehicles car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            IVehicles truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];
                string vehicleType = commandParts[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandParts[2]);
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(commandParts[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.fuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.fuelQuantity:F2}");
        }
    }
}
 