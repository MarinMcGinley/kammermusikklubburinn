using System;
using System.Security.AccessControl;

namespace Core.Entities;

public class PerformerInGroup : BaseEntity
{
    public required int PerformerId { get; set; }
    public required Performer Performer { get; set; }
    public required int InstrumentId { get; set; }
    public required Instrument Instrument { get; set; }
    public required int PieceInConcertId { get; set; }
    public required PieceInConcert PieceInConcert { get; set; }
}
