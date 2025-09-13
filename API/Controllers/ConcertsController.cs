using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ConcertsController(
        IGenericRepository<Concert> concertRepo,
        IGenericRepository<ConcertSeason> concertSeasonRepo
    ) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConcertDto>>> GetConcerts([FromQuery] SpecParams specParams)
        {
            var spec = new ConcertSpecification(specParams);

            return await CreatePagedResult(concertRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToDto());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ConcertDto>> GetConcert(int id)
        {
            var spec = new ConcertSpecification(id);

            var concert = await concertRepo.GetEntityWithSpec(spec);

            if (concert == null) return NotFound();

            return concert.ToDto();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateConcert(int id, UpdateConcertDto concert)
        {
            if (concert.Id != id || !ConcertExists(id)) return BadRequest("Cannot update this concert season");

            var concertSeason = await concertSeasonRepo.GetByIdAsync(concert.ConcertSeasonId);

            if (concertSeason == null) return BadRequest("Concert season does not exist");

            concertRepo.Update(new Concert { Id = concert.Id, Date = concert.Date, ConcertSeason = concertSeason, Description = concert.Description });

            if (await concertRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the concert");
        }

        [HttpPost]
        public async Task<ActionResult<Concert>> CreateConcert(CreateConcertDto concert)
        {
            var concertSeason = await concertSeasonRepo.GetByIdAsync(concert.ConcertSeasonId);

            if (concertSeason == null) return BadRequest("Concert season does not exist");

            var newConcert = new Concert { Date = concert.Date, ConcertSeason = concertSeason, Description = concert.Description };

            concertRepo.Add(newConcert);

            if (await concertRepo.SaveAllAsync())
            {
                return CreatedAtAction("CreateConcert", new { id = newConcert.Id }, newConcert.ToDto());
            }

            return BadRequest("Problem creating concert");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteConcert(int id)
        {
            var concert = await concertRepo.GetByIdAsync(id);

            if (concert == null) return NotFound();

            concertRepo.Remove(concert);

            if (await concertRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the concert");
        }

        private bool ConcertExists(int id)
        {
            return concertRepo.Exists(id);
        }
    }
}
