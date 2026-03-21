using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Common;
namespace P01_StudentSystem.Data.Models
{
    using static EntityValidation.Student;

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        [MaxLength(PhoneNumberMaxLength)]
        public string? PhoneNumber  { get; set; } 

        [Required]
        public DateTime RegisteredOn { get; set; }


        public DateTime? Birthday  { get; set; }


        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();


    }
}