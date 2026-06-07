using System;

namespace Core.Entities.SeedEntities;

public class SeedConcertSeason
{
    public required string Title { get; set; }
    public required DateTime BeginDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required ICollection<SeedConcert> Concerts { get; set; }
}
