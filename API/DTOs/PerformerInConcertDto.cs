using System;

namespace API.DTOs;

public class PerformerInConcertDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Instrument { get; set; }
}
