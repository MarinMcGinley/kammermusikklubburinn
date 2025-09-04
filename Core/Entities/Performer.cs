using System;

namespace Core.Entities;

public class Performer : BaseEntity
{
    public required string Name { get; set; }
    public required ICollection<PerformerInGroup> PerformerInGroups { get; set; }
}
