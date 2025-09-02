using System;

namespace Core.Entities;

public class PieceInConcert : BaseEntity
{
    public required int PieceId { get; set; }
    public required Piece Piece { get; set; }
    public required int ConcertId { get; set; }
    public required Concert Concert { get; set; }
}
