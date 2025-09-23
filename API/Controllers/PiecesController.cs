using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class PiecesController(
        IGenericRepository<Piece> pieceRepo,
        IGenericRepository<Composer> composerRepo,
        IGenericRepository<Concert> concertRepo
    ) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceDto>>> GetPieces([FromQuery] SpecParams specParams)
        {
            var spec = new PieceSpecification(specParams);

            return await CreatePagedResult(pieceRepo, spec, specParams.PageIndex, specParams.PageSize, p => p.ToDto());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PieceDto>> GetPiece(int id)
        {
            var spec = new PieceSpecification(id);
            var Piece = await pieceRepo.GetEntityWithSpec(spec);

            if (Piece == null) return NotFound();

            return Piece.ToDto();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePiece(int id, UpdatePieceDto piece)
        {
            if (piece.Id != id || !PieceExists(id)) return BadRequest("Cannot update this piece");
            var composer = await composerRepo.GetByIdAsync(piece.ComposerId);

            if (composer == null)
            {
                return BadRequest("This composer does not exist");
            }

            pieceRepo.Update(new Piece { Id = piece.Id, ComposerId = piece.ComposerId, Title = piece.Title });

            if (await pieceRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the piece");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePiece(int id)
        {
            var Piece = await pieceRepo.GetByIdAsync(id);

            if (Piece == null) return NotFound();

            pieceRepo.Remove(Piece);

            if (await pieceRepo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the piece");
        }

        [HttpPost]
        public async Task<ActionResult<Piece>> CreatePiece(CreatePieceDto piece)
        {

            var composer = await composerRepo.GetByIdAsync(piece.ComposerId);

            if (composer == null)
            {
                return BadRequest("This composer does not exist");
            }

            var newPiece = new Piece { Title = piece.Title, ComposerId = piece.ComposerId };
            pieceRepo.Add(newPiece);

            if (await pieceRepo.SaveAllAsync())
            {
                return CreatedAtAction("CreatePiece", new { id = newPiece.Id }, newPiece.ToDto());
            }
            return BadRequest("Problem creating piece");
        }


        [HttpGet("{id:int}/concerts")]
        public async Task<ActionResult<IEnumerable<ConcertDto>>> GetConcerts(int id, [FromQuery] SpecParams specParams)
        {
            var spec = new ConcertSpecification(specParams, id, "PieceId");

            return await CreatePagedResult(concertRepo, spec, specParams.PageIndex, specParams.PageSize, c => c.ToDto());
        }

        private bool PieceExists(int id)
        {
            return pieceRepo.Exists(id);
        }
    }
}
