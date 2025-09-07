using System;

namespace Core.Entities;

public class Instrument : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<PerformerInGroup> PerformersInGroups { get; set; } = [];
}
