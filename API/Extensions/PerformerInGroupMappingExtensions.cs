using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class PerformerInGroupMappingExtensions
{
    public static PerformerInConcertDto ToDto(this PerformerInGroup performerInGroup)
    {

        return new PerformerInConcertDto
        {
            Id = performerInGroup.Performer.Id,
            Name = performerInGroup.Performer.Name,
            Instrument = performerInGroup.Instrument.Name,
        };
    }
}
