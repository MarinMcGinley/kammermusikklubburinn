using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class PerformerInGroupMappingExtensions
{
    public static PerformerDto ToDto(this PerformerInGroup performerInGroup)
    {

        return new PerformerDto
        {
            Id = performerInGroup.Performer.Id,
            Name = performerInGroup.Performer.Name,
            Instrument = performerInGroup.Instrument.Name,
        };
    }
}
