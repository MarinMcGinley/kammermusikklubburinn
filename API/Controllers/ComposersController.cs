using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ComposersController(IGenericRepository<Composer> composerRepo, IGenericRepository<Concert> concertRepo) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandAloneComposerDto>>> GetComposers([FromQuery] SpecParams specParams)
        {
            var spec = new ComposerSpecification(specParams);

            return await CreatePagedResult(composerRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToStandAloneComposerDto());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StandAloneComposerDto>> GetComposer(int id)
        {
            var spec = new ComposerSpecification(id);
            var composer = await composerRepo.GetEntityWithSpec(spec);

            if (composer == null) return NotFound();

            return composer.ToStandAloneComposerDto();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateComposer(int id, UpdateComposerDto composer)
        {
            if (composer.Id != id || !ComposerExists(id)) return NotFound();

            composerRepo.Update(new Composer { Id = composer.Id, Name = composer.Name });

            if (await composerRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the composer");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteComposer(int id)
        {
            var composer = await composerRepo.GetByIdAsync(id);

            if (composer == null) return NotFound();

            composerRepo.Remove(composer);

            if (await composerRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the composer");
        }

        [HttpPost]
        public async Task<ActionResult<Composer>> CreateComposer(CreateComposerDto composer)
        {

            var newComposer = new Composer { Name = composer.Name };

            composerRepo.Add(newComposer);

            if (await composerRepo.SaveAllAsync())
            {
                return CreatedAtAction("CreateComposer", new { id = newComposer.Id }, newComposer.ToDto());
            }

            return BadRequest("Problem creating composer");
        }

        [HttpGet("{id:int}/concerts")]
        public async Task<ActionResult<IEnumerable<ConcertDto>>> GetConcerts(int id, [FromQuery] SpecParams specParams)
        {
            var spec = new ConcertSpecification(specParams, id, "ComposerId");

            return await CreatePagedResult(concertRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToDto());
        }

        private bool ComposerExists(int id)
        {
            return composerRepo.Exists(id);

        }
    }
}
