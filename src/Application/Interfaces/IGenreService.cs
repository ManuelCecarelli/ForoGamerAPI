using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGenreService : IServiceBase<Genre, GenreDTO>
    {
    }
}
