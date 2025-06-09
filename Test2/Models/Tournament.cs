namespace Test2.Models;
using System.ComponentModel.DataAnnotations;

public class Tournament
{
    [Key]
    public int TournamentId { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}