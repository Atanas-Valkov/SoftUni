using _00.Demo.Models.Interfaces;

namespace _00.Demo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Document doc = new Document();
           doc.Print();

           PDF pdf = new PDF(); 
           pdf.Print();

           List<IPrintable> printables = new List<IPrintable>();

           printables.Add(new Document());
           printables.Add(new PDF());
           printables.Add(new Document());

           foreach (var item in printables)
           {
               item.Print();
           }

           StartPrinting(new Document());
           StartPrinting(new PDF());
           StartPrinting(new Image());

           Cat cat = new Cat();
         
           cat.SayHello();
           cat.Move();
           
           doc.Print();
           doc.Read();
        }

        public static void StartPrinting(IPrintable printable)
        {
            printable.Print();
        }

        // Силата ма интерфеисите:
        // 1. Полиморфизъм              => възможност за използване на един и същ метод с различни обекти
        // 2. Абстракция                => скриване на детайлите на реализация
        // 3. Множествено наследяване   => клас може да имплементира много интерфейси 
        // 4. Дефиниране на поведение   => чрез интерфейс се дефинира какво трябва да може да прави обекта
        // 5. Лесна поддръжка и разширяемост на кода => промени в един клас не засягат други класове, които използват интерфейса
        // 6. Тестируемост               => улеснява създаването на mock обекти за тестване
        // 7. Слабовръзковост            => намалява зависимостите между компонентите на системата
        // 


    }
}
