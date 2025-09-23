using System;
using System.Security.AccessControl;

namespace Core.Entities;

public class PerformerInGroup : BaseEntity
{
    public required int PerformerId { get; set; }
    public Performer Performer { get; set; } = null!;
    public required int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = null!;
    public required int PieceInConcertId { get; set; }
    public PieceInConcert PieceInConcert { get; set; } = null!;
}
