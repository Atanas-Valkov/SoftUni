namespace P08L2.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> kvp = new Dictionary<string, int>();


            foreach (string s in input)
            {
                string sToLower = s.ToLower();

                if (!kvp.ContainsKey(sToLower))
                {
                    kvp[sToLower] = 1;

                }
                else
                {
                    kvp[sToLower]++;
                }

            }

            foreach (var asd in kvp)
            {
                
                if (asd.Value % 2 == 0)
                {
                    continue;
                }
                else
                {
                    Console.Write(asd.Key + " ");
                }

                
            }  
        }
    }
}