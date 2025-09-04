using System;

namespace Core.Entities.SeedEntities;

public class SeedConcert
{
    public string? Description { get; set; }
    public required DateTime Date { get; set; }
    public required ICollection<SeedPiece> Pieces { get; set; }
}
