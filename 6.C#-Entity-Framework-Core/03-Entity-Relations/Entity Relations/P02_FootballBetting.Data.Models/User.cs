using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static P02_FootballBetting.Common.EntityValidation.User;
namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public required string Email { get; set; }

        [Precision(12,4)]
        public decimal Balance { get; set; }

    }
}