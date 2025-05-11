/*
 

5
1
Mercedes
green
END

10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END

 */


using System.Threading.Channels;

namespace P01E10.Crossroads_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isHit = false;
            int constantGreenLight = int.Parse(Console.ReadLine());
            int constantFreeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string commandInfo;
            int totalCarsPassed = 0;
            while ((commandInfo = Console.ReadLine()) != "END")
            {
                string car = commandInfo;
                if (commandInfo != "green")
                {
                    cars.Enqueue(car);
                }
                else
                {
                    int greenLight = constantGreenLight;
                    int freeWindow = constantFreeWindow;

                    while (cars.Any() && greenLight > 0)
                    {
                        string currentCar = cars.Dequeue();
                        int carLength = currentCar.Length;

                        if (greenLight >= carLength)
                        {
                            greenLight -= carLength;
                            totalCarsPassed++;
                        }
                        else if (greenLight + freeWindow >= carLength)
                        {
                            totalCarsPassed++;
                            greenLight = 0;
                        }
                        else
                        {
                            isHit = true;
                            int hitIndex = greenLight + freeWindow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[hitIndex]}.");
                            break;
                        }
                    }
                }

                if (isHit)
                {
                    break;
                }
            }

            if (!isHit)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
