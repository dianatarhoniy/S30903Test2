namespace Test2.Context;

using Microsoft.EntityFrameworkCore;
using Test2.Models;


public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Map>().HasData(
            new Map { MapId = 1, Name = "Inferno" },
            new Map { MapId = 2, Name = "Mirage" }
        );

        modelBuilder.Entity<Tournament>().HasData(
            new Tournament { TournamentId = 1, Name = "CS2 Summer Cup" }
        );

        modelBuilder.Entity<Match>().HasData(
            new Match
            {
                MatchId = 1,
                MapId = 1,
                TournamentId = 1,
                MatchDate = new DateTime(2025, 7, 2, 15, 0, 0),
                Team1Score = 16,
                Team2Score = 12
            },
            new Match
            {
                MatchId = 2,
                MapId = 2,
                TournamentId = 1,
                MatchDate = new DateTime(2025, 7, 3, 18, 0, 0),
                Team1Score = 10,
                Team2Score = 16
            }
        );

        modelBuilder.Entity<Player>().HasData(
            new Player
            {
                PlayerId = 1,
                FirstName = "Alex",
                LastName = "Smith",
                BirthDate = new DateTime(2000, 5, 20)
            }
        );

        modelBuilder.Entity<PlayerMatch>().HasData(
            new PlayerMatch
            {
                PlayerId = 1,
                MatchId = 1,
                Rating = 1.25m,
                MVPs = 3
            },
            new PlayerMatch
            {
                PlayerId = 1,
                MatchId = 2,
                Rating = 1.10m,
                MVPs = 2
            }
        );
    }
}