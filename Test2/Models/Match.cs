namespace Test2.Models;
using System.ComponentModel.DataAnnotations;
public class Match
{
    [Key]
    public int MatchId { get; set; }

    [Required]
    public int TournamentId { get; set; }

    public Tournament Tournament { get; set; } = null!;

    [Required]
    public int MapId { get; set; }

    public Map Map { get; set; } = null!;

    [Required]
    public DateTime MatchDate { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public decimal BestRating { get; set; }

    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}