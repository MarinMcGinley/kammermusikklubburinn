using System;
using Core.Entities;

namespace Core.Specifications;

public class ConcertSeasonSpecification : BaseSpecification<ConcertSeason>
{
    public ConcertSeasonSpecification(string? title) : base(x =>
        string.IsNullOrWhiteSpace(title) || x.Title == title
    )
    {
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
