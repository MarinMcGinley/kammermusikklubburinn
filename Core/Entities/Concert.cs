using System;

namespace Core.Entities;

public class Concert : BaseEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required DateTime Date { get; set; }

    public required int ConcertSeasonId { get; set; }
    public required ConcertSeason ConcertSeason { get; set; }
    public required ICollection<PieceInConcert> PieceInConcert { get; set; }
    public required ICollection<GroupInConcert> GroupInConcert { get; set; }

}
