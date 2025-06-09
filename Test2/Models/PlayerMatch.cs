namespace Test2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerMatch
{
    [Required]
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    [Required]
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;

    public int MVPs { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public decimal Rating { get; set; }
}