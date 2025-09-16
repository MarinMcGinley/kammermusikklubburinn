using System;
using System.Data.Common;
using Core.Entities;

namespace Core.Specifications;

public class ComposerSpecification : BaseSpecification<Composer>
{
    public ComposerSpecification(SpecParams specParams) : base(x =>
            string.IsNullOrWhiteSpace(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)
        )
    {
        AddInclude("Pieces");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

    public ComposerSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude("Pieces");
    }
}
