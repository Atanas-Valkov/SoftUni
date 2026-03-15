using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static P02_FootballBetting.Common.EntityValidation.Game;
namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

       
        public int HomeTeamId { get; set; }

      
        public int AwayTeamId { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        [Precision(5, 3)]
        public decimal HomeTeamBetRate { get; set; }

        [Precision(5, 3)]
        public decimal AwayTeamBetRate { get; set; }

        [Precision(5, 3)]
        public decimal DrawBetRate { get; set; }


        public DateTime? DateTime { get; set; }

        [MaxLength(MaxResultLength)]
        public string? Result { get; set; }

    }
}