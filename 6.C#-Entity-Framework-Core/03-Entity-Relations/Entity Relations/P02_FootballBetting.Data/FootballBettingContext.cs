using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;


namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }


        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(
                        "Server=localhost,1433;Database=SoftUni;User Id=sa;Password=SoftUn!2026;TrustServerCertificate=True;Encrypt=False;");
            }

            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new
                {
                    ps.PlayerId,
                    ps.GameId
                });
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}