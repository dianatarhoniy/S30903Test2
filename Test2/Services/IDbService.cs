using Test2.DTOs;

namespace Test2.Services;

public interface IDbService
{
    Task<PlayerMatchesDto> GetPlayerMatchesAsync(int playerId);
    Task AddPlayerWithMatchesAsync(PlayerRequestDto dto);
}