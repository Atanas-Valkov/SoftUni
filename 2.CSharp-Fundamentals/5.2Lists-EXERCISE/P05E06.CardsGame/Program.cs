namespace P05E06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            List<int> secondPlayer = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            while (firstPlayer.Count> 0 && secondPlayer.Count > 0)
            {
                int firstCard = firstPlayer[0];
                int secondCard = secondPlayer[0];
                firstPlayer.RemoveAt(0);
                secondPlayer.RemoveAt(0);
                if (firstCard > secondCard)
                {
                    firstPlayer.Add(secondCard);
                    firstPlayer.Add(firstCard);
                }
                else if(firstCard < secondCard)
                {
                    secondPlayer.Add(firstCard);
                    secondPlayer.Add(secondCard);
                }

                if (firstPlayer.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
                    break;
                }
                if (secondPlayer.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
                    break;
                }
            }
        }
    }
}