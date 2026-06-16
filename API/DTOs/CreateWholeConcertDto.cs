using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateWholeConcertDto
{
    public string? Description { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int ConcertSeasonId { get; set; }

    public required List<CreatePiece> Pieces { get; set; }
}

public class CreatePiece
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string GroupName { get; set; }
    public required List<CreatePerformer> Performers { get; set; }
}

public class CreatePerformer
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int InstrumentId { get; set; }

}
