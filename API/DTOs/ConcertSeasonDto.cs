using System;

namespace API.DTOs;

public class ConcertSeasonDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTime BeginDate { get; set; }
    public required DateTime EndDate { get; set; }

}
