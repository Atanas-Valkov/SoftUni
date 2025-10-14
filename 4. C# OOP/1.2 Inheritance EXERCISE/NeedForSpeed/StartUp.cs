using System.ComponentModel;
using System.Reflection.Metadata;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           FamilyCar  motorcycle = new FamilyCar(100, 110);
           motorcycle.Drive(10);
           System.Console.WriteLine(motorcycle.Fuel);
        }
    }
}
