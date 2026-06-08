using System;
using Core.Interfaces;

namespace Core.Entities;

public class ConcertSeason : BaseEntity, IDtoConvertible
{
    public required string Title { get; set; }
    public required DateTime BeginDate { get; set; }
    public required DateTime EndDate { get; set; }
    public ICollection<Concert> Concerts { get; set; } = [];
}
