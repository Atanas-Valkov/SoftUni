
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using static EntityValidation.Color;

public class Color
{
    [Key] public int ColorId { get; set; }

    [Required]
    [MaxLength(ColorMaxLength)] 
    public string Name { get; set; } = null!;

    [InverseProperty(nameof(Team.PrimaryKitColor))]
    public virtual ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

    [InverseProperty(nameof(Team.SecondaryKitColor))]
    public virtual ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
}