using System;

namespace Core.Entities;

public class PerformerInGroup : BaseEntity
{
    public required int PerformerId { get; set; }
    public required Performer Performer { get; set; }
    public required int GroupId { get; set; }
    public required Group Group { get; set; }
    public required int InstrumentId { get; set; }
    public required Instrument Instrument { get; set; }

}
