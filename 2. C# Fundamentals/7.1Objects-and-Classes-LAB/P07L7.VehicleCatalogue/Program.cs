using P07L7.VehicleCatalogue;

namespace P07L7.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog  catalogs = new Catalog();

            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] vehicleInfo = input.Split("/");
                string typeVehicle = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];

                if (typeVehicle == "Car")
                {
                    string horsePower = vehicleInfo[3];
                    catalogs.Cars.Add(new Car(brand, horsePower, model, typeVehicle));
                }
                else if (typeVehicle == "Truck")
                {
                    string weight = vehicleInfo[3];
                    catalogs.Trucks.Add(new Truck(brand, weight, model, typeVehicle));
                }
            }

            Pint(catalogs);
        }

        private static void Pint(Catalog catalogs)
        {
            if (catalogs.Cars.Count != 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car car in catalogs.Cars.OrderBy(x => x.brand))
                {
                    Console.WriteLine($"{car.brand}: {car.model} - {car.horsePower}hp");
                }
            }

            if (catalogs.Trucks.Count != 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truck in catalogs.Trucks.OrderBy(x => x.brand))
                {
                    Console.WriteLine($"{truck.brand}: {truck.model} - {truck.weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public Truck(string brand, string weight, string model, string typeVehicle)
        {
            this.brand = brand;
            this.weight = weight;
            this.model = model;
            this.typeVehicle = typeVehicle;
        }
        public string typeVehicle { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string weight { get; set; }
    }

    public class Car
    {
        public Car(string brand, string horsePower, string model, string typeVehicle)
        {
            this.typeVehicle = typeVehicle;
            this.brand = brand;
            this.horsePower = horsePower;
            this.model = model;
        }
        public string typeVehicle { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string horsePower { get; set; }
    }
}
public class Catalog
{
    public Catalog()
    {
        Cars = new List<Car>();
        Trucks = new List<Truck>();
    }
    public List<Car> Cars { get; set; }
    public List<Truck> Trucks { get; set; }
}