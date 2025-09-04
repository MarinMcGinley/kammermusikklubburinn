using System;

namespace Core.Entities;

public class Concert : BaseEntity
{
    public string? Description { get; set; }
    public required DateTime Date { get; set; }

    public required int ConcertSeasonId { get; set; }
    public required ConcertSeason ConcertSeason { get; set; }
    public required ICollection<PieceInConcert> PiecesInConcert { get; set; }
}
