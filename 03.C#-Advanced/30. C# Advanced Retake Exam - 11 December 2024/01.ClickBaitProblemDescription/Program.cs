using System.Xml.Linq;

namespace _01.ClickBaitProblemDescription
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> fifo = new Queue<int>();
            Stack<int> lifo = new Stack<int>();

            int[] fifoLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < fifoLine.Length; i++)
            {
                fifo.Enqueue(fifoLine[i]);
            }

            int[] lifoLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> finalFeedCollection = new List<int>();

            for (int i = 0; i < lifoLine.Length; i++)
            {
                lifo.Push(lifoLine[i]);
            }

            int target = int.Parse(Console.ReadLine());
            int greaterSequences = fifo.Count > lifo.Count
                    ? greaterSequences = fifo.Count
                    : greaterSequences = lifo.Count;

            while (fifo.Any() && lifo.Any())
            {

                int currentFifo = fifo.Dequeue();
                int currentLifo = lifo.Pop();
                int moduloOperation = 0;
                if (currentFifo != 0 && currentLifo != 0)
                {
                    moduloOperation = currentFifo > currentLifo
                        ? currentFifo % currentLifo
                       : currentLifo % currentFifo;
                }
                else
                {
                    moduloOperation = 0;
                }

                if (currentLifo > currentFifo)
                {
                    finalFeedCollection.Add(moduloOperation);
                    moduloOperation *= 2;
                    if (moduloOperation != 0)
                    {
                        lifo.Push(moduloOperation);
                    }
                }
                else if (currentLifo < currentFifo)
                {
                    if (moduloOperation != 0)
                    {
                        int doubleTheRemainder = moduloOperation * 2;
                        fifo.Enqueue(doubleTheRemainder);
                    }
                    moduloOperation = moduloOperation - (moduloOperation * 2);
                    finalFeedCollection.Add(moduloOperation);
                }
                else if (currentLifo == currentFifo)
                {
                    finalFeedCollection.Add(0);
                }

            }

            int sumOfElements = finalFeedCollection.Sum();
            Console.WriteLine($"Final Feed: {string.Join(", ", finalFeedCollection)}");
            if (sumOfElements >= target)
            {
                Console.WriteLine($"Goal achieved! Engagement Value: {sumOfElements}");
            }
            else
            {
                int shortfall = target - sumOfElements;
                Console.WriteLine($"Goal not achieved! Short by: {shortfall}");
            }
        }
    }
}
