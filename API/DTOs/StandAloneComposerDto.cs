using System;

namespace API.DTOs;

public class StandAloneComposerDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required List<ComposerPieceDto> Pieces { get; set; }
}
