using System;
using Core.Entities;

namespace Core.Specifications;

public class ConcertSeasonSpecification : BaseSpecification<ConcertSeason>
{
    public ConcertSeasonSpecification(ConcertSeriesSpecParams specParams) : base(x =>
        string.IsNullOrWhiteSpace(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        // AN EXAMPLE OF SPECIFICATION
        // switch (title)
        // {
        //     case "priceAsc":
        //         AddOrderBy(x => x.Title);
        //         break;
        //     default:
        //         AddOrderBy(x => x.Title);
        //         break;

        // }
    }

}
