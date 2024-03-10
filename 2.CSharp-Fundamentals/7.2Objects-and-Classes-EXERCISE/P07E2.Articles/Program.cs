using System;
using System.Linq;
using System.Reflection.Metadata;

namespace P07E2.Articles;

internal class Program
{
    static void Main(string[] args)
    {

        List<string> strings = Console.ReadLine()
            .Split(", ")
            .ToList();

        Article article = new Article(strings[0], strings[1], strings[2]);

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);


            string firstIndex = commands[0];
            string secondIndex = commands[1];

            if (firstIndex == "Edit")
            {
                article.Edit(secondIndex);
            }
            else if (firstIndex == "ChangeAuthor")
            {
                article.ChangeAuthor(secondIndex);
            }
            else if (firstIndex == "Rename")
            {

                article.Rename(secondIndex);
            }
        }

        article.ToString(article.Title, article.Content, article.Author);
    }


    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }

        public void ToString(string title, string content, string author)
        {
            Console.WriteLine($"{title} - {content}: {author}");

        }
    }
}
