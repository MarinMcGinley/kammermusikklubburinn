using System;

namespace Core.Entities.SeedEntities;

public class SeedPerformer
{
    public required string Name { get; set; }
    public required SeedInstrument Instrument { get; set; }
}
