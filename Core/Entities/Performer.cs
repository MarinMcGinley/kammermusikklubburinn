using System;
using Core.Interfaces;

namespace Core.Entities;

public class Performer : BaseEntity, IDtoConvertible
{
    public required string Name { get; set; }
    public ICollection<PerformerInGroup> PerformerInGroups { get; set; } = [];
}
