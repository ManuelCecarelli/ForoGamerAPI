using Application.Models;
using Application.Models.Request.Genre;
using Application.Models.Request.Platform;
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
            #region GenreMaps
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
                .AfterMap((src, dst) =>
                {
                    if (string.IsNullOrWhiteSpace(dst.Description))
                    {
                        dst.Description = null;
                    }
                });
            #endregion

            #region PlatformMaps
            CreateMap<Platform, PlatformDTO>();

            CreateMap<PlatformCreateDTO, Platform>()
                .BeforeMap((src, dst) =>
                {
                    if (string.IsNullOrWhiteSpace(src.Description))
                    {
                        dst.Description = null;
                    }
                });

            CreateMap<PlatformUpdateDTO, Platform>()
                .AfterMap((src, dst) =>
                {
                    if (string.IsNullOrWhiteSpace(dst.Description))
                    {
                        dst.Description = null;
                    }
                });
            #endregion

            //agregar otros mapeos...
        }
    }
}
