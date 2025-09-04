using System;

namespace Core.Entities;

public class Piece : BaseEntity
{
    public required string Title { get; set; }
    public required int ComposerId { get; set; }
    public required Composer Composer { get; set; }
    public required ICollection<PieceInConcert> PieceInConcerts { get; set; }
}
