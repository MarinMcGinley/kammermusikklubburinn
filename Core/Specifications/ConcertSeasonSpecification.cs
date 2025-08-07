using System;
using Core.Entities;

namespace Core.Specifications;

public class ConcertSeasonSpecification : BaseSpecification<ConcertSeason>
{
    public ConcertSeasonSpecification(string? title) : base(x =>
        string.IsNullOrWhiteSpace(title) || x.Title == title
    )
    {
    }

}
