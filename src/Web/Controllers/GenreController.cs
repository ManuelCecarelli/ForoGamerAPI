using Application.Interfaces;
using Application.Models;
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
    }
}
