using System;
using Core.Interfaces;

namespace Core.Entities;

public class Piece : BaseEntity, IDtoConvertible
{
    public required string Title { get; set; }
    public required int ComposerId { get; set; }
    public Composer Composer { get; set; } = null!;
    public ICollection<PieceInConcert> PieceInConcerts { get; set; } = [];
}
