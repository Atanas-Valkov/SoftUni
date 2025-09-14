using System.Net.NetworkInformation;

namespace _01.PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> contestant = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> piecesEachPie = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            while (contestant.Any() && piecesEachPie.Any())
            {

                if (piecesEachPie.Peek() == 1)
                {
                    if (piecesEachPie.Count != 0)
                    {
                        piecesEachPie.Push(piecesEachPie.Pop() + 1);
                        continue;
                    }
                }
  int currentPiecesEachPie = piecesEachPie.Pop();
                int currentContestant = contestant.Dequeue();
                if (currentContestant >= currentPiecesEachPie)
                {
                    int remaining = currentContestant - currentPiecesEachPie;
                    contestant.Enqueue(remaining);
                }
                else if (currentContestant < currentPiecesEachPie)
                {
                    int removedPie = currentPiecesEachPie - currentContestant;
                    piecesEachPie.Push(removedPie);
                }
            }
            Print(piecesEachPie, contestant);
        }

        private static void Print(Stack<int> piecesEachPie, Queue<int> contestant)
        {
            if (!piecesEachPie.Any() && contestant.Any())
            {
                Console.WriteLine($"We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {string.Join(", ", contestant)}");
            }
            else
            {
                Console.WriteLine($"Our contestants need to rest!");
                Console.WriteLine($"Pies left: {string.Join(", ", piecesEachPie)}");
            }

            if (!piecesEachPie.Any() && !contestant.Any())
            {
                Console.WriteLine($"We have a champion!");
            }
        }
    }
}
