using System;
using Core.Interfaces;

namespace Core.Entities;

public class Composer : BaseEntity, IDtoConvertible
{
    public required string Name { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public ICollection<Piece> Pieces { get; set; } = [];
}
