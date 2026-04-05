using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string? command = Console.ReadLine();

            if (command != null)
            {
                string result = GetBooksByAgeRestriction(db, command);
                Console.WriteLine(result);
            }


        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            bool isValidCommand = Enum.TryParse<AgeRestriction>(command, true, out AgeRestriction ageRestriction);

            if (isValidCommand)
            {
                var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToList();

                foreach (var book in books)
                {
                    sb.AppendLine(book);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {

        }





    }
}



