namespace P01L8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            string command = " ";
            Queue<string> cars = new Queue<string>();
            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        string passedCar = cars.Dequeue();
                        Console.WriteLine($"{passedCar} passed!");
                        counter++;
                    }
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
