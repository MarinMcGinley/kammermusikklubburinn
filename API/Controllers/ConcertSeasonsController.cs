using System;
using System.Net.Http.Headers;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ConcertSeasonsController(IGenericRepository<ConcertSeason> repo) : BaseApiController
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSeason>>> GetConcertSeasons([FromQuery] ConcertSeriesSpecParams specParams)
    {
        var spec = new ConcertSeasonSpecification(specParams);

        return await CreatePagedResult(repo, spec, specParams.PageIndex, specParams.PageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConcertSeason>> GetConcertSeason(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null) return NotFound();

        return product;
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
