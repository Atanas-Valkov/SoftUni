using System;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
namespace P07E2.Articles;
internal class Program
{
    static void Main(string[] args)
    {
        List<string> articles = Console.ReadLine().Split(", ").ToList();
        int number = int.Parse(Console.ReadLine());
        Article article = new Article(articles[2], articles[1], articles[0]);

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().Split(": ");
            string command = input[0];
            string change = input[1];

            if (command == "Edit")
            {
                article.Edit(change);
            }
            else if(command == "ChangeAuthor")
            {
                article.ChangeAuthor(change);
            }
            else if (command == "Rename")
            {
                article.Rename(change);
            }
        }
        Console.WriteLine(article.ToString());
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
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
