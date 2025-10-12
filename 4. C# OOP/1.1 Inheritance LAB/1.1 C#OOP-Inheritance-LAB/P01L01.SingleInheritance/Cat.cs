namespace Farm;

public class Cat : Animal
{
    public Cat(string name) 
        : base(name)        
    {                       
        
    }

    public void Meow() => Console.WriteLine("meowing...");
    
}