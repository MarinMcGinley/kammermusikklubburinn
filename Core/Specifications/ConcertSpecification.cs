using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class ConcertSpecification : BaseSpecification<Concert>
{
    public ConcertSpecification(SpecParams specParams)
    {
        AddInclude("PiecesInConcert.Piece.Composer");
        AddInclude("PiecesInConcert.PerformersInGroup.Performer");
        AddInclude("PiecesInConcert.PerformersInGroup.Instrument");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }
    public ConcertSpecification(SpecParams specParams, int id, string type) : base(concertMapper(id, type))
    {
        AddInclude("PiecesInConcert.Piece.Composer");
        AddInclude("PiecesInConcert.PerformersInGroup.Performer");
        AddInclude("PiecesInConcert.PerformersInGroup.Instrument");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

    private static Expression<Func<Concert, bool>> concertMapper(int id, string type)
    {
        switch (type)
        {
            case "ConcertSeasonId":
                return x => x.ConcertSeasonId == id;
            case "PerformerId":
                return x => x.PiecesInConcert.Any(p => p.PerformersInGroup.Any(pf => pf.PerformerId == id));
            default:
                return x => false;
        }
    }

    public ConcertSpecification(int concertId) : base(x => x.Id == concertId)
    {
        AddInclude("PiecesInConcert.Piece.Composer");
        AddInclude("PiecesInConcert.PerformersInGroup.Performer");
        AddInclude("PiecesInConcert.PerformersInGroup.Instrument");
    }

}
