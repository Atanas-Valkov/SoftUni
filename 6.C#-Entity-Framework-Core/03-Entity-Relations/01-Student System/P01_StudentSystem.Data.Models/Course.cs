using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Common;

namespace P01_StudentSystem.Data.Models
{

    using static EntityValidation.Course;
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

       
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Precision(12,4)]
        public decimal  Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();

        public virtual ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}