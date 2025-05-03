using Application.Models;
using Application.Models.Request.Platform;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlatformService : IServiceBase<Platform, PlatformDTO, PlatformCreateDTO, PlatformUpdateDTO>
    {
    }
}
