using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Xml.Linq;
/*
1 1 2 2 3 3 4 4 5 5 
1 0
-1 0
end
 */

namespace P06ME12_08_20_03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfTwins = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int counter = 0 ;
            string numbers ="";
            bool end = false;
            while ((numbers= Console.ReadLine()) != "end")
            {
         
                counter ++ ;
                string[] index = numbers.Split();
                int firstIndex = int.Parse(index[0]);
                int secondIndex = int.Parse(index[1]);

                if (firstIndex == secondIndex || firstIndex<0 || secondIndex<0 || firstIndex>=listOfTwins.Count || secondIndex>=listOfTwins.Count)
                {
                    string addMatchingElements = "-" + counter + "a";
                    listOfTwins.Insert(listOfTwins.Count/2, addMatchingElements);
                    listOfTwins.Insert(listOfTwins.Count / 2, addMatchingElements);

                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (listOfTwins[firstIndex] == listOfTwins[secondIndex])
                {
                    if (secondIndex>0)
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {listOfTwins[firstIndex]}!");
                        listOfTwins.Remove(listOfTwins[firstIndex]);
                        listOfTwins.Remove(listOfTwins[secondIndex - 1]);
                    }
                    else
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {listOfTwins[firstIndex]}!");
                        listOfTwins.Remove(listOfTwins[firstIndex]);
                        listOfTwins.Remove(listOfTwins[secondIndex ]);
                    }
                }
                else
                {
                    Console.WriteLine($"Try again!");
                }

                if (listOfTwins.Count == 0 || listOfTwins.Count == 1 )
                {
                    end = true;
                    Console.WriteLine($"You have won in {counter} turns!");
                    break;
                }
          
            }
            if (end == false) {
                    Console.WriteLine($"Sorry you lose :(");
                    Console.WriteLine(string.Join(" ", listOfTwins));
            }
        }
    }        
}            
             
             
             
             
             