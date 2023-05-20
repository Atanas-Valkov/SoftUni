using System;
using System.IO.Pipes;
using System.Xml.Serialization;

namespace P01E01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string person = "";


            if (age<=2)
            {
                person = "baby"; 
            }
            else if (age<=13)
            {
                person = "child";
            }
            else if (age <= 19)
            {
                person = "teenager";
            }
            else if (age <= 65)
            {
                person = "adult";
            }
            else if (age>= 66)
            {
                person = "elder";
            }
            Console.WriteLine(person);
        }
    }
}
