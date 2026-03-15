using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using static Common.EntityValidation.Team;

    public class Team
    {
        [Key] public int TeamId { get; set; }

        [Required] 
        [MaxLength(NameMaxLength)] 
        public required string Name { get; set; }
        
        [Required] 
        [MaxLength(LogoUrlLength)] 
        public required string LogoUrl { get; set; }

        [Required] 
        [MaxLength(InitialsLength)] 
        public required string Initials { get; set; }

        [Required]
        [Precision(13, 5)] 
        public  decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }

        public virtual Color PrimaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        
        public virtual Color SecondaryKitColor { get; set; } = null!;

        public int TownId { get; set; }
    }


}

   