namespace P3L08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            bool isParty = false;
            string guest;
            while ((guest = Console.ReadLine()) != "END")
            {
                if (guest == "PARTY")
                {
                    isParty = true;
                }

                if (!isParty)
                {
                    char firstSymbol = guest[0];

                    if (char.IsDigit(firstSymbol))
                    {
                        vip.Add(guest);
                    }
                    else
                    {
                        regular.Add(guest);
                    }
                }
                else
                {
                    if (vip.Contains(guest))
                    {
                        vip.Remove(guest);
                    }
                    else if (regular.Contains(guest))
                    {
                        regular.Remove(guest);
                    }
                }
            }

            Console.WriteLine($"{vip.Count + regular.Count}");

            if (vip.Any())
            {
                foreach (var reservation in vip)
                {
                    Console.WriteLine(reservation);
                }
            }
            if (regular.Any())
            {
                foreach (var reservation in regular)
                {
                    Console.WriteLine(reservation);
                }
            }
        }
    }
}