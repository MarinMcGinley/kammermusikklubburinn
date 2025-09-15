using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class PerformerMappingExtensions
{

    public static PerformerDto ToDto(this Performer performer)
    {
        return new PerformerDto
        {
            Name = performer.Name,
            Id = performer.Id,
        };
    }

}
