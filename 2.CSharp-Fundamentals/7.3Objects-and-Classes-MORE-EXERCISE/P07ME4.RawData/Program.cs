using System.Net;
using System.Threading.Channels;

namespace P07ME4.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Car car = new Car(cargoType, cargoWeight, new Engine(engineSpeed, enginePower), model);
                cars.Add(car);
            }

            string type = Console.ReadLine();
            if (type == "fragile")
            {
                cars
                    .Where(x => x.CargoType == "fragile" && x.CargoWeight < 1000)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else if (type == "flamable")
            {
                cars
                    .Where(x => x.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
        public class Car
        {
            public Car(string cargoType, int cargoWeight, Engine engine, string model)
            {
                CargoType = cargoType;
                CargoWeight = cargoWeight;
                Engine = engine;
                Model = model;
            }

            public Engine Engine { get; set; }
            public string Model { get; set; }
            public int CargoWeight { get; set; }
            public string CargoType { get; set; }
        }
        public class Engine
        {
            public Engine(int engineSpeed, int enginePower)
            {
                EngineSpeed = engineSpeed;
                EnginePower = enginePower;
            }
            public int EngineSpeed { get; set; }
            public int EnginePower { get; set; }
        }
    }
}