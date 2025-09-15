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
                        newConcertSeason.Concerts.Add(newConcert);

                        foreach (SeedPiece piece in concert.Pieces)
                        {
                            Composer? newComposer = context.Composers.FirstOrDefault(x => x.Name == piece.Composer.Name);
                            newComposer ??= new Composer { Name = piece.Composer.Name };

                            if (newComposer.Id == 0) // not tracked yet
                            {
                                context.Composers.Add(newComposer);
                                await context.SaveChangesAsync();
                            }

                            Piece? newPiece = context.Pieces.FirstOrDefault(x => x.ComposerId == newComposer.Id && x.Title == piece.Title);
                            newPiece ??= new Piece { Title = piece.Title, Composer = newComposer };

                            if (newPiece.Id == 0) // not tracked yet
                            {
                                context.Pieces.Add(newPiece);
                            }

                            var newPieceInConcert = new PieceInConcert
                            {
                                Concert = newConcert,
                                GroupName = piece.GroupName,
                                Piece = newPiece,
                            };
                            newConcert.PiecesInConcert.Add(newPieceInConcert);

                            foreach (SeedPerformer performer in piece.Performers)
                            {
                                Instrument? newInstrument = context.Instruments
                                    .FirstOrDefault(i => i.Name == performer.Instrument.Name);
                                newInstrument ??= new Instrument { Name = performer.Instrument.Name };

                                if (newInstrument.Id == 0) // not tracked yet
                                {
                                    context.Instruments.Add(newInstrument);
                                    await context.SaveChangesAsync();
                                }

                                Performer? newPerformer = context.Performers
                                    .FirstOrDefault(p => p.Name == performer.Name);
                                newPerformer ??= new Performer { Name = performer.Name };

                                if (newPerformer.Id == 0) // not tracked yet
                                {
                                    context.Performers.Add(newPerformer);
                                    await context.SaveChangesAsync();
                                }

                                var performerInGroup = new PerformerInGroup
                                {
                                    Performer = newPerformer,
                                    Instrument = newInstrument,
                                    PieceInConcert = newPieceInConcert
                                };

                                newPieceInConcert.PerformersInGroup.Add(performerInGroup);
                            }
                        }
                    }
                    await context.SaveChangesAsync();
                    _logger.LogInformation("Changes saved");
                }
                _logger.LogInformation("Seeding completed");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding failed");
        }
    }

}
