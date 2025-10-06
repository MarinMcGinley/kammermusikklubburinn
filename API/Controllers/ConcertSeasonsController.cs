

using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ConcertSeasonsController(
    IGenericRepository<ConcertSeason> concertSeasonRepo,
    IGenericRepository<Concert> concertRepo
) : BaseApiController
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSeasonDto>>> GetConcertSeasons([FromQuery] SpecParams specParams)
    {
        var spec = new ConcertSeasonSpecification(specParams);

        return await CreatePagedResult(concertSeasonRepo, spec, specParams.PageIndex, specParams.PageSize, o => o.ToDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConcertSeasonDto>> GetConcertSeason(int id)
    {
        var concertSeason = await concertSeasonRepo.GetByIdAsync(id);

        if (concertSeason == null) return NotFound();

        return concertSeason.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<ConcertSeason>> CreateConcertSeason(CreateConcertSeasonDto concertSeason)
    {
        var newConcertSeason = new ConcertSeason { Title = concertSeason.Title };
        concertSeasonRepo.Add(newConcertSeason);

        if (await concertSeasonRepo.SaveAllAsync())
        {
            return CreatedAtAction("GetConcertSeason", new { id = newConcertSeason.Id }, newConcertSeason.ToDto());
        }

        return BadRequest("Problem creating concert season");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateConcertSeason(int id, UpdateConcertSeasonDto concertSeason)
    {
        if (concertSeason.Id != id || !ConcertSeasonExists(id)) return BadRequest("Cannot update this concert season");

        concertSeasonRepo.Update(new ConcertSeason { Id = concertSeason.Id, Title = concertSeason.Title });

        if (await concertSeasonRepo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the concert season");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteConcertSeason(int id)
    {
        var concertSeason = await concertSeasonRepo.GetByIdAsync(id);

        if (concertSeason == null) return NotFound();

        concertSeasonRepo.Remove(concertSeason);

        if (await concertSeasonRepo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the concert season");
    }

    [HttpGet("{id:int}/concerts")]
    public async Task<ActionResult<IEnumerable<ConcertDto>>> GetConcerts(int id, [FromQuery] SpecParams specParams)
    {
        var spec = new ConcertSpecification(specParams, id, "ConcertSeasonId");

        return await CreatePagedResult(concertRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToDto());
    }

    private bool ConcertSeasonExists(int id)
    {
        return concertSeasonRepo.Exists(id);
    }
}
