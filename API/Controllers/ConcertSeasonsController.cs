

using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ConcertSeasonsController(IGenericRepository<ConcertSeason> repo) : BaseApiController
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSeasonDto>>> GetConcertSeasons([FromQuery] ConcertSeriesSpecParams specParams)
    {
        var spec = new ConcertSeasonSpecification(specParams);

        return await CreatePagedResult(repo, spec, specParams.PageIndex, specParams.PageSize, o => o.ToDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConcertSeasonDto>> GetConcertSeason(int id)
    {
        var concertSeason = await repo.GetByIdAsync(id);

        if (concertSeason == null) return NotFound();

        return concertSeason.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<ConcertSeason>> CreateConcertSeason(ConcertSeason concertSeason)
    {
        repo.Add(concertSeason);

        if (await repo.SaveAllAsync())
        {
            return CreatedAtAction("GetConcertSeason", new { id = concertSeason.Id }, concertSeason);
        }

        return BadRequest("Problem creating concert season");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateConcertSeason(int id, ConcertSeason concertSeason)
    {
        if (concertSeason.Id != id || !ConcertSeasonExists(id)) return BadRequest("Cannot update this concert season");

        repo.Update(concertSeason);

        if (await repo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the concert season");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteConcertSeason(int id)
    {
        var concertSeason = await repo.GetByIdAsync(id);

        if (concertSeason == null) return NotFound();

        repo.Remove(concertSeason);

        if (await repo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the concert season");
    }

    private bool ConcertSeasonExists(int id)
    {
        return repo.Exists(id);
    }
}
