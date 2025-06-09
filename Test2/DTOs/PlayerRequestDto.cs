namespace Test2.DTOs;

public class PlayerRequestDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public List<ParticipationDto> Participations { get; set; } = new();
}