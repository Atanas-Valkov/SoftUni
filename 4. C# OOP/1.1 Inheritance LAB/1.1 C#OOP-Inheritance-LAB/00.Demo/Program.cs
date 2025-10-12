using _00.Demo.Animals;

namespace _00.Demo.Person
{
    public class Program
    {
        public static void Main(string[] args)
        {
          Cat cat = new Cat("Pesho", 12);
          cat.Eat();
          cat.Meow();
          Dog dog = new Dog("Gosho",13);
          dog.Bark();
          dog.Eat();
          dog.Aga = 10;
          Console.WriteLine($"{cat.Name} {dog.Aga}");
         
          Person person1 = new Person("Gosh", "Plovdiv");
          person1.Address = "Sofia";
          Console.WriteLine(person1.Address);
          person1.Address = "Varna";
          Console.WriteLine(person1.Address);
         
          // Това се кзава Полиморфизъм. //
          // Въпреки, че имам е Лист от Animal, мога да добавя обекти от тип Cat и Dog,
          // защото те са наследници на Animal.
          List<Animal> animals = new List<Animal>()
          { 
              new Cat("Sharo", 1), //-> animals.add(new Cat("Sharo", 1));
              new Dog("Simon", 13)//->  animals.add(new Dog("Simon", 13));
          };
            // нов синтаксис за създаване на обекти // стар синтаксис


            // Метод, който приема параметър от тип Animal
            // Можем да подадем както обект от тип Cat, така и обект от тип Dog
            // защото и двата класа са наследници на Animal
            static void PrintAnimalName(Animal animal)
            {
                Console.WriteLine(animal.Name);
            }

            PrintAnimalName(new Dog("Puh", 1));
            PrintAnimalName(new Cat("Misho", 2));


        }
    }
}
