namespace P08ME3.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = arguments[0];
                double fuelAmount = double.Parse(arguments[1]);
                double fuelPerKilometer = double.Parse(arguments[2]);

                Car car = new Car(fuelAmount, fuelPerKilometer, model);
                cars.Add(car);
            }
            Car helper = new Car(0, 0, " ");
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string drive = tokens[0];
                string modelCar = tokens[1];
                double traveledDistance = double.Parse(tokens[2]);

                helper.CalculateDriveDistance(traveledDistance, cars, modelCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }

        public class Car
        {
            public void CalculateDriveDistance(double traveledDistance, List<Car> cars, string modelCar)
            {
                var car = cars.FirstOrDefault(x => x.Model == modelCar);

                if (car != null)
                {
                    if (car.FuelAmount < traveledDistance * car.FuelPerKilometer)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                        return;
                    }
                    car.FuelAmount -= traveledDistance * car.FuelPerKilometer;
                   car.TraveledDistance += traveledDistance;
                }
            }


            public Car(double fuelAmount, double fuelPerKilometer, string model)
            {
                FuelAmount = fuelAmount;
                FuelPerKilometer = fuelPerKilometer;
                Model = model;
                TraveledDistance = 0;
            }

            public string Model { get; set; }
            public double FuelAmount { get; set; }
            public double FuelPerKilometer { get; set; }
            public double TraveledDistance { get; set; }

        }
    }
}