using System;

namespace API.DTOs;

public class PieceDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required ComposerDto Composer { get; set; }

}
