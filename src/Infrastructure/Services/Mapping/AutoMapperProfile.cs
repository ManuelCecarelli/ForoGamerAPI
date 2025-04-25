using Application.Models;
using Application.Models.Request.Genre;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genre, GenreDTO>(); //Se puede agregar ".ReverseMap();" para permitir el mapeo inverso.

            CreateMap<GenreCreateDTO, Genre>()
                .BeforeMap((src, dst) =>
                {
                    if (string.IsNullOrWhiteSpace(src.Description))
                    {
                        dst.Description = null;
                    }
                });

            CreateMap<GenreUpdateDTO, Genre>()
                .BeforeMap((src, dst) =>
                {
                    if (string.IsNullOrWhiteSpace(src.Description))
                    {
                        dst.Description = null;
                    }
                });

            //agregar otros mapeos...
        }
    }
}
