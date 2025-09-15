using System;
using Core.Entities;

namespace Core.Specifications;

public class PerformerSpecification : BaseSpecification<Performer>
{

    public PerformerSpecification(SpecParams specParams) : base(x =>
        string.IsNullOrWhiteSpace(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

}
