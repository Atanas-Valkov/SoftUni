using static P07E3.Articles2._0.Program;

namespace P07E3.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string author = input[2];
                Article article = new Article(author, content, title);
                articles.Add(article);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        public class Article
        {
            public Article(string author, string content, string title)
            {
                Title = title;
                Content = content;
                Author = author;
            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}