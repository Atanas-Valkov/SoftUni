using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace P10L3.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<nameRe>[A-Z][a-z]+)%[^|$%.]*<(?<productRe>\w+)>[^|$%.]*\|(?<countRe>\d+)\|[^|$%.]*?(?<PriceRe>\d+.\d+|\d+)\$";
            double income = 0;
            string input;
            while ((input= Console.ReadLine()) != "end of shift")
            {

                foreach (Match match in Regex.Matches(input,pattern))
                {
                    Ordar ordar = new Ordar();

                    ordar.Customer = match.Groups["nameRe"].Value;
                    ordar.Products = match.Groups["productRe"].Value;
                    ordar.Count = double.Parse(match.Groups["countRe"].Value);
                    ordar.Price = double.Parse(match.Groups["PriceRe"].Value);

                    Console.WriteLine($"{ordar.Customer}: {ordar.Products} - {ordar.Total():f2}");
                    income += ordar.Total();
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }

        class Ordar
        {

            
            public  string Customer { get; set; }

            public string Products { get; set; }

            public double Count { get; set; }

            public double Price { get; set; }


            public double Total()
            {
                return Price * Count;
            }
        }
    }
}