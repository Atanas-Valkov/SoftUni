using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static P02_FootballBetting.Common.EntityValidation.Game;
namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; } = null!;

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        [Precision(5, 3)]
        public decimal HomeTeamBetRate { get; set; }

        [Precision(5, 3)]
        public decimal AwayTeamBetRate { get; set; }

        [Precision(5, 3)]
        public decimal DrawBetRate { get; set; }


        public DateTime DateTime { get; set; }

        [MaxLength(MaxResultLength)]
        public string? Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new HashSet<PlayerStatistic>();

        public virtual ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();

    }
}