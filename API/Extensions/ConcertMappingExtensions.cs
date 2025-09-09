using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class ConcertMappingExtensions
{

    public static ConcertDto ToDto(this Concert concert)
    {
        return new ConcertDto
        {
            Id = concert.Id,
            Description = concert.Description,
            Date = concert.Date,
            PiecesInConcert = concert.PiecesInConcert.Select(x => x.ToDto()).ToList()
        };
    }
}
