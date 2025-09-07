using System;
using Core.Interfaces;

namespace Core.Entities;

public class ConcertSeason : BaseEntity, IDtoConvertible
{
    public required string Title { get; set; }
    public ICollection<Concert> Concerts { get; set; } = [];
}
