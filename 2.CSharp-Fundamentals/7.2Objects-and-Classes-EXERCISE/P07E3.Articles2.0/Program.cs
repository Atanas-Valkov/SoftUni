using static P07E3.Articles2._0.Program;

namespace P07E3.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
                

            for (int i = 0; i < number; i++)
            {
               string[] commands = Console.ReadLine().Split(", ");

                Article article = new Article(commands[0], commands[1], commands[2]);

                articles.Add(article);
                
                // if (firstIndex == "Edit")
                // {
                //     article.Edit(secondIndex);
                // }
                // else if (firstIndex == "ChangeAuthor")
                // {
                //     article.ChangeAuthor(secondIndex);
                // }
                // else if (firstIndex == "Rename")
                // {
                //
                //     article.Rename(secondIndex);
                // }
            }
            foreach (Article article in articles)
            {
                article.ToString(article.Title, article.Content, article.Author);
            }
                     
                
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
        
       //  public void Edit(string content)
       //  {
       //      Content = content;
       //  }
       // 
       //  public void ChangeAuthor(string author)
       //  {
       //      Author = author;
       //  }
       //  public void Rename(string title)
       //  {
       //      Title = title;
       //  }
      
          public void ToString(string title, string content, string author)
          {
              Console.WriteLine($"{title} - {content}: {author}");

          }
      }
    } 
}