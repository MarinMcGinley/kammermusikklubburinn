using System;

namespace Core.Entities;

public class Composer : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Piece> Pieces { get; set; } = [];
}
