using System;

namespace API.DTOs;

public class PieceInConcertDto
{
    public required PieceDto Piece { get; set; }
    public required string GroupName { get; set; }
    public required List<PerformerInConcertDto> Performers { get; set; }
}
