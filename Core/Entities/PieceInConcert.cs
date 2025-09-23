using System;

namespace Core.Entities;

public class PieceInConcert : BaseEntity
{
    public required int PieceId { get; set; }
    public Piece Piece { get; set; } = null!;
    public required int ConcertId { get; set; }
    public Concert Concert { get; set; } = null!;
    public required string GroupName { get; set; }
    public ICollection<PerformerInGroup> PerformersInGroup { get; set; } = [];
}
