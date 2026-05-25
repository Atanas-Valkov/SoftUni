using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace RazorViewsAndLayouts_BookShelf.DbModels
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public required string Title { get; set; } = null!;

        public int Year { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}