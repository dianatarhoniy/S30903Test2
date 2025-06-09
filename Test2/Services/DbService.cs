using Microsoft.EntityFrameworkCore;
using Test2.Context;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _context;

    public DbService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerMatchesDto> GetPlayerMatchesAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Tournament)
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Map)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        if (player == null)
            throw new ArgumentException("Player is not found");

        return new PlayerMatchesDto
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatches.Select(pm => new MatchDto
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map.Name,
                Date = pm.Match.MatchDate,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score,
                Team2Score = pm.Match.Team2Score
            }).ToList()
        };
    }

    public async Task AddPlayerWithMatchesAsync(PlayerRequestDto dto)
    {
        var player = new Player
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate
        };

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        foreach (var match in dto.Participations)
        {
            var existingMatch = await _context.Matches.FindAsync(match.MatchId);
            if (existingMatch == null)
                throw new ArgumentException($"Match with ID {match.MatchId} not found");

            var existingParticipation = await _context.PlayerMatches
                .FirstOrDefaultAsync(pm => pm.PlayerId == player.PlayerId && pm.MatchId == match.MatchId);

            if (existingParticipation != null)
            {
                if (match.Rating > existingParticipation.Rating)
                    existingParticipation.Rating = match.Rating;
                continue;
            }

            _context.PlayerMatches.Add(new PlayerMatch
            {
                PlayerId = player.PlayerId,
                MatchId = match.MatchId,
                MVPs = match.MVPs,
                Rating = match.Rating
            });
        }

        await _context.SaveChangesAsync();
    }
}