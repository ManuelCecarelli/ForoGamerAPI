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
            try
            {
                return await _genreService.GetByIdAsync(id, cancellationToken);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<GenreDTO>> Create([FromBody] GenreCreateDTO genreCreateDto,
            CancellationToken cancellationToken = default)
        {
            return await _genreService.CreateAsync(genreCreateDto, cancellationToken);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] GenreUpdateDTO genreUpdateDto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _genreService.UpdateAsync(id, genreUpdateDto, cancellationToken);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await _genreService.DeleteAsync(id, cancellationToken);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
