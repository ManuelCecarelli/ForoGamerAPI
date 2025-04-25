using Application.Interfaces;
using Application.Models;
using Application.Models.Request.Genre;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        //private readonly ILogger<GenreController> _logger;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            var dtoList = await _genreService.GetAllAsync(cancellationToken);
            return Ok(dtoList);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<GenreDTO>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var genreDto = await _genreService.GetByIdAsync(id, cancellationToken);
            return Ok(genreDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<GenreDTO>> Create([FromBody] GenreCreateDTO genreCreateDto,
            CancellationToken cancellationToken = default)
        {
            var genreDto = await _genreService.CreateAsync(genreCreateDto, cancellationToken);
            return CreatedAtAction(
                $"{nameof(GetById)}/{genreDto.Id}",
                genreDto
            );
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] GenreUpdateDTO genreUpdateDto,
            CancellationToken cancellationToken = default)
        {
            await _genreService.UpdateAsync(id, genreUpdateDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _genreService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
