/*
P34562Z q2576f H456z 

char asd = 'a';
Console.WriteLine(asd - 96);


 */



namespace P09E8.LettersChangeNumbers
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (var word in input)
            {
                char firstIndex = word[0];
                char lastIndex = word[word.Length - 1];
                double number = double.Parse(word.Substring(1, word.Length - 2));

                if (firstIndex >= 65 && firstIndex <= 90)
                {
                    sum += number / (firstIndex - 64);
                }
                else if(firstIndex >= 97 && firstIndex <= 122)
                {
                    sum += number * (firstIndex - 96);
                }

                if (lastIndex >= 65 && lastIndex <=90)
                {
                    sum -= lastIndex - 64;
                }
                else if(lastIndex >= 97 && lastIndex <= 122)
                {
                    sum += lastIndex - 96;
                }
                
            }
            
            Console.WriteLine($"{sum:f2}");

        }

    }
}