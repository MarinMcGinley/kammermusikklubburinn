using System;
using System.Net.Http.Headers;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertSeasonsController(IConcertSeasonRepository repo) : ControllerBase
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSeason>>> GetConcertSeasons()
    {
        return Ok(await repo.GetConcertSeasonsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConcertSeason>> GetConcertSeason(int id)
    {
        var product = await repo.GetConcertSeasonByIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ConcertSeason>> CreateConcertSeason(ConcertSeason concertSeason)
    {
        repo.AddConcertSeason(concertSeason);

        if (await repo.SaveChangesAsync())
        {
            return CreatedAtAction("GetConcertSeason", new { id = concertSeason.Id }, concertSeason);
        }

        return BadRequest("Problem creating concert season");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateConcertSeason(int id, ConcertSeason concertSeason)
    {
        if (concertSeason.Id != id || !ConcertSeasonExists(id)) return BadRequest("Cannot update this concert season");

        repo.UpdateConcertSeason(concertSeason);

        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the concert season");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteConcertSeason(int id)
    {
        var concertSeason = await repo.GetConcertSeasonByIdAsync(id);

        if (concertSeason == null) return NotFound();

        repo.DeleteConcertSeason(concertSeason);

        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the concert season");
    }

    private bool ConcertSeasonExists(int id)
    {
        return repo.ConcertSeasonExists(id);
    }
}
