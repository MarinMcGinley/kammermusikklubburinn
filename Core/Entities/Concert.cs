using System;
using Core.Interfaces;

namespace Core.Entities;

public class Concert : BaseEntity, IDtoConvertible
{
    public string? Description { get; set; }
    public required DateTime Date { get; set; }

    public required int ConcertSeasonId { get; set; }
    public ConcertSeason ConcertSeason { get; set; } = null!;
    public ICollection<PieceInConcert> PiecesInConcert { get; set; } = [];
}
