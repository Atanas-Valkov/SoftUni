using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidation.Position;
namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }
    }
}