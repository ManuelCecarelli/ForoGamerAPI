using Application.Interfaces;
using Application.Models;
using Application.Models.Request.Platform;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlatformService : ServiceBase<Platform, PlatformDTO, PlatformCreateDTO, PlatformUpdateDTO>, IPlatformService
    {
        public PlatformService(IPlatformRepository repository, IMapperService mapper) : base(repository, mapper)
        {   
        }
    }
}
