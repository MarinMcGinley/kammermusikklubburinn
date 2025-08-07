using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class ConcertContextSeed
{
    public static async Task SeedAsync(ConcertContext context)
    {
        if (!context.ConcertSeasons.Any())
        {
            var concertSeasonData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/concert_seasons.json");

            var concertSeasons = JsonSerializer.Deserialize<List<ConcertSeason>>(concertSeasonData);

            if (concertSeasons == null) return;

            context.ConcertSeasons.AddRange(concertSeasons);

            await context.SaveChangesAsync();
        }
    }

}
