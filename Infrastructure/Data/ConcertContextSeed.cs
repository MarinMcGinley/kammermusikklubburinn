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

    public async Task SeedPerformersAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding performers...");

        try
        {
            if (!context.Performers.Any())
            {
                var performersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/performers.json");
                var performers = JsonSerializer.Deserialize<List<string>>(performersData);

                if (performers == null) return;

                foreach (string performer in performers)
                {
                    var newPerformer = new Performer { Name = performer };
                    context.Performers.Add(newPerformer);
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Performers seeded...");


            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding performers failed");
        }
    }

    public async Task SeedComposersAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding composers...");

        try
        {
            if (!context.Performers.Any())
            {
                var composersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/composers.json");
                var composers = JsonSerializer.Deserialize<List<string>>(composersData);

                if (composers == null) return;

                foreach (string composer in composers)
                {
                    var parts = composer.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var firstName = string.Join(" ", parts.Take(parts.Length - 1));
                    var lastName = parts.Last();

                    var newComposer = new Composer { FirstName = firstName, LastName = lastName, Name = composer };
                    context.Composers.Add(newComposer);
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Composers seeded...");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding composers failed");
        }
    }

    public async Task SeedPiecesAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding pieces...");

        try
        {
            if (!context.Performers.Any())
            {
                var piecesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/composer_pieces.json");
                var pieces = JsonSerializer.Deserialize<List<SeedComposerWithPieces>>(piecesData);

                if (pieces == null) return;

                foreach (SeedComposerWithPieces composer in pieces)
                {
                    var foundComposer = context.Composers.First(c => c.Name == composer.Composer);
                    if (foundComposer == null)
                    {
                        var parts = composer.Composer.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        var firstName = string.Join(" ", parts.Take(parts.Length - 1));
                        var lastName = parts.Last();

                        foundComposer = new Composer { FirstName = firstName, LastName = lastName, Name = composer.Composer };
                        context.Composers.Add(foundComposer);

                        await context.SaveChangesAsync();

                        _logger.LogInformation("Saving composer to context: {Composer}", composer.Composer);
                    }

                    foreach (string piece in composer.Pieces)
                    {
                        var newPiece = new Piece { ComposerId = foundComposer.Id, Title = piece };
                        context.Pieces.Add(newPiece);
                    }
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Pieces seeded...");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding pieces failed");
        }
    }

    public async Task SeedInstrumentsAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding instruments...");

        try
        {
            if (!context.Performers.Any())
            {
                var instrumentsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/instruments.json");
                var instruments = JsonSerializer.Deserialize<List<string>>(instrumentsData);

                if (instruments == null) return;

                foreach (string instrument in instruments)
                {
                    var newInstrument = new Instrument { Name = instrument };
                    context.Instruments.Add(newInstrument);
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Instruments seeded...");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding instruments failed");
        }
    }

    public async Task SeedConcertSeasons(ConcertContext context, string jsonFile)
    {
        try
        {
            var concertSeasonData = await File.ReadAllTextAsync(jsonFile);

            var concertSeasons = JsonSerializer.Deserialize<List<SeedConcertSeason>>(concertSeasonData);

            if (concertSeasons == null) return;

            foreach (SeedConcertSeason concertSeason in concertSeasons)
            {
                _logger.LogInformation("Seeding concerts");
                var newConcertSeason = new ConcertSeason { Title = concertSeason.Title, BeginDate = concertSeason.BeginDate, EndDate = concertSeason.EndDate    };
                context.ConcertSeasons.Add(newConcertSeason);

                foreach (SeedConcert concert in concertSeason.Concerts)
                {
                    _logger.LogInformation("Seeding concerts...");
                    var newConcert = new Concert { Description = concert.Description, Date = concert.Date, ConcertSeasonId = newConcertSeason.Id };
                    newConcertSeason.Concerts.Add(newConcert);

                    foreach (SeedPiece piece in concert.Pieces)
                    {
                        Composer? newComposer = context.Composers.FirstOrDefault(x => x.Name == piece.Composer.Name);

                        var parts = piece.Composer.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        var firstName = string.Join(" ", parts.Take(parts.Length - 1));
                        var lastName = parts.Last();

                        newComposer ??= new Composer { Name = piece.Composer.Name, FirstName = firstName, LastName = lastName };

                        if (newComposer.Id == 0) // not tracked yet
                        {
                            context.Composers.Add(newComposer);
                            await context.SaveChangesAsync();
                            _logger.LogInformation("Composer saved to context: {Name}", newComposer.Name);
                        }

                        Piece? newPiece = context.Pieces.FirstOrDefault(x => x.ComposerId == newComposer.Id && x.Title == piece.Title);
                        newPiece ??= new Piece { Title = piece.Title, ComposerId = newComposer.Id };

                        if (newPiece.Id == 0) // not tracked yet
                        {
                            context.Pieces.Add(newPiece);
                            await context.SaveChangesAsync();
                            _logger.LogInformation("Piece saved to context: {Title}", newPiece.Title);
                        }

                        var newPieceInConcert = new PieceInConcert
                        {
                            ConcertId = newConcert.Id,
                            GroupName = piece.GroupName,
                            PieceId = newPiece.Id,
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
                                _logger.LogInformation("Instrument saved to context: {Name}", newInstrument.Name);
                            }

                            Performer? newPerformer = context.Performers
                                .FirstOrDefault(p => p.Name == performer.Name);
                            newPerformer ??= new Performer { Name = performer.Name };

                            if (newPerformer.Id == 0) // not tracked yet
                            {
                                context.Performers.Add(newPerformer);
                                await context.SaveChangesAsync();
                                _logger.LogInformation("Performer saved to context: {Name}", newPerformer.Name);
                            }

                            var performerInGroup = new PerformerInGroup
                            {
                                PerformerId = newPerformer.Id,
                                InstrumentId = newInstrument.Id,
                                PieceInConcertId = newPieceInConcert.Id
                            };

                            newPieceInConcert.PerformersInGroup.Add(performerInGroup);
                        }
                    }
                }
            }
            await context.SaveChangesAsync();
            _logger.LogInformation("Changes saved");

        }

        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding concert seasons failed");
        }
    }

    public async Task SeedAsync(ConcertContext context)
    {
        _logger.LogInformation("Seeding concert seasons...");

        try
        {
            if (!context.ConcertSeasons.Any())

            {
                await SeedPerformersAsync(context);
                await SeedComposersAsync(context);
                await SeedPiecesAsync(context);
                await SeedInstrumentsAsync(context);

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_0_to_10.json");
                _logger.LogInformation("Concert seasons 0 to 10 saved");
    
                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_11_to_20.json");
                _logger.LogInformation("Concert seasons 11 to 20 saved");

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_21_to_29.json");
                _logger.LogInformation("Concert seasons 21 to 29 saved");

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_30_to_39.json");
                _logger.LogInformation("Concert seasons 30 to 39 saved");

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_40_to_49.json");
                _logger.LogInformation("Concert seasons 40 to 49 saved");

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_50_to_59.json");
                _logger.LogInformation("Concert seasons 50 to 59 saved");

                await SeedConcertSeasons(context, "../Infrastructure/Data/SeedData/concert_seasons_60_to_68.json");
                _logger.LogInformation("Concert seasons 60 to 68 saved");

            }
        }
        catch (Exception e)
        {
            _logger.LogError(0, e, "Seeding failed");
        }
    }
}
