namespace _00.Demo.Animals;

public class Animal
{
    protected Animal(string name, int aga)
    {
        if (name.Length < 2)
        {
            throw new ArgumentException("Invalid name");
        }

        this.Name = name;
    }
    
    public string Name { get; private set; } // Достъпно навсякъде, но сетването само в рамките на класа
    public int Aga { get; set; } // Достъпно в рамките на класа и в наследниците му 
    private string Colar { get; set; } // Достъпно само в рамките на класа но се Вижда

    internal class MyClass// Достъпно в рамките на същата сборка (assembly)т.е. същия проект/ DLL
    {

    }

    public void Eat()
    {
        Console.WriteLine("eating...");
    }
}