namespace P07L7.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalogs = new List<Catalog>();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string vehicle;
            while ((vehicle = Console.ReadLine()) != "end")
            {
                string[] token = vehicle.Split("/");

                string type = token[0];
                string brand = token[1];
                string model = token[2];
                string hP = token[3];

                Truck truck = new Truck(brand,model, hP);
                Car car = new Car(brand, hP, model);
                Catalog catalog = new Catalog(cars,trucks);

                if (type == "Truck")
                {
                    trucks.Add(truck);
                }
                else
                {
                    cars.Add(car);
                }
            }

            List<Car> sortedCars = cars.OrderBy(x=>x.CarBrand).ToList();


            Console.WriteLine($"Cars:");

            foreach (Car car in sortedCars)
            {
                Console.WriteLine($"{car.CarBrand}: {car.CarModel} - {car.CarHp}hp");
            }


            List<Truck> sortedTruck =trucks.OrderBy(x => x.TruckBrand).ToList();

            foreach (Truck truck in sortedTruck)
            {
                Console.WriteLine($"Trucks:");
                Console.WriteLine($"{truck.TruckBrand}: {truck.TruckModel} - {truck.TruckWeight}kg");
            }

        }
    }
    public class Truck
    {
        public Truck(string truckBrand, string truckModel, string truckWeight)
        {
            TruckBrand = truckBrand;
            TruckModel = truckModel;
            TruckWeight = truckWeight;
        }

        public string TruckBrand { get; set; }

        public string TruckModel { get; set; }

        public string TruckWeight { get; set; }
    }

    public class Car
    {
        public Car(string carBrand, string carHp, string carModel)
        {
            CarBrand = carBrand;
            CarHp = carHp;
            CarModel = carModel;
        }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CarHp { get; set; }


    }

    public class Catalog
    {
        public Catalog(List<Car> cars, List<Truck> trucks)
        {
            this.cars = cars;
            this.trucks = trucks;
        }

        public List<Car> cars { get; set; }

        public List<Truck> trucks { get; set; }
    }

}