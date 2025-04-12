/*
4 5 3
-1
-1
 */


namespace P05E09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            while (input.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                sum = IncreaseOrDecrease(input, index, sum);
            }

            Console.WriteLine(sum);
        }

        private static int IncreaseOrDecrease(List<int> input, int index, int sum)
        {
            var removedElement = RemovedElement(input, index, ref sum);

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] <= removedElement)
                {
                    input[i] += removedElement;
                }
                else
                {
                    input[i] -= removedElement;
                }
            }

            return sum;
        }

        private static int RemovedElement(List<int> input, int index, ref int sum)
        {
            int removedElement = 0;
            if (index < 0)
            {
                removedElement = input[0];
                sum += input[0];
                input.RemoveAt(0);
                input.Insert(0, input[input.Count - 1]);
            }
            else if (index > input.Count - 1)
            {
                removedElement = input[input.Count - 1];
                sum += removedElement;
                input.RemoveAt(input.Count - 1);
                input.Add(input[0]);
            }
            else
            {
                removedElement = input[index];
                sum += removedElement;
                input.RemoveAt(index);
                return removedElement;
            }

            return removedElement;
        }
    }
}