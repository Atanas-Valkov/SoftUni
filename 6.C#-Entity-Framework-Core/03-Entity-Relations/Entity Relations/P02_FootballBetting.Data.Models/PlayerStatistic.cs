using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [Key]
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }

    }
}