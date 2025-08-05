using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ConcertSeasonRepository(ConcertContext context) : IConcertSeasonRepository
{


    public void AddConcertSeason(ConcertSeason concertSeason)
    {
        context.ConcertSeasons.Add(concertSeason);
    }

    public bool ConcertSeasonExists(int id)
    {
        return context.ConcertSeasons.Any(x => x.Id == id);
    }

    public void DeleteConcertSeason(ConcertSeason concertSeason)
    {
        context.ConcertSeasons.Remove(concertSeason);
    }

    public async Task<ConcertSeason?> GetConcertSeasonByIdAsync(int id)
    {
        return await context.ConcertSeasons.FindAsync(id);
    }

    public async Task<IReadOnlyList<ConcertSeason>> GetConcertSeasonsAsync()
    {
        return await context.ConcertSeasons.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateConcertSeason(ConcertSeason concertSeason)
    {
        context.Entry(concertSeason).State = EntityState.Modified;
    }
}
