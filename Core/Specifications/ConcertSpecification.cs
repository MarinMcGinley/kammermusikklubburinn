using System;
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
    public ConcertSpecification(SpecParams specParams, int concertSeasonId) : base(x => x.ConcertSeasonId == concertSeasonId)
    {
        AddInclude("PiecesInConcert.Piece.Composer");
        AddInclude("PiecesInConcert.PerformersInGroup.Performer");
        AddInclude("PiecesInConcert.PerformersInGroup.Instrument");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

    public ConcertSpecification(int concertId) : base(x => x.Id == concertId)
    {
        AddInclude("PiecesInConcert.Piece.Composer");
        AddInclude("PiecesInConcert.PerformersInGroup.Performer");
        AddInclude("PiecesInConcert.PerformersInGroup.Instrument");
    }

}
