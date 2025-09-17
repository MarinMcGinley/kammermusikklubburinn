using System;
using Core.Entities;

namespace Core.Specifications;

public class PieceSpecification : BaseSpecification<Piece>
{
    public PieceSpecification(SpecParams specParams) : base(x =>
        string.IsNullOrWhiteSpace(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)
    )
    {
        AddInclude("Composer");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

    public PieceSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude("Composer");
    }

}
