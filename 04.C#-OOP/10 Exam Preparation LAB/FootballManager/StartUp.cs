using FootballManager.Core;
using FootballManager.Core.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager
{
    public class StartUp
    {
        static void Main(string[] args)
        {

          Console.SetIn(new StreamReader("input.txt"));

            var sw = new StreamWriter("output.txt")
            {
                AutoFlush = true
            };
            
            Console.SetOut(sw);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
