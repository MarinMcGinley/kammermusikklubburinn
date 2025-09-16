using System;
using API.DTOs;
using Core.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Extensions;

public static class StandAloneComposerMappingExtensions
{
    public static StandAloneComposerDto ToStandAloneComposerDto(this Composer composer)
    {
        return new StandAloneComposerDto
        {
            Id = composer.Id,
            Name = composer.Name,
            Pieces = composer.Pieces.Select(x => x.ToComposerPieceDto()).ToList()
        };
    }

}
