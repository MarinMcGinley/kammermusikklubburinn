
using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PerformersController(
        IGenericRepository<Performer> performerRepo,
        IGenericRepository<Concert> concertRepo
    ) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformerDto>>> GetPerformers([FromQuery] SpecParams specParams)
        {
            var spec = new PerformerSpecification(specParams);

            return await CreatePagedResult(performerRepo, spec, specParams.PageIndex, specParams.PageSize, p => p.ToDto());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PerformerDto>> GetPerformer(int id)
        {
            var performer = await performerRepo.GetByIdAsync(id);

            if (performer == null) return NotFound();

            return performer.ToDto();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePerformer(int id, UpdatePerformerDto performer)
        {
            if (performer.Id != id || !PerformerExists(id)) return BadRequest("Cannot update this performer");

            performerRepo.Update(new Performer { Id = performer.Id, Name = performer.Name });

            if (await performerRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the performer");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePerformer(int id)
        {
            var performer = await performerRepo.GetByIdAsync(id);

            if (performer == null) return NotFound();

            performerRepo.Remove(performer);

            if (await performerRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the performer");
        }

        [HttpPost]
        public async Task<ActionResult<Performer>> CreatePerformer(CreatePerformerDto performer)
        {


            var newPerformer = new Performer { Name = performer.Name };

            performerRepo.Add(newPerformer);

            if (await performerRepo.SaveAllAsync())
            {
                return CreatedAtAction("CreatePerformer", new { id = newPerformer.Id }, newPerformer.ToDto());
            }

            return BadRequest("Problem creating performer");
        }


        [HttpGet("{id:int}/concerts")]
        public async Task<ActionResult<IEnumerable<ConcertDto>>> GetConcerts(int id, [FromQuery] SpecParams specParams)
        {
            var spec = new ConcertSpecification(specParams, id, "PerformerId");

            return await CreatePagedResult(concertRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToDto());
        }

        private bool PerformerExists(int id)
        {
            return performerRepo.Exists(id);
        }
    }
}
