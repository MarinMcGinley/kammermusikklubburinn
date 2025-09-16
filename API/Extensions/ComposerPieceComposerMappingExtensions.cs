using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class ComposerPieceComposerMappingExtensions
{

    public static ComposerPieceDto ToComposerPieceDto(this Piece piece)
    {
        return new ComposerPieceDto
        {
            Id = piece.Id,
            Title = piece.Title,
        };
    }
}
