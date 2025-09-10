using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class PieceInConcertMappingExtensions
{
    public static PieceInConcertDto ToDto(this PieceInConcert pieceInConcert)
    {
        return new PieceInConcertDto
        {
            GroupName = pieceInConcert.GroupName,
            Piece = pieceInConcert.Piece.ToDto(),
            Performers = pieceInConcert.PerformersInGroup.Select(x => x.ToDto()).ToList()
        };
    }

}
