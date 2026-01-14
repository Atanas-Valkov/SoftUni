using System.Diagnostics.Metrics;

namespace P01ME05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numbersOfLetter = int.Parse(Console.ReadLine());
            string letter = "";

            for (int i = 1; i <= numbersOfLetter; i++)
            {
                int digit = int.Parse(Console.ReadLine());
                int lastdigit = digit % 10;
                if (lastdigit == 2)
                {
                    if (digit == 2)
                    {
                        letter += 'a';
                    }
                    else if (digit == 22)
                    {
                        letter += 'b';
                    }
                    else
                    {
                        letter += 'c';
                    }
                }
                else if (lastdigit == 3)
                {
                    if (digit == 3)
                    {
                        letter += 'd';
                    }
                    else if (digit == 33)
                    {
                        letter += 'e';
                    }
                    else
                    {
                        letter += 'f';
                    }
                }
                else if (lastdigit == 4)
                {
                    if (digit == 4)
                    {
                        letter += 'g';
                    }
                    else if (digit == 44)
                    {
                        letter += 'h';
                    }
                    else
                    {
                        letter += 'i';
                    }
                }
                else if (lastdigit == 5)
                {
                    if (digit == 5)
                    {
                        letter += 'j';
                    }
                    else if (digit == 55)
                    {
                        letter += 'k';
                    }
                    else
                    {
                        letter += 'l';
                    }
                }
                else if (lastdigit == 6)
                {
                    if (digit == 6)
                    {
                        letter += 'm';
                    }
                    else if (digit == 66)
                    {
                        letter += 'n';
                    }
                    else
                    {
                        letter += 'o';
                    }
                }
                else if (lastdigit == 7)
                {
                    if (digit == 7)
                    {
                        letter += 'p';
                    }
                    else if (digit == 77)
                    {
                        letter += 'q';
                    }
                    else if (digit == 777)
                    {
                        letter += 'r';
                    }
                    else
                    {
                        letter += 's';
                    }

                }
                else if (lastdigit == 8)
                {
                    if (digit == 8)
                    {
                        letter += 't';
                    }
                    else if (digit == 88)
                    {
                        letter += 'u';
                    }
                    else
                    {
                        letter += 'v';
                    }
                }
                else if (lastdigit == 9)
                {
                    if (digit == 9)
                    {
                        letter += 'w';
                    }
                    else if (digit == 99)
                    {
                        letter += 'x';
                    }
                    else if (digit == 999)
                    {
                        letter += 'y';
                    }
                    else
                    {
                        letter += 'x';
                    }
                }
                else if(lastdigit == 0)
                {
                    letter += ' ';
                }
            }
            Console.WriteLine(letter);
        }
    }
}