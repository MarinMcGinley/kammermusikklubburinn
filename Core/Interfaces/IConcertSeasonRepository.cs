using System;

namespace Core.Entities;

public interface IConcertSeasonRepository
{
    Task<IReadOnlyList<ConcertSeason>> GetConcertSeasonsAsync();
    Task<ConcertSeason?> GetConcertSeasonByIdAsync(int id);
    void AddConcertSeason(ConcertSeason concertSeason);
    void UpdateConcertSeason(ConcertSeason concertSeason);
    void DeleteConcertSeason(ConcertSeason concertSeason);
    bool ConcertSeasonExists(int id);
    Task<bool> SaveChangesAsync();
}
