using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class ComposerMappingExtensions
{
    public static ComposerDto ToDto(this Composer composer)
    {
        return new ComposerDto
        {
            Id = composer.Id,
            Name = composer.Name
        };
    }
}
