
using System;

namespace Core.Entities;

public class GroupInConcert : BaseEntity
{
    public required int GroupId { get; set; }
    public required Group Group { get; set; }
    public required int ConcertId { get; set; }
    public required Concert Concert { get; set; }
}
