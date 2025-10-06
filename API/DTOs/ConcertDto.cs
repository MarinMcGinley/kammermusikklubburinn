using System;

namespace API.DTOs;

public class ConcertDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public int ConcertSeasonId { get; set; }
    public required List<PieceInConcertDto> PiecesInConcert { get; set; }
}
