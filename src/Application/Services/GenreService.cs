using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService : ServiceBase<Genre, GenreDTO>, IGenreService
    {
        public GenreService(IGenreRepository repository, IMapperService mapper) : base(repository, mapper)
        {  
        }
    }
}
