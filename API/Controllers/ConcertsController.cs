using System.Reflection.Metadata.Ecma335;
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
        IGenericRepository<ConcertSeason> concertSeasonRepo,
        IGenericRepository<Piece> pieceRepo,
        IGenericRepository<Performer> performerRepo,
        IGenericRepository<Instrument> instrumentRepo
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

        [HttpPost("whole")]
        public async Task<ActionResult> CreateWholeConcert(CreateWholeConcertDto concert)
        {
            var concertSeason = await concertSeasonRepo.GetByIdAsync(concert.ConcertSeasonId);

            if (concertSeason == null) return BadRequest("Concert season does not exist");

            var newConcert = new Concert { Date = concert.Date, ConcertSeason = concertSeason, Description = concert.Description };

            concertRepo.Add(newConcert);

            foreach (var piece in concert.Pieces)
            {
                var newPiece = await pieceRepo.GetByIdAsync(piece.Id);
                if (newPiece == null)
                {
                    return BadRequest("Piece does not exist"); // TODO WHICH PIECE?
                }
                var newPieceInConcert = new PieceInConcert
                {
                    Concert = newConcert,
                    GroupName = piece.GroupName,
                    Piece = newPiece,
                };
                newConcert.PiecesInConcert.Add(newPieceInConcert);

                foreach (var performer in piece.Performers)
                {
                    var newPerformer = await performerRepo.GetByIdAsync(performer.Id);
                    if (newPerformer == null)
                    {
                        return BadRequest("Performer does not exist"); // TODO WHICH PIECE?
                    }
                    var newInstrument = await instrumentRepo.GetByIdAsync(performer.InstrumentId);
                    if (newInstrument == null)
                    {
                        return BadRequest("Instrument does not exist"); // TODO WHICH PIECE?
                    }
                    var newPerformerInGroup = new PerformerInGroup { Performer = newPerformer, Instrument = newInstrument, PieceInConcert = newPieceInConcert };
                    newPieceInConcert.PerformersInGroup.Add(newPerformerInGroup);
                }
            }


            if (await concertRepo.SaveAllAsync())
            {
                return CreatedAtAction("CreateConcert", new { id = newConcert.Id }, newConcert.ToDto());
            }

            return BadRequest("Problem creating concert");
        }

        private bool ConcertExists(int id)
        {
            return concertRepo.Exists(id);
        }
    }
}
