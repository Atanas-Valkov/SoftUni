using System.Collections.Generic;

namespace P07E6.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsepower = int.Parse(input[3]);

                type = char.ToUpper(type[0]) + type.Substring(1).ToLower();
                Vehicle vehicle = new Vehicle(type, model, color, horsepower);
                vehicles.Add(vehicle);
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle vehicle = vehicles.Find(x => x.Model == command);
                if (vehicle != null)
                {
                    Console.WriteLine($"Type: {vehicle.Type}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                }
            }
            var cars = vehicles.Where(x => x.Type.ToLower() == "car").ToList();
            var trucks = vehicles.Where(x => x.Type.ToLower() == "truck").ToList();
            double avrCarHp = cars.Any()? cars.Average(x => x.Horsepower): 0.00;
            double avrTruckHp = trucks.Any() ? trucks.Average(x => x.Horsepower) : 0.00;

            Print(avrCarHp, avrTruckHp);
        }
        private static void Print(double avrCarHp, double avrTruckHp)
        {
            Console.WriteLine($"Cars have average horsepower of: {avrCarHp:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avrTruckHp:F2}.");
        }
    }
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}