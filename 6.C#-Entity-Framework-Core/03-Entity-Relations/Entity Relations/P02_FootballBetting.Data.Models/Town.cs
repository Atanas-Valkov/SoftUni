using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidation.Town;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId  { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        public int CountryId { get; set; }
    }
}