using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidation.Player;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key] public int PlayerId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)] 
        public required string Name { get; set; }

        [Required] 
        [MaxLength(MaxSquadNumber)] 
        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }

        public int PositionId { get; set; }

        public int TeamId { get; set; }
        
        public int TownId { get; set; }

    }
}