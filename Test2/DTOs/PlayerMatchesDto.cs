namespace Test2.DTOs;

public class PlayerMatchesDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public List<MatchDto> Matches { get; set; } = new();
}