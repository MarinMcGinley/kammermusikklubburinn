using System;

namespace API.DTOs;

public class PerformerDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Instrument { get; set; }
}
