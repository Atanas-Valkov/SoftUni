using Car;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tires[]> tires = new List<Tires[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string command = " ";
            ProvidingTires(tires, command);
            ProvidingEngines(engines, command);
            ProvidingCars(engines, tires, cars, command);
            DriveAndPrint(cars);
        }

        private static void ProvidingCars(List<Engine> engines, List<Tires[]> tires, List<Car> cars, string command)
        {
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] parts = command.Split(" ");

                string make = parts[0];
                string model = parts[1];
                int year = int.Parse(parts[2]);
                double fuelQuantity = double.Parse(parts[3]);
                double fuelConsumption = double.Parse(parts[4]);
                int engineIndex = int.Parse(parts[5]);
                int tiresIndex = int.Parse(parts[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }
        }
        private static void ProvidingEngines(List<Engine> engines, string command)
        {

            while ((command = Console.ReadLine()) != "Engines done")
            {
                double[] tireInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                int horsePower = (int)tireInfo[0];
                double cubicCapacity = tireInfo[1];

                Engine engin = new Engine(horsePower, cubicCapacity);
                engines.Add(engin);
            }
        }
        private static void ProvidingTires(List<Tires[]> tires, string command)
        {
            while ((command = Console.ReadLine()) != "No more tires")
            {
                double[] tireInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                int firsYear = (int)tireInfo[0];
                double firstPressure = tireInfo[1];
                int secondYear = (int)tireInfo[2];
                double secondPressure = tireInfo[3];
                int thirdYear = (int)tireInfo[4];
                double thirdPressure = tireInfo[5];
                int fourthYear = (int)tireInfo[6];
                double fourthPressure = tireInfo[7];

                Tires[] pearTier =
                [
                    new Tires(firsYear, firstPressure),
                    new Tires(secondYear, secondPressure),
                    new Tires(thirdYear, thirdPressure),
                    new Tires(fourthYear, fourthPressure)
                ];
                tires.Add(pearTier);
            }
        }

        private static void DriveAndPrint(List<Car> cars)
        {
            var result = cars
                .Where(car => car.Year >= 2017)
                .Where(car => car.Engine.HorsePower > 330)
                .Where(car =>
                {
                    double tiresPressureSum = car
                        .Tires
                        .Select(t => t.Pressure)
                        .Sum();

                    return tiresPressureSum > 9 && tiresPressureSum < 10;
                })
                .ToList();

            foreach (var car in result)
            {
                car.Drive(20);
                Console.WriteLine($@"Make: {car.Make}
Model: {car.Model}
Year: {car.Year}
HorsePowers: {car.Engine.HorsePower}
FuelQuantity: {car.FuelQuantity}
");
            }
 
        }
    }
}
