namespace Test2.DTOs;

public class MatchDto
{
    public string Tournament { get; set; } = null!;
    public string Map { get; set; } = null!;
    public DateTime Date { get; set; }

    public int MVPs { get; set; }
    public decimal Rating { get; set; }

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}