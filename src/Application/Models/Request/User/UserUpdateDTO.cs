using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.User
{
    public class UserUpdateDTO
    {
        [Required, StringLength(30, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        public string? ProfilePhotoURL { get; set; }
    }
}
