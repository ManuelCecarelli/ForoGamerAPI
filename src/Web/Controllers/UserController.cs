using Application.Interfaces;
using Application.Models;
using Application.Models.Request.Genre;
using Application.Models.Request.User;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            var dtoList = await _userService.GetAllAsync(cancellationToken);
            return Ok(dtoList);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<UserDTO>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var userDto = await _userService.GetByIdAsync(id, cancellationToken);
            return Ok(userDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserDTO>> Create([FromBody] UserCreateDTO userCreateDto,
            CancellationToken cancellationToken = default)
        {
            var userDto = await _userService.CreateAsync(userCreateDto, cancellationToken);

            return CreatedAtAction(
                nameof(GetById), // nombre del método que sirve para recuperar el recurso
                new { id = userDto.Id }, // id del recurso
                userDto // incluimos el nuevo recurso creado en el body de la respuesta
            );
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UserUpdateDTO userUpdateDto,
            CancellationToken cancellationToken = default)
        {
            await _userService.UpdateAsync(id, userUpdateDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _userService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
