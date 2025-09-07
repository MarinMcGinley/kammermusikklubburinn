using System;

namespace Core.Entities;

public class ConcertSeason : BaseEntity
{
    public required string Title { get; set; }
    public ICollection<Concert> Concerts { get; set; } = [];
}
