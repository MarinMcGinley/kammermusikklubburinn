using System;

namespace Core.Entities;

public class Piece : BaseEntity
{
    public required string Title { get; set; }
    public int ComposerId { get; set; }
    public required Composer Composer { get; set; } = null!;
    public ICollection<PieceInConcert> PieceInConcerts { get; set; } = [];
}
