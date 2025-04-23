using Application.Models;
using Application.Models.Request.Genre;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGenreService : IServiceBase<Genre, GenreDTO, GenreCreateDTO, GenreUpdateDTO>
    {
    }
}
