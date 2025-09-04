using System;
using System.Text.Json;
using Core.Entities;
using Core.Entities.SeedEntities;

namespace Infrastructure.Data;

public class ConcertContextSeed
{
    public static async Task SeedAsync(ConcertContext context)
    {
        if (!context.ConcertSeasons.Any())
        {
            var concertSeasonData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/first.json");

            var concertSeasons = JsonSerializer.Deserialize<List<SeedConcertSeason>>(concertSeasonData);

            if (concertSeasons == null) return;
            // TODO finish seeding
            // context.ConcertSeasons.AddRange(concertSeasons);

            // await context.SaveChangesAsync();
        }
    }

}
