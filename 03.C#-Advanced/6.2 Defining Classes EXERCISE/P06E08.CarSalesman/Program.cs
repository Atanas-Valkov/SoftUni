using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P06E08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineLine[0];
                int enginePower = int.Parse(engineLine[1]);
                int? displacement = null;
                string? efficiency = null;

                Engine engine = new Engine(model, enginePower, displacement, efficiency);
                if (engineLine.Length == 3)
                {
                    if (int.TryParse(engineLine[2], out int disp))
                    {
                        displacement = disp;
                        engine.Displacement = displacement.Value;
                    }
                    else
                    {
                        efficiency = engineLine[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (engineLine.Length == 4)
                {
                    displacement = int.Parse(engineLine[2]);
                    efficiency = engineLine[3];
                    engine.Displacement = displacement.Value;
                    engine.Efficiency = efficiency;
                }
                engines[model]= engine;
            }

            int m = int.Parse(Console.ReadLine());
            Car[] car = new Car[m];

            for (int j = 0; j < m; j++)
            {
                string[] carLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

               string model = carLine[0];
                Engine carEngine = engines[carLine[1]];
                int? weight = null;
                string? color = null;

                if (carLine.Length == 3)
                {
                    if (int.TryParse(carLine[2], out int disp))
                    {
                        weight = disp;
                    }
                    else
                    {
                        color = carLine[2];
                    }
                }
                else if (carLine.Length == 4)
                {
                    weight = int.Parse(carLine[2]);
                    color = carLine[3];
                }

                car[j] = new Car(model, carEngine, weight, color);
            }

            foreach (var c in car)
            {
                Console.WriteLine($"{c.Model}:");
                Console.WriteLine($"  {c.Engine.Model}:");
                Console.WriteLine($"    Power: {c.Engine.Power}");
                Console.WriteLine($"    Displacement: {(c.Engine.Displacement == 0 ? "n/a" : c.Engine.Displacement.ToString())}");
                Console.WriteLine($"    Efficiency: {c.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {(c.Weight == null ? "n/a" : c.Weight.ToString())}");
                Console.WriteLine($"  Color: {(c.Color == null ? "n/a" : c.Color)}");
            }
        }
    }
}
