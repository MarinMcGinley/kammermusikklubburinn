using System;
using System.Security.AccessControl;

namespace Core.Entities;

public class PerformerInGroup : BaseEntity
{
    public int PerformerId { get; set; }
    public required Performer Performer { get; set; } = null!;
    public int InstrumentId { get; set; }
    public required Instrument Instrument { get; set; } = null!;
    public int PieceInConcertId { get; set; }
    public required PieceInConcert PieceInConcert { get; set; } = null!;
}
