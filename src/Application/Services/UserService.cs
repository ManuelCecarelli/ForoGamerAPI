using Application.Interfaces;
using Application.Models;
using Application.Models.Request.User;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : ServiceBase<User, UserDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        public UserService(IUserRepository repository, IMapperService mapper) : base(repository, mapper)
        {
        }
    }
}
