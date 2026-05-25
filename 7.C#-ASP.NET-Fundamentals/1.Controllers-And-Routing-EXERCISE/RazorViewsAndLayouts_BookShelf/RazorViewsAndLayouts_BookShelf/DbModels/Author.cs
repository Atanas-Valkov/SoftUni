namespace RazorViewsAndLayouts_BookShelf.DbModels
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation;

    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public required string Name { get; set; } = null!;

        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string? Country { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}