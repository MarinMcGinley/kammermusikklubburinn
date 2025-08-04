using System;
using System.Net.Http.Headers;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertSeasonsController : ControllerBase
{
    private readonly ConcertContext context;

    public ConcertSeasonsController(ConcertContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConcertSeason>>> GetConcertSeasons()
    {
        return await context.ConcertSeasons.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConcertSeason>> GetConcertSeason(int id)
    {
        var product = await context.ConcertSeasons.FindAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ConcertSeason>> CreateConcertSeason(ConcertSeason concertSeason)
    {
        context.ConcertSeasons.Add(concertSeason);

        await context.SaveChangesAsync();

        return concertSeason;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateConcertSeason(int id, ConcertSeason concertSeason)
    {
        if (concertSeason.Id != id || !ConcertSeasonExists(id)) return BadRequest("Cannot update this concert season");

        context.Entry(concertSeason).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteConcertSeason(int id)
    {
        var concertSeason = await context.ConcertSeasons.FindAsync(id);

        if (concertSeason == null) return NotFound();

        context.ConcertSeasons.Remove(concertSeason);

        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConcertSeasonExists(int id)
    {
        return context.ConcertSeasons.Any(x => x.Id == id);
    }
}
