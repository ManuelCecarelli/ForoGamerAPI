using Application.Models;
using Application.Models.Request.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService : IServiceBase<User, UserDTO, UserCreateDTO, UserUpdateDTO>
    {
    }
}
