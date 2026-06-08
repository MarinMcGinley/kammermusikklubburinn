using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class ConcertSeasonMappingExtensions
{
    public static ConcertSeasonDto ToDto(this ConcertSeason concertSeason)
    {
        return new ConcertSeasonDto
        {
            Id = concertSeason.Id,
            Title = concertSeason.Title,
            BeginDate = concertSeason.BeginDate,
            EndDate = concertSeason.EndDate
            // Concerts = concertSeason.Concerts.Select(x => x.ToDto()).ToList()
        };
    }

}
