using System;
using System.Linq.Expressions;
using System.Text.Json;
using Core.Entities;
using Core.Entities.SeedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class ConcertContextSeed
{

    private readonly ILogger<ConcertContextSeed> _logger;

    public ConcertContextSeed(ILogger<ConcertContextSeed> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding concert seasons...");

        try
        {
            if (!context.ConcertSeasons.Any())
            {
                var concertSeasonData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/first.json");

                var concertSeasons = JsonSerializer.Deserialize<List<SeedConcertSeason>>(concertSeasonData);

                if (concertSeasons == null) return;

                foreach (SeedConcertSeason concertSeason in concertSeasons)
                {
                    var newConcertSeason = new ConcertSeason { Title = concertSeason.Title };
                    context.ConcertSeasons.Add(newConcertSeason);

                    foreach (SeedConcert concert in concertSeason.Concerts)
                    {
                        var newConcert = new Concert { Description = concert.Description, Date = concert.Date, ConcertSeason = newConcertSeason };

                        foreach (SeedPiece piece in concert.Pieces)
                        {

                            var alreadyExistingPiece = context.Pieces
                                .Include(p => p.Composer)
                                .FirstOrDefault(p => p.Title == piece.Title && p.Composer.Name == piece.Composer.Name);

                            if (alreadyExistingPiece == null)
                            {
                                Piece? newPiece;
                                var alreadyExistingComposer = context.Composers.FirstOrDefault(c => c.Name == piece.Composer.Name);

                                if (alreadyExistingComposer == null)
                                {
                                    var newComposer = new Composer { Name = piece.Composer.Name };
                                    context.Composers.Add(newComposer);

                                    newPiece = new Piece { Title = piece.Title, Composer = newComposer };
                                }
                                else
                                {
                                    newPiece = new Piece { Title = piece.Title, Composer = alreadyExistingComposer };
                                }

                                var newPieceInConcert = new PieceInConcert
                                {
                                    Concert = newConcert,
                                    GroupName = piece.GroupName,
                                    Piece = newPiece,
                                };

                                foreach (SeedPerformer performer in piece.Performers)
                                {
                                    Instrument? newInstrument = context.Instruments
                                        .FirstOrDefault(i => i.Name == performer.Instrument.Name);

                                    newInstrument ??= new Instrument { Name = performer.Instrument.Name };

                                    Performer? newPerformer = context.Performers
                                        .FirstOrDefault(p => p.Name == performer.Name);

                                    newPerformer ??= new Performer { Name = performer.Name };

                                    var performerInGroup = new PerformerInGroup
                                    {
                                        Performer = newPerformer,
                                        Instrument = newInstrument,
                                        PieceInConcert = newPieceInConcert
                                    };
                                }
                            }

                        }
                    }
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Seeding completed");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding failed");
        }
    }

}
