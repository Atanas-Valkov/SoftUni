namespace _00.Demo.Animals;

public class Dog : Animal
{
    public Dog(string name, int aga)
        : base(name, aga)
    {
    }


    public void Bark()
    {
        Console.WriteLine("barking...");
    }
   
}