using System;

namespace Core.Entities.SeedEntities;

public class SeedComposerWithPieces
{
    public required string Composer { get; set; }

    public required List<string> Pieces { get; set; }
}
