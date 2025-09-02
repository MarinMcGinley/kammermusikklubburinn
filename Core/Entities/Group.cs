using System;

namespace Core.Entities;

public class Group : BaseEntity
{
    public required string Name { get; set; }
    public required ICollection<PerformerInGroup> PerformersInGroups { get; set; }
    public required ICollection<GroupInConcert> GroupInConcert { get; set; }
}
