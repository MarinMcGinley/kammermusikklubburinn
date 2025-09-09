using System;
using Core.Interfaces;

namespace Core.Entities;

public class Concert : BaseEntity, IDtoConvertible
{
    public string? Description { get; set; }
    public required DateTime Date { get; set; }

    public int ConcertSeasonId { get; set; }
    public required ConcertSeason ConcertSeason { get; set; }
    public ICollection<PieceInConcert> PiecesInConcert { get; set; } = [];
}
