/*
SoftUni Article
Some content of the SoftUni article
some comment
more comment 
last comment
end of comments
 */

using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace P09ME5.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titleArticle = Console.ReadLine();
            string content = Console.ReadLine();
            List<string> list = new List<string>();

            string comments = string.Empty;
            while ((comments = Console.ReadLine()) != "end of comments")
            {
                list.Add(comments);
            }

            Console.WriteLine($"<h1>\n    {titleArticle}\n</h1>");
            Console.WriteLine($"<article>\n    {content}\n</article>");

            foreach (var asd in list)
            {
                Console.WriteLine($"<div>\n    {asd}\n</div>");
            }
        }
    }
}