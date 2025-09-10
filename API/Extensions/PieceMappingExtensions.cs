using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class PieceMappingExtensions
{
    public static PieceDto ToDto(this Piece piece)
    {
        return new PieceDto
        {
            Id = piece.Id,
            Title = piece.Title,
            Composer = piece.Composer.ToDto()
        };
    }
}
