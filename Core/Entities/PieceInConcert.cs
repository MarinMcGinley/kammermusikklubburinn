using System;

namespace Core.Entities;

public class PieceInConcert : BaseEntity
{
    public int PieceId { get; set; }
    public required Piece Piece { get; set; } = null!;
    public int ConcertId { get; set; }
    public required Concert Concert { get; set; } = null!;
    public required string GroupName { get; set; }
    public ICollection<PerformerInGroup> PerformersInGroup { get; set; } = [];
}
