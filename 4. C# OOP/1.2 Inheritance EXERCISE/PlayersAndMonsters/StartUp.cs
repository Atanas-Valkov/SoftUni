using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Elf", 10);
            MuseElf museElf = new MuseElf("MuseElf", 15);
            Console.WriteLine(elf.ToString());
        }
    }
}