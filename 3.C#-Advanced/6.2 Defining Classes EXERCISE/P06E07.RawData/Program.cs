using System.Threading.Channels;

namespace P06E07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = line[0];
                int engineSpeed = int.Parse(line[1]);
                int enginePower = int.Parse(line[2]);
                int cargoWeight = int.Parse(line[3]);
                string cargoType = line[4];
                double tire1Pressure = double.Parse(line[5]);
                int tire1Age = int.Parse(line[6]);
                double tire2Pressure = double.Parse(line[7]);
                int tire2Age = int.Parse(line[8]);
                double tire3Pressure = double.Parse(line[9]);
                int tire3Age = int.Parse(line[10]);
                double tire4Pressure = double.Parse(line[11]);
                int tire4Age = int.Parse(line[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire[] tires =
                [
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)

                ];

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine().ToLower();
            IEnumerable<string> result;

            if (command == "fragile")
            {
                 result = cars
                     .Where(c=>c.Cargo.Type == "fragile")
                    .Where(c => c.Tires.Any(t => t.Pressure < 1))
                    .Select(m=>m.Model);
            }
            else if (command == "flammable")
            {
                 result = cars
                     .Where(c=>c.Cargo.Type == "flammable")
                    .Where(c => c.Engine.EnginePower > 250)
                    .Select(c => c.Model);
            }
            else
            {
                result = Array.Empty<string>();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car);
            }
        }
    }
}
