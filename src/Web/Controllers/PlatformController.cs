using Application.Interfaces;
using Application.Models;
using Application.Models.Request.Genre;
using Application.Models.Request.Platform;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PlatformDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            var dtoList = await _platformService.GetAllAsync(cancellationToken);
            return Ok(dtoList);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PlatformDTO>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var platformDto = await _platformService.GetByIdAsync(id, cancellationToken);
            return Ok(platformDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PlatformDTO>> Create([FromBody] PlatformCreateDTO platformCreateDto,
            CancellationToken cancellationToken = default)
        {
            var platformDto = await _platformService.CreateAsync(platformCreateDto, cancellationToken);

            return CreatedAtAction(
                nameof(GetById), // nombre del método que sirve para recuperar el recurso
                new { id = platformDto.Id }, // id del recurso
                platformDto // incluimos el nuevo recurso creado en el body de la respuesta
            );
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] PlatformUpdateDTO platformUpdateDto,
            CancellationToken cancellationToken = default)
        {
            await _platformService.UpdateAsync(id, platformUpdateDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _platformService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
