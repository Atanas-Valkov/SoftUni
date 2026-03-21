using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_StudentSystem.Common.EntityValidation.Resource;
namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength()]
        public string Name { get; set; } = null!;


        [Required]
        [Unicode(false)]
        [MaxLength(UrlMaxLength)]
        public string Url { get; set; } = null!;

        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;



    }
}