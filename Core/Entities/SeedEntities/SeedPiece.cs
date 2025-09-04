using System;

namespace Core.Entities.SeedEntities;

public class SeedPiece
{
    public required string Title { get; set; }
    public required SeedComposer Composer { get; set; }
    public required string GroupName { get; set; }
    public required ICollection<SeedPerformer> Performers { get; set; }
}
