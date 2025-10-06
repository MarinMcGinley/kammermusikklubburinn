using System;
using Core.Entities;

namespace Core.Specifications;

public class ConcertSeasonSpecification : BaseSpecification<ConcertSeason>
{
    public ConcertSeasonSpecification(SpecParams specParams) : base(x =>
        string.IsNullOrWhiteSpace(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

}
