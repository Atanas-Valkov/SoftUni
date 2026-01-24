using P04E01.Vehicles.Models.Interfaces;
using P04E02.VehiclesExtension.Models;

namespace P04E02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicles car = new Car(
                double.Parse(carInfo[1]),
                double.Parse(carInfo[2]),
                double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicles truck = new Truck(
                double.Parse(truckInfo[1]),
                double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(
                double.Parse(busInfo[1]),
                double.Parse(busInfo[2]),
                double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

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
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Drive(distance));
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
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(liters);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(commandParts[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
