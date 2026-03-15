using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidation.Country;
namespace P02_FootballBetting.Data.Models
{
    public class Country_
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }
    }
}